namespace StudyHere.API.Auth;

public class TokenInfo
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? TokenCreated { get; set; }
    public DateTime? TokenExpires { get; set; }
}