using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;


namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;
        private IAutoMapperConfig _autoMapper;

        public AuthorsController(ILibraryRepository libraryRepository, IAutoMapperConfig autoMapper)
        {
            _libraryRepository = libraryRepository;
            _autoMapper = autoMapper;
        }

        public IMapper Mapper { get {
                return _autoMapper.Mapper;
        } }
        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _libraryRepository.GetAuthors();

            var authors = Mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);

           return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            
            var authorFromRepo = _libraryRepository.GetAuthor(id);

            if(authorFromRepo == null)
            {
                return NotFound();
            }
            var author = Mapper.Map<AuthorDto>(authorFromRepo);

            return Ok(author);
        }
    }
}
