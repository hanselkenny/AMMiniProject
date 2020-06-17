using Model.DTO;
using Repository.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public interface IAlumniRepository : IRepository<AlumniDTO>
    {
    }
    public class AlumniRepository : BaseRepository<AlumniDTO>, IAlumniRepository
    {
        public AlumniRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
