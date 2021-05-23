using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.DTO.Meet
{
    public class MeetDTO
    {
        public int Id { get; set; }
        public string MeetDate { get; set; }
        public int StudentId { get; set; }
        public string TeacherFullName { get; set; }
        public int IsOkay { get; set; }
    }
}
