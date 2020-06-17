using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public interface IDbContextFactory
    {
        DbContext GetContext();
    }

    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContextOptions<ValidasiDBContext> options;

        public DbContextFactory(DbContextOptions<ValidasiDBContext> options)
        {
            this.options = options;
        }

        public DbContext GetContext()
        {
            DbContext ctx = new ValidasiDBContext(options); ;
            ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return ctx;
        }
    }
}
