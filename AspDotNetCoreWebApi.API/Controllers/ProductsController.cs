using AspDotNetCoreWebApi.API.DTO;
using AspDotNetCoreWebApi.API.Filter;
using AspDotNetCoreWebApi.Core.Entity;
using AspDotNetCoreWebApi.Core.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryByIdAsync(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        //[ValidationFilter] -> startup dosyasına aldık ve tüm controllera eklenmiş oldu.
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result; // async ve await olmadan async metodu çağırdık

            _productService.Remove(product);

            return NoContent();
        }
    }
}
