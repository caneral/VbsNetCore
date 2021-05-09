using System.ComponentModel.DataAnnotations;

namespace StudentInfo.Entity.Entity
{
    public enum AppClaimEnum
    {
        [Display(Name = "Öğretmen")]
        Teacher = 1,

        [Display(Name = "Öğrenci")]
        Parent = 2,

        [Display(Name = "Admin")]
        Admin = 3 
    }
}
