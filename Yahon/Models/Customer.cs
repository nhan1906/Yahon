using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebGrease.Css;

namespace Yahon.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password field cannot be blank.")]
        [MinLength(12, ErrorMessage = "Password must be at least {1} characters.")]
        public string Password { get; set; }
        
        public byte[] Salt { get; set; }
        
        [NotMapped]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name = "Last name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input your last name.")]
        public string LastName { get; set; }
        [Display(Name = "First name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please input your first name.")]
        public string FirstName { get; set; }
        
/*        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime? DateOfBirth { get; set; }*/
        
        [Display(Name = "Address")]
        public string Address { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();
    }
}