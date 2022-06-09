using Application;
using Application.Commands.Books;
using Application.Dto.Book;
using Application.Helper;
using Application.Queries.Books;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookLibraryContext _context;
        private IMapper _mapper;
        private UseCaseExecutor _useCaseExecutor;

        public BookController(BookLibraryContext context, IMapper mapper, UseCaseExecutor useCaseExecutor)
        {
            _mapper = mapper;
            _context = context;
            _useCaseExecutor = useCaseExecutor;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get([FromQuery] BookSearch search, [FromServices] IGetBooksQuery query)
        {
            IEnumerable<BookResultDto> books = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBookQuery query)
        {
            BookResultDto book = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromForm] AddBookDto dto,
            [FromServices] IAddBookCommand command,
            [FromServices] AddBookValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Book book = _mapper.Map<Book>(dto);

                if (dto.ContentFile != null)
                    book.ContentFileSource = FileHelper.UploadFile(dto.ContentFile);

                if (dto.CoverImage != null)
                    book.CoverImageSource = FileHelper.UploadFile(dto.CoverImage);

                _useCaseExecutor.ExecuteCommand(command, book);
                return Ok("Book created successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] ChangeBookDto dto,
            [FromServices] IChangeBookCommand changeBookCommand,
            [FromServices] IGetOneBookQuery getOneBookQuery,
            [FromServices] ChangeBookValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Book book = _mapper.Map<Book>(dto);

                if (dto.ContentFile != null)
                {
                    FileHelper.RemoveFile(_useCaseExecutor.ExecuteQuery(getOneBookQuery, id).ContentFileSource);
                    book.ContentFileSource = FileHelper.UploadFile(dto.ContentFile);
                }
                else
                    book.ContentFileSource = dto.ContentFileSource;

                if (dto.CoverImage != null)
                {
                    FileHelper.RemoveFile(_useCaseExecutor.ExecuteQuery(getOneBookQuery, id).CoverImageSource);
                    book.CoverImageSource = FileHelper.UploadFile(dto.CoverImage);
                }
                else
                    book.CoverImageSource = dto.CoverImageSource;

                _useCaseExecutor.ExecuteCommand(changeBookCommand, book);
                return Ok("Book changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveBookCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok($"Book with id = {id} deleted successfully");
        }
    }
}
