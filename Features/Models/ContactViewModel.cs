using System.ComponentModel.DataAnnotations;


namespace ContosoUniversity.Features.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Full name")]
        public string Name { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}