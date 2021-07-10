using Winster.Entities.Models;
using System.Collections.Generic;

namespace winster.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
