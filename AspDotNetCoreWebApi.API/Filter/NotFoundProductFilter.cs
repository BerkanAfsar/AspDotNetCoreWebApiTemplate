using AspDotNetCoreWebApi.API.DTO;
using AspDotNetCoreWebApi.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreWebApi.API.Filter
{
    public class NotFoundProductFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundProductFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault(); // Values contollerdaki parametrenin değeri dir. keys dersek onun adıdır örneğin id gibi

            var product = await _productService.GetByIdAsync(id);

            if(product != null)
            {
                await next(); // request in devam etmesini sağlıyor
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;

                errorDto.Errors.Add($"id si {id} olan ürün veritabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
