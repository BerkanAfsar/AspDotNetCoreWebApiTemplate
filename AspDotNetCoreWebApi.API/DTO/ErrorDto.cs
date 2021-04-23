using System.Collections.Generic;

namespace AspDotNetCoreWebApi.API.DTO
{
    public class ErrorDto // clienta bir ata döneceksek bu dto yu kullanıcaz
    {

        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }

        public int Status { get; set; }
    }
}
