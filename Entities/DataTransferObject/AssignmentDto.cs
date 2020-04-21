using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObject
{
   public class AssignmentDto
    {
        public Guid Id { get; set; }
        public string AssignmentName { get; set; }
        public string Description { get; set; }
    }
}
