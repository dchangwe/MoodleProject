using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Contracts;
using Entities.Models;
using System.Linq;

namespace Repository
{
    public class SubmissionRepository : RepositoryBase<Submission>,ISubmissionRepository
    {
        public SubmissionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public IEnumerable<Submission> GetAllSubmissions(bool trackChanges) => 
            FindAll(trackChanges).OrderBy(sb => sb.Id)
            .ToList();
    }
}
