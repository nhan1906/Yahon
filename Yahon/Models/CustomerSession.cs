using System.ComponentModel.DataAnnotations;

namespace Yahon.Models
{
    public class CustomerSession
    {
        [Key]
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input your email.")]
        public string EmailId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input your password.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}