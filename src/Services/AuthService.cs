using Identity.Models;
using Identity.Helper;
using Identity.DTO;
using Microsoft.EntityFrameworkCore;


namespace Identity.Services
{
    public class AuthService  : IAuthService
    {
        private readonly MasterContext _db;
        private readonly IEmailSender _emailSender;

    public AuthService(MasterContext db, IEmailSender emailSender)
    {
        _db = db;
        _emailSender = emailSender;
    }

    public async Task<(bool Success, string? Error)> RegisterAsync(RegisterInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Name) ||
            string.IsNullOrWhiteSpace(input.Email) ||
            string.IsNullOrWhiteSpace(input.Password))
        {
            return (false, "Nhap day du thong tin!");
        }

        var exists = await _db.Users.AnyAsync(x => x.Email == input.Email);
        if (exists)
        {
            return (false, "Email da ton taii!");
        }

        var user = new User
        {
            UserName = input.Name,
            Email = input.Email,
            PasswordHash = PasswordHashService.Hash(input.Password),
            Status = false,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        await SendConfirmationEmailAsync(user);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ConfirmEmailAsync(string email, string rawtoken)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            return (false, "Tai khoan khong ton tai!");
        }

        if (user.Status)
        {
            return (false, "Tai khoan da duoc xac minh!");
        }

        var hashedToken = Tokens.HashToken(rawtoken);
        var emailConfirmToken = await _db.EmailConfirmTokens.FirstOrDefaultAsync(x => x.UserId == user.UserId && x.TokenHash == hashedToken);

        if (emailConfirmToken == null || emailConfirmToken.Used || emailConfirmToken.ExpiresAt < DateTime.UtcNow)
        {
            return (false, "Token da het han!");
        }

        user.Status = true;
        user.UpdateAt = DateTime.UtcNow;
        emailConfirmToken.Used = true;

        await _db.SaveChangesAsync();
        await _emailSender.SendEmailAsync(user.Email, "Chao muung!", "Tai khoan duoc kich hoat");
        return (true, null);
    }

    private async Task SendConfirmationEmailAsync(User user)
    {
        var rawToken = Tokens.GenerateToken();
        var emailConfirmToken = new EmailConfirmToken
        {
            UserId = user.UserId,
            TokenHash = Tokens.HashToken(rawToken),
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddHours(24),
            Used = false
        };

        _db.EmailConfirmTokens.Add(emailConfirmToken);
        await _db.SaveChangesAsync();

        var confirmationLink = $"https://localhost:5101/Register/confirm-email?email={user.Email}&token={rawToken}";
        var emailBody = $"Nhan vao link de xa nhan kich hoat tai khoan: {confirmationLink}";

        await _emailSender.SendEmailAsync(user.Email, "Xac nhan email:", emailBody);
    }
}

}