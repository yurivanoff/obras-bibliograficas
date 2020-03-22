using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Utils;
using Domain.Models;
using Persistance.Repository.Interaces;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> CreateAuthors(IEnumerable<Author> authors)
        {
            foreach (var author in authors)
            {
                author.Name = author.Name.Trim();
                await _authorRepository.CreateAuthor(author);
            }

            return authors;
        }

        public async Task<IEnumerable<Author>> GetFormattedAuthors()
        {
            IEnumerable<Author> formattedAuthors = await _authorRepository.GetAuthors();

            foreach(var author in formattedAuthors)
            {
                author.Name = AuthorNameFormatter.FormatNames(author.Name);
            }

            return formattedAuthors;
        }

        public async Task<IEnumerable<Author>> GetUnformattedAuthors()
        {
            IEnumerable<Author> authors = await _authorRepository.GetAuthors();
            return authors;
        }

        public async Task<Author> DeleteAuthor(int id) => await _authorRepository.DeleteAuthor(id);

    }
}