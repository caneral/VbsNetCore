using ApplicationCore.Entity;

namespace StudentInfo.Entity.DTO.Student
{
    public class StudentListDTO : IDTO
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
        /// Veli Ad-Soyad
        /// </summary>
        public string ParentName { get; set; }
        public string ParentSurname { get; set; }
    }
}
