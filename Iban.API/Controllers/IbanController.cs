using Microsoft.AspNetCore.Mvc;

namespace Iban.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IbanController : ControllerBase
    {
       
        [HttpGet]
        public bool Get(string iban, [FromServices] Tests.IbanValidator validator) =>
            validator.Validate(iban);
    }
}