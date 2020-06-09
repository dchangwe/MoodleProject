using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObject
{
   public class SubmissionDto
    {
        public Guid id { get; set; }
        public string Score { get; set; }
        public string Submission_Comment { get; set; }
        
    }
}
