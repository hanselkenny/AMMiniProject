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
        [Required(ErrorMessage ="NIM harus diisi")]
        public string ExternalSystemID { get; set; }

        [Required(ErrorMessage = "No. Ijazah harus diisi")]
        public string NoIjazah { get; set; }

        [Required(ErrorMessage = "Tanggal lahir harus diisi")]
        public DateTime? Tgl_Lahir { get; set; }

        [Required(ErrorMessage = "Tanggal lulus harus diisi")]
        public DateTime? Tgl_Lulus { get; set; }
    }
}
