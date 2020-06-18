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
        AlumniSubdomain GetAlumniById(string Id);
    }
    public class AlumniService : IAlumniService
    {
        private IAlumniRepository alumniRepository;
        public AlumniService(IAlumniRepository alumniRepository)
        {
            this.alumniRepository = alumniRepository;
        }

        public AlumniSubdomain GetAlumniById(string Id)
        {
            var alumni = alumniRepository.GetByID(Id);
            AlumniSubdomain alumniSubdomain = new AlumniSubdomain
            {
                AdminData = alumni
            };
            return alumniSubdomain;
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
