using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Submission
    {
        [Column("SubmissionId")] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Score is a required field.")] 
        
        public string  Score { get; set; }
        [Required(ErrorMessage = "submission text is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the submission text is 100 characters.")]
        public string Submission_Comment { get; set; }





        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        [ForeignKey(nameof(Assignment))]
        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        [ForeignKey(nameof(Section))]
        public Guid SectionId { get; set; }
        public Section Section { get; set; }

    }
}


