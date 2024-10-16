namespace WebApp.Models;

public class UserRegister
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public ObjectId UserTypeId { get; set; }
    public ObjectId UserTypeId { get; set; }
}