using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.Entity.Entity
{
    public class Meet : BaseEntity, IAudit
    {
        public int Id { get; set; }
        public string MeetDate { get; set; }
        public int StudentId { get; set; }
        public Student StudentFK { get; set; }
        public int TeacherId { get; set; }
        public Teacher TeacherFK { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
