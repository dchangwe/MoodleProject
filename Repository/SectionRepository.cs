using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;
using Contracts;
using System.Linq;

namespace Repository
{
    public class SectionRepository : RepositoryBase<Section>,ISectionRepository
    {
        public SectionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        //public IEnumerable<Section> GetAllSections(bool trackChanges) => 
        //    FindAll(trackChanges).OrderBy(c => c.Id)
        //    .ToList();
        public IEnumerable<Section> GetSections(Guid courseId, bool trackChanges) => 
            FindByCondition(s => s.CourseId.Equals(courseId),trackChanges)
            .OrderBy(s => s.Id);
        public Section GetSection(Guid courseId, Guid id, bool trackChanges) => 
            FindByCondition(s => s.CourseId.Equals(courseId) && s.Id.Equals(id), trackChanges) 
            .SingleOrDefault();
    }
}
