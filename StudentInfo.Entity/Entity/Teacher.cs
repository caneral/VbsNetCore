using ApplicationCore.Entity;
using System;
using System.Collections.Generic;

namespace StudentInfo.Entity.Entity
{
    /// <summary>
    /// Öğretmen Bilgileri
    /// </summary>
    public class Teacher : BaseEntity, IAudit
    {
        /// <summary>
        /// Öğretmen Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Öğretmen Adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Öğretmen Soyadı
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Öğretmen T.C. Kimlik Numarası
        /// </summary>
        public string TCNumber { get; set; }
        public ICollection<Meet> Meets { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
