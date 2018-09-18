using System.Collections.Generic;
using System.Linq;
using EmailServer.Database.Entities;
using EmailServer.Database.Enums;

namespace EmailServer.Database
{
    public class DbInitializer
    {
        public static void Initialize(EmailServerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Emails.Any())
            {
                return;
            }

            var emails = new List<Email>();

            for (var i = 0; i < 30; i++)
            {
                emails.Add(i % 2 != 0
                    ? new Email {Subject = $"Received Email{i}", Body = $"Email body {i}", Type = EmailType.Received}
                    : new Email {Subject = $"Sent Email{i}", Body = $"Email body {i}", Type = EmailType.Sent});
            }

            context.AddRange(emails);

            context.SaveChanges();
        }
    }
}
