using CookBook.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    [HttpGet(Name = "UserController")]
    public IActionResult GetUser()
    {
        
        var messages = ResourceExceptionsMessages.EMPTY_USER_NAME;

        return Ok(messages);
    }
};