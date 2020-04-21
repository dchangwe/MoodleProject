using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
   public interface ISectionRepository
    {
        IEnumerable<Section> GetSections( Guid courseId, bool trackChanges);
        Section GetSection(Guid courseId, Guid id, bool trackChanges);
    }
}
