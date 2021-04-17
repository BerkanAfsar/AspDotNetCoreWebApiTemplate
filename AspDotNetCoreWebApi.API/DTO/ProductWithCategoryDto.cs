namespace AspDotNetCoreWebApi.API.DTO
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
