using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistance.Repository.Interaces;

namespace Persistance.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAuthors() =>  await _context.Authors.ToListAsync(); 

        public async Task<Author> CreateAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> DeleteAuthor(int id)
        {   
             var author = _context.Authors.FirstOrDefault(a => a.Id == id);

             if(author != default)
             {
                _context.Remove(author);
                await _context.SaveChangesAsync();
             }

             return author;
        }
    }
}