namespace StudentInfo.Entity.DTO.Message
{
    public class MessageAddDTO
    {
        /// <summary>
        /// Mesaj Açıklaması
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Öğrenci Id
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Öğretmen Id
        /// </summary>
        public int TeacherId { get; set; }
    }
}
