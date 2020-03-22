using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(IAuthorService service, ILogger<AuthorsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Author>> GetFormattedAuthors() => await _service.GetFormattedAuthors();

        //authors/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Author[] authors)
        {
            if(!authors.Any())
                return BadRequest();

            await _service.CreateAuthors(authors);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAuthor(id);
            return Ok();
        }
    }
}
