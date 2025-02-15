namespace Services.Interface;

public interface IAuthService
{ Task<bool> Login(string email, string password);
}