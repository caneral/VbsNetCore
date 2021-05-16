using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.DTO.Meet
{
    public class MeetAddDTO
    {
        public string MeetDate { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }
}
