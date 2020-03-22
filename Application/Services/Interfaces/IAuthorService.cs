using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAuthorService
    {
         Task<IEnumerable<Author>> GetFormattedAuthors();
         Task<IEnumerable<Author>> GetUnformattedAuthors();
         Task<IEnumerable<Author>> CreateAuthors(IEnumerable<Author> author);
         Task<Author> DeleteAuthor(int id);
    }
}