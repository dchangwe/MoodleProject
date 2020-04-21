using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Section
    {
        [Column("SectionId")]
        public Guid Id { get; set; }


        public string StartDate { get; set; }

        public string EndDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        

        [ForeignKey(nameof(Course))]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
    }
}
