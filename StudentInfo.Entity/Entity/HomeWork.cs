using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.Entity
{
    public class HomeWork : BaseEntity, IAudit
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string HomeworkSubject { get; set; }
        public string HomeworkDesc { get; set; }
        public int ClassId { get; set; }
        public Class ClassFK { get; set; }
        public string FileId { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
