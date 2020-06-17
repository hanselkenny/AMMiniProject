using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.DTO.Base;
using Model.DTO;
using System;
using System.Collections.Generic;

namespace Repository.Context
{
    public class ValidasiDBContext : DbContext
    {
        public ValidasiDBContext(DbContextOptions<ValidasiDBContext> options) : base(options)
        {
        }
		public DbSet<AlumniDTO> alumniDTOs{ get; set; }
		public override int SaveChanges()
		{
			OnBeforeSave();
			return base.SaveChanges();
		}

		public int SaveDeletion()
		{
			OnBeforeDelete();
			return base.SaveChanges();
		}

		public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
		{
			Entry(entity).State = EntityState.Deleted;
			return base.Update(entity);
		}

		private void OnBeforeSave()
		{
			IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				if (entry.Entity is BaseModel model)
				{
					switch (entry.State)
					{
						case EntityState.Added:
							model.SetUserIn("testing");
							model.SetDateIn(DateTime.Now);
							model.SetDateUp(null);
							model.SetUserUp(null);
							model.SetStr('A');
							break;
						case EntityState.Modified:
							model.SetStr('A');
							model.SetUserUp("testing");
							model.SetDateUp(DateTime.Now);
							break;
						case EntityState.Deleted:
							model.SetStr('D');
							break;
					}
				}
			}
		}

		private void OnBeforeDelete()
		{
			IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				if (entry.Entity is BaseModel model)
				{
					model.SetDateUp(DateTime.Now);
					model.SetUserUp("testing");
					model.SetStr('D');
				}
			}
		}
	}
}