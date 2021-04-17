using System.Collections.Generic;

namespace AspDotNetCoreWebApi.API.DTO
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
