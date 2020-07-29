using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public LocalMailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public void Send(string subject, string message)
        {
            var mailFrom = _configuration["mailSettings:mailFromAddress"];
            var mailTo = _configuration["mailSettings:mailToAddress"];
            Debug.WriteLine($"Mail from {mailFrom} to {mailTo}, with LocalMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
