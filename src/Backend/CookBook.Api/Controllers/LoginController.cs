using CookBook.Application.UseCases.Login.DoLogin;
using CookBook.Comunication.Request;
using CookBook.Comunication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    public class LoginController : CookBookControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseLoginRequestJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromServices] ILoginUseCase _loginUseCase,[FromBody] LoginRequestJson request)
        {
            var response = await _loginUseCase.Execute(request);

            return Ok(response);
        }
    }
}
