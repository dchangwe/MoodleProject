using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
  public class Course
    {
        [Column("CourseId")] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Course name is a required field.")] 
        [MaxLength(60, ErrorMessage = "Maximum length for the course name is 60 characters.")] 
         public string CourseName { get; set; }

        [Required(ErrorMessage = "Course decription is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the description is 60 characters")] 
        public string Description { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
