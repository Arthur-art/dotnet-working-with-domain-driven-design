using CookBook.Application.UseCases.User.Register;
using CookBook.Comunication.Request;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpGet(Name = "UserController")]
    public async Task<IActionResult> GetUser([FromServices] IUserRegisterUseCase _service)
    {

        await _service.Execute(new RequestUserRegisterJson
        {
            Email = "arthur@gmail.com",
            Name= "Arthur",   
            Password="123456",
            PhoneNumber = "31 9 8953-7539"
        });

        return Ok();
    }
};