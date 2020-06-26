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
        AlumniSubdomain GetNIM(string? id);
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

        public AlumniSubdomain GetAlumniById(string Id)
        {
            var alumni = alumniRepository.GetByID(Id);
            AlumniSubdomain alumniSubdomain = new AlumniSubdomain
            {
                AdminData = alumni
            };
            return alumniSubdomain;
        }

        public AlumniSubdomain GetNIM(string? id)
        {
            var test = alumniRepository.GetByID(id);
            AlumniSubdomain alumniSubdomain = new AlumniSubdomain
            {
                AdminData = test
            };
            return alumniSubdomain;
        }
    }
}
