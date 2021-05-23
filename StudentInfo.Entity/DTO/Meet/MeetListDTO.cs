using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.DTO.Meet
{
    public class MeetListDTO
    {
        public int Id { get; set; }
        public string MeetDate { get; set; }
        public string StudentFullName { get; set; }
        public string StudentNumber { get; set; }
        public string TeacherFullName { get; set; }
        public int IsOkay { get; set; }
    }
}
