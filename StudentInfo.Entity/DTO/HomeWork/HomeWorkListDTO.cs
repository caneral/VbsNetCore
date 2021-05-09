using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.DTO.HomeWork
{
    public class HomeWorkListDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string HomeworkSubject { get; set; }
        public string HomeworkDesc { get; set; }
        public string ClassName { get; set; }
    }
}
