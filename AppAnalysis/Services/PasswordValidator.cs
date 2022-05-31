using System.Text.RegularExpressions;
using AppAnalysis.Models;
using Microsoft.AspNetCore.Identity;

namespace AppAnalysis.Services;

public class PasswordValidator : IPasswordValidator<User>
{
    public int RequiredLength { get; set; } = 6;

    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
    {
        List<IdentityError> errors = new List<IdentityError>();
 
        if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
        {
            errors.Add(new IdentityError
            {
                Description = $"Пароль должен содержать как минимум {RequiredLength} символов"
            });
        }
        
        if (!password.Any(c => char.IsDigit(c)))
        {
            errors.Add(new IdentityError
            {
                Description = "Пароль должен содержать хотя бы одну цифру"
            });
        }
        
        if (!password.Any(c => char.IsLetter(c)))
        {
            errors.Add(new IdentityError
            {
                Description = "Пароль должен содержать хотя бы одну букву"
            });
        }
        return Task.FromResult(errors.Count == 0 ?
            IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
    }
}