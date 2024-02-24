using CookBook.Api.Filters;
using CookBook.Application.UseCases.User.Register;
using CookBook.Application.UseCases.User.UpdatePassword;
using CookBook.Comunication.Request;
using CookBook.Comunication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers;
public class UserController : CookBookControllerBase
{

    [HttpPost("CreateUser",Name = "UserRegister")]
    [ProducesResponseType(typeof(ResponseUserRegisterJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> GetUser([FromServices] IUserRegisterUseCase _service, [FromBody] RequestUserRegisterJson requestUser)
    {

       var response =  await _service.Execute(requestUser);

       return Created(string.Empty, response);
    }
    
    [HttpPut("updateUserPassword",Name = "UserUpdatePassword")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ServiceFilter(typeof (AuthenticatedUserAttribute))]
    public async Task<IActionResult> PutUpdateUserPassword([FromServices] IUserUpdatePassword _service,
        [FromBody] RequestUserUpdatePasswordJson requestUserUpdatePassword)
    {

       await _service.Execute(requestUserUpdatePassword);

       return NoContent();
    }
};