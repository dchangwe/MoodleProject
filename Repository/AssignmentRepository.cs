using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;
using Contracts;
using System.Linq;

namespace Repository
{
    public class AssignmentRepository : RepositoryBase<Assignment>,IAssignmentRepository
    {
        public AssignmentRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public IEnumerable<Assignment> GetAssignments(Guid courseId, bool trackChanges) => 
            FindByCondition(a => a.CourseId.Equals(courseId), trackChanges)
            .OrderBy(a => a.Id);
        public Assignment GetAssignment(Guid courseId, Guid id, bool trackChanges) => 
            FindByCondition(a => a.CourseId.Equals(courseId) && a.Id.Equals(id), trackChanges)
            .SingleOrDefault();
        public void CreateAssignmentForCourse(Guid courseId, Assignment assignment) { 
            assignment.CourseId = courseId; 
            Create(assignment); 
        }
        public void DeleteAssignment(Assignment assignment)
        {
            Delete(assignment);
        }
    }
}
