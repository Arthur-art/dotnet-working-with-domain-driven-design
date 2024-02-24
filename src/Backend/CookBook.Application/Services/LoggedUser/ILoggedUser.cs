using CookBook.Domain.Entities;

namespace CookBook.Application.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> RecoverUser();
}
