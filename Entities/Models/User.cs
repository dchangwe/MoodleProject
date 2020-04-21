using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Entities.Models
{
    public class User
    {
        [Column("UserId")] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is a required field.")] 
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the last name is 60 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Address is 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a required field.")]
        [MaxLength(8, ErrorMessage = "Maximum length for the Password is 8 characters")]
        public string Password { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Submission>Submissions { get; set; }
        
        
    }
}
