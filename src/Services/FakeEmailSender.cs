using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Identity.Services
{
    public class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;
        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }
        public Task SendEmailAsync(string to, string subject, string body)
        {
            _logger.LogInformation("Sending fake email to {To} with subject {Subject}\nBody: {Body}", to, subject, body);
            return Task.CompletedTask;
        }
    }
}
