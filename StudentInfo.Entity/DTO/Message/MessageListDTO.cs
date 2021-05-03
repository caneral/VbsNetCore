namespace StudentInfo.Entity.DTO.Message
{
    public class MessageListDTO
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
        /// Öğretmen Adı
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// Öğretmen Soyadı
        /// </summary>
        public string TeacherSurname { get; set; }
    }
}
