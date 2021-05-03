using ApplicationCore.Entity;
using System;
using System.Collections.Generic;

namespace StudentInfo.Entity.Entity
{
    /// <summary>
    /// Öğrenci Veli Bilgileri
    /// </summary>
    public class Parent : BaseEntity, IAudit
    {
        /// <summary>
        /// Veli Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Veli Adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Veli Soyadı
        /// </summary>
        public string Surname { get; set; }

        public ICollection<Student> Students { get; set; }

        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
