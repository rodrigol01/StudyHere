namespace StudyHere.Domain.Models;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public Guid? RoleId { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? TokenExpires { get; set; }
}