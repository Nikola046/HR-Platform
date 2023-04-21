using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_Platform.Models
{
    public class Skill
    {
        [Required(ErrorMessage ="SkillID is required")]
        public int SkillID { get; set; }


        [DisplayName("Skill name")]
        [Required(ErrorMessage = "Skill name is required")]
        [MaxLength(60)]
        public string SkillName { get; set; } = "";


        [DisplayName("Foreign language")]
        [Required(ErrorMessage = "Foreign name is required")]
        [MaxLength(50)]
        public string ForeignLanguage { get; set; } = "";


        [DisplayName("Code")]
        [Required(ErrorMessage = "Code is required")]
        [MaxLength(20)]
        public string Code { get; set; } = "";
    }
}
