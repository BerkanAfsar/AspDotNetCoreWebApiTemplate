using System.ComponentModel.DataAnnotations;

namespace AspDotNetCoreWebApi.API.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
