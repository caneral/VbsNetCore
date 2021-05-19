using ApplicationCore.Entity;
using System;
using System.Collections.Generic;

namespace StudentInfo.Entity.Entity
{
    /// <summary>
    /// Öğrenci Bilgileri
    /// </summary>
    public class Student : BaseEntity, IAudit
    {
        /// <summary>
        /// Öğrenci Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Öğrenci T.C. Kimlik Numarası
        /// </summary>
        public string TCNumber { get; set; }

        /// <summary>
        /// Öğrenci Ad
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Öğrenci Soyad
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Öğrenci Okul Numarası
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Öğrencinin Sınıfı
        /// </summary>
        public int ClassId { get; set; }
        public Class ClassFK { get; set; }

        /// <summary>
        /// Veli Id 
        /// </summary>
        public int ParentId { get; set; }
        public Parent ParentFK { get; set; }

        public ICollection<Meet> Meets { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
