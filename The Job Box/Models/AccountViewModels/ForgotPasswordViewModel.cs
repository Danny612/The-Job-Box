using System.ComponentModel.DataAnnotations;

namespace The_Job_Box.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
