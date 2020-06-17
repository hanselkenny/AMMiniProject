using Model.Subdomains;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Module
{
    public interface IAlumniService
    {
        List<AlumniSubdomain> GetAlumnis();
    }
    public class AlumniService : IAlumniService
    {
        private IAlumniRepository alumniRepository;
        public AlumniService(IAlumniRepository alumniRepository)
        {
            this.alumniRepository = alumniRepository;
        }

        public List<AlumniSubdomain> GetAlumnis()
        {
            return alumniRepository.FindAll().Select(x => new AlumniSubdomain
            {
                AdminData = x
            }).ToList();
        }
    }
}
