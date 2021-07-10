using winster.Contracts;
using Winster.Entities;
using Winster.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using Repository;

namespace Winster.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToList();
    }
}
