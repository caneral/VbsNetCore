using ApplicationCore.Entity;
using System;

namespace StudentInfo.Entity.Entity
{
    /// <summary>
    /// Öğrenci - Öğretmen İlişki Bilgileri
    /// </summary>
    public class StudentTeacher : BaseEntity, IAudit
    {
        /// <summary>
        /// İlişki Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Öğretmen Id
        /// </summary>
        public int TeacherId { get; set; }
        public Teacher TeacherFK { get; set; }

        /// <summary>
        /// Öğrenci Id
        /// </summary>
        public int StudentId { get; set; }
        public Student StudentFK { get; set; }

        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
