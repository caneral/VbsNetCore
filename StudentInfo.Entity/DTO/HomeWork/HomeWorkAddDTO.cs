using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.DTO.HomeWork
{
    public class HomeWorkAddDTO
    {
        public string CourseName { get; set; }
        public string HomeworkSubject { get; set; }
        public string HomeworkDesc { get; set; }
        public int ClassId { get; set; }
    }
}
