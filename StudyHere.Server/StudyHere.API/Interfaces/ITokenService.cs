using StudyHere.API.Auth;
using StudyHere.Domain.Models;

namespace StudyHere.API.Interfaces;

public interface ITokenService
{
    Task<string> GenerateToken(User user);
    Task<bool> ValidateToken(string token);
}