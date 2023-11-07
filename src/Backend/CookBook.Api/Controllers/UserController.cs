using CookBook.Application.UseCases.User.Register;
using CookBook.Comunication.Request;
using CookBook.Comunication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpPost(Name = "UserRegister")]
    [ProducesResponseType(typeof(ResponseUserRegisterJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetUser([FromServices] IUserRegisterUseCase _service, [FromBody] RequestUserRegisterJson requestUser)
    {

       var response =  await _service.Execute(requestUser);

       return Created(string.Empty, response);
    }
};