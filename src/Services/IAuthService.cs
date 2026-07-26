using Identity.DTO;

namespace Identity.Services
{
    public interface IAuthService 
    {
        Task<(bool Success, string? Error)> RegisterAsync(RegisterInput input);
        Task<(bool Success, string? Error)> ConfirmEmailAsync(string email, string rawtoken);
    }
}
