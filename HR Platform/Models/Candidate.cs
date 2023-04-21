using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HR_Platform.Models
{
    public class Candidate
    {
        [Required(ErrorMessage ="CandidateID is required")]
        public int CandidateID { get; set; }


        [DisplayName("Full name")]
        [Required(ErrorMessage ="Full name is required")]
        [MaxLength(40)]
        public string FullName { get; set; }


        [DisplayName("Date of birth")]
        [Required(ErrorMessage ="Date of birth is required")]
        public string DateOfBirth { get; set; }


        [DisplayName("Contact")]
        [Required(ErrorMessage ="Contact is required")]
        [MaxLength(20)]
        public string Contact { get; set; }


        [DisplayName("E-mail")]
        [Required(ErrorMessage ="E-mail is required")]
        [MaxLength(40)]
        public string Email { get; set; }


        [DisplayName("Skill")]
        [Required(ErrorMessage ="Skill is required")]
        public Skill? Skills { get; set; }=new Skill();

    }
}
