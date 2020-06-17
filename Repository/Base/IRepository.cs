using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Base
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        IEnumerable<TEntity> FindAll();
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> InsertMultiple(List<TEntity> entities);
        void Delete(TEntity entity);
    }
}
