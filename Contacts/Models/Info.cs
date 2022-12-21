using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class Info
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your Name.")]
        //[Range(5,20)]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide Phone No.")]
        [Phone]
        [StringLength(9)]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Enter valid Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        [StringLength(50)]
        public string Email { get; set; }

        
    }
}
