using Application;
using Application.Commands.Categories;
using Application.Dto.Category;
using Application.Queries.Categories;
using Application.Searches;
using AutoMapper;
using Domain;
using Implementation.ResponseMessages;
using Implementation.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private UseCaseExecutor _useCaseExecutor;
        private IMapper _mapper;

        public CategoryController(UseCaseExecutor useCaseExecutor, IMapper mapper)
        {
            _useCaseExecutor = useCaseExecutor;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCategoryQuery query)
        {
            CategoryResultDto result = _useCaseExecutor.ExecuteQuery(query, id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get([FromBody] CategorySearch search,
              [FromServices] IGetCategoriesQuery query)
        {
            IEnumerable<CategoryResultDto> result = _useCaseExecutor.ExecuteQuery(query, search);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryDto dto
            , [FromServices] IAddCategoryCommand command
            , [FromServices] AddCategoryValidator validator)
        {
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Category category = _mapper.Map<Category>(dto);
                _useCaseExecutor.ExecuteCommand(command, category);
                return Ok("Category added successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ChangeCategoryDto dto
            , [FromServices] IChangeCategoryCommand command
            , [FromServices] ChangeCategoryValidator validator)
        {
            dto.Id = id;
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                Category category = _mapper.Map<Category>(dto);
                _useCaseExecutor.ExecuteCommand(command, category);
                return Ok("Category changed successfully");
            }

            return UnprocessableEntity(UnprocessableEntityResponse.Message(result.Errors));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IRemoveCategoryCommand command)
        {
            _useCaseExecutor.ExecuteCommand(command, id);
            return Ok("Category removed successfully.");
        }
    }
}
