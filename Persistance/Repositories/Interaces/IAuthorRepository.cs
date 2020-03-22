using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistance.Repository.Interaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthors();
        Task<Author> CreateAuthor(Author author);
        Task<Author> DeleteAuthor(int id);
        
    }
}