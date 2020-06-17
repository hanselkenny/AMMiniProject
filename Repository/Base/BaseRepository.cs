using Microsoft.EntityFrameworkCore;
using Model.DTO.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected ValidasiDBContext Context;
        private ValidasiDBContext PrevDbContext;

        public BaseRepository(IDbContextFactory dbContextFactory)
        {
            Context = (ValidasiDBContext)dbContextFactory.GetContext();
        }

        public void UseContext(DbContext context)
        {
            PrevDbContext = this.Context;
            this.Context = (ValidasiDBContext)context;
        }

        public void RevertToPreviousDbContext()
        {
            this.Context = PrevDbContext;
            PrevDbContext = null;
        }

        public IEnumerable<TEntity> FindAll()
        {
            IEnumerable<TEntity> entities = Context.Set<TEntity>().Where(x => !x.StrSc.Equals('D'));
            return entities;
        }
        
        public TEntity Insert(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public IEnumerable<TEntity> InsertMultiple(List<TEntity> entities)
        {
            for (int i = 0; i < entities.Count; i++)
                Context.Add(entities[i]);
            Context.SaveChanges();
            //entities.ForEach(x => Context.Entry(x).State = EntityState.Detached);
            return entities;
        }
        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            Context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                Context.Remove(entity);
                Context.SaveDeletion();
            }
        }
    }
}
