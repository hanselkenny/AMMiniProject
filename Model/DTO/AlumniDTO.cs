using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("MsAlumni")]
    public class AlumniDTO : BaseModel
    {
        [Key]
        [Column("ExternalSystemId")]
        public string ExternalSystemId { get; set; }
        [Column("NoIjazah")]
        public string NoIjazah { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Tgl_Lahir")]
        public DateTime TanggalLahir { get; set; }
        [Column("Tgl_Lulus")]
        public DateTime TanggalLulus { get; set; }
        [Column("File_dwd")]
        public string FileName{ get; set; }
        [Column("JurusanId")]
        public int JurusanId { get; set; }
    }
}
