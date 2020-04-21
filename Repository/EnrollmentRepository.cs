using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;
using Contracts;
using System.Linq;

namespace Repository
{
    public class EnrollmentRepository : RepositoryBase<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Enrollment> GetAllEnrollments(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(e => e.Id)
            .ToList();
        public IEnumerable<Enrollment> GetEnrollments(Guid userId, Guid sectionId, bool trackChanges) =>
            FindByCondition(e => e.UserId.Equals(userId) && e.SectionId.Equals(sectionId), trackChanges)
            .OrderBy(e => e.Id);
        public Enrollment GetEnrollment(Guid userId, Guid id, Guid sectionId, bool trackChanges) =>
            FindByCondition(e => e.User.Equals(userId) && e.Id.Equals(id) && e.Section.Equals(sectionId), trackChanges)
            .SingleOrDefault();
    }
}
