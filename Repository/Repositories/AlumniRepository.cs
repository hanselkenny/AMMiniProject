using Model.DTO;
using Repository.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public interface IAlumniRepository : IRepository<AlumniDTO>
    {
        AlumniDTO GetByID(string Id);
    }
    public class AlumniRepository : BaseRepository<AlumniDTO>, IAlumniRepository
    {
        public AlumniRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }

        public AlumniDTO GetByID(string Id)
        {
            return Context.alumniDTOs.Where(x => x.ExternalSystemId.Equals(Id) && x.StrSc.Equals('A')).FirstOrDefault();
        }
    }
}
