using AspDotNetCoreWebApi.API.DTO;
using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.API.Controllers
{
    [Route("[controller]")] // [Route("[controller]/[action]")] yazarsak action metot ismi olur category/GetAll
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsByIdAsync(int id)
        {
            var category = await _categoryService.GetWithProductsByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductsDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var updatedCategory = _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetByIdAsync(id).Result; // async ve await olmadan async metodu çağırdık

            _categoryService.Remove(category);

            return NoContent();
        }
    }
}
