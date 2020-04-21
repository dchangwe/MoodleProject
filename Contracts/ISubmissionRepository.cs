using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
  public  interface ISubmissionRepository
    {
        IEnumerable<Submission> GetAllSubmissions(bool trackChanges);
    }
}
