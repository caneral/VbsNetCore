using ApplicationCore.Entity;
using System;

namespace StudentInfo.Entity.Entity
{
    /// <summary>
    /// Duyuru, Mesaj, Ödev 
    /// </summary>
    public class Message : BaseEntity, IAudit
    {
        /// <summary>
        /// Mesaj Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mesaj Açıklaması
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Öğrenci Id
        /// </summary>
        public int? StudentId { get; set; }
        public Student StudentFK { get; set; }

        /// <summary>
        /// Öğretmen Id
        /// </summary>
        public int TeacherId { get; set; }
        public Teacher TeacherFK { get; set; }

        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
