namespace WebApp;

public class EmailSettings
{
    public string Email { get; set; } = null!;
    public string Host { get; set; } = null!;
    public byte Port { get; set; }
    public string Password { get; set; } = null!;
}