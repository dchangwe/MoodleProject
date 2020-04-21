using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
  public  interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> GetAllEnrollments(bool trackChanges);

        IEnumerable<Enrollment> GetEnrollments(Guid userId, Guid sectionId, bool trackChanges);
        Enrollment GetEnrollment(Guid userId, Guid id, Guid sectionId, bool trackChanges);
    }
}
