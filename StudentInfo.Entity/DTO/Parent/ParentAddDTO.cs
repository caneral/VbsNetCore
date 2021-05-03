using ApplicationCore.Entity;

namespace StudentInfo.Entity.DTO.Parent
{
    public class ParentAddDTO : IDTO
    {
        /// <summary>
        /// Veli Adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Veli Soyadı
        /// </summary>
        public string Surname { get; set; }
    }
}
