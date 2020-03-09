using System.ComponentModel.DataAnnotations;

namespace The_Job_Box.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public object LoginModel { get; set; }
    }
}
