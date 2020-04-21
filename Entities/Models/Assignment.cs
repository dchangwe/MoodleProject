using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Assignment
    {
        [Column("AssignmentId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Assignment name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string AssignmentName { get; set; }



        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Position is 100 characters.")]
        public string Description { get; set; }
        public ICollection<Submission> Submissions { get; set; }

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
