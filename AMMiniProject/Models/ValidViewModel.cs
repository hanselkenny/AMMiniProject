using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMMiniProject.Models
{
    public class ValidViewModel
    {
        public string ExternalSystemID { get; set; }

        public string NoIjazah { get; set; }

        public string Name { get; set; }
      
        public DateTime Tgl_Lahir { get; set; }

        public DateTime Tgl_Lulus { get; set; }

        public int AcadProgramId { get; set; }

        public AcadProgram AcadProgramDesc { get; set; }
    }

    public class AcadProgram
    {
        public int AcadProgramId { get; set; }

        public string AcadProgramDesc { get; set; }

        public int GelarId { get; set; }
        public ProgramDegree Gelar { get; set; }
    }

    public class ProgramDegree
    {
        public int GelarId { get; set; }

        public string Gelar { get; set; }
    }
}
