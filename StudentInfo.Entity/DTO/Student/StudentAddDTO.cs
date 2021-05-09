using ApplicationCore.Entity;

namespace StudentInfo.Entity.DTO.Student
{
    public class StudentAddDTO : IDTO
    {
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
        /// Sınıf id
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Veli Id 
        /// </summary>
        public int ParentId { get; set; }
    }
}
