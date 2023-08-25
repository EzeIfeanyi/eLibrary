using System.ComponentModel.DataAnnotations;

namespace eLibrary.Models;

public class ForgotPasswordViewModel
{
    [Required]
    public string Email { get; set; }
}
