using Model.DTO;
using Model.Subdomains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMMiniProject.Models
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "NIM")]
        public string ExternalSystemId { get; set; }

        [Required]
        [Display(Name = "NoIjazah")]
        public string NoIjazah { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Tanggal Lahir")]
        [DataType(DataType.Date)]
        public DateTime TanggalLhr { get; set; }

        [Required]
        [Display(Name = "Tanggal Lulus")]
        [DataType(DataType.Date)]
        public DateTime TanggalLls { get; set; }

        public List<AlumniSubdomain> alumniDTO { get; set; }

        public AlumniSubdomain alumniAja { get; set; }
    }
}
