using AspDotNetCoreWebApi.API.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AspDotNetCoreWebApi.API.Extension
{
    public static class UseCustomExceptionHandler //extension entityframework de olan metodların üzerine başka bir metot eklemektir o yüzden class static ve metod static olmalıdır
    {
        public static void UseCustomException(this IApplicationBuilder app) // bu extension metodu IApplicationBuilder üzerine yazılmıştır
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context => // async yi aşağıdaki WriteAsync async olduğu için koyduk
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var exception = error.Error;

                        ErrorDto errorDto = new ErrorDto();

                        errorDto.Status = 500;
                        errorDto.Errors.Add(exception.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
        }
    }
}
