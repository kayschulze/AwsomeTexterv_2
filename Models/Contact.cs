using System;
using System.ComponentModel.DataAnnotations;

namespace AwesomeTexter.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool IsChecked { get; set; }
    }
}
