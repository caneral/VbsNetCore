using ApplicationCore.Entity;
using System;

namespace StudentInfo.Entity.Entity
{
    /// <summary>
    /// Duyuru
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
        /// Sınıf Id
        /// </summary>
        public int ClassId { get; set; }
        public Student ClassFK { get; set; }

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
