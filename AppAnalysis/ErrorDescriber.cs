using Microsoft.AspNetCore.Identity;

namespace AppAnalysis;

public class ErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError PasswordMismatch()
    {
        return new()
        {
            Description = "Пароли не совпадают"
        };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new()
        {
            // В приложении почта используется как username
            Description = $"Почта {userName} уже занята"
        };
    }
}