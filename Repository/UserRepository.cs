using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Contracts;
using Entities;
using System.Linq;

namespace Repository
{
  public  class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public IEnumerable<User> GetAllUsers(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(u => u.FirstName)
            .ToList();
        public User GetUser(Guid userId, bool trackChanges) => 
            FindByCondition(u => u.Id.Equals(userId), trackChanges)
            .SingleOrDefault();
        public void CreateUser(User user) => Create(user);
    }
}
