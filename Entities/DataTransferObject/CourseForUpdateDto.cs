using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObject
{
   public class CourseForUpdateDto
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public IEnumerable<AssignmentForCreationDto> Assignments { get; set; }
    }
}
