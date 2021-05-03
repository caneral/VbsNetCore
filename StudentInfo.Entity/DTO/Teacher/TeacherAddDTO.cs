namespace StudentInfo.Entity.DTO.Teacher
{
    public class TeacherAddDTO
    {
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
    }
}
