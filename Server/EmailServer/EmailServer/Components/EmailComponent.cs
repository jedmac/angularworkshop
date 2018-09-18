using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailServer.Database;
using EmailServer.Database.Entities;
using EmailServer.Database.Enums;
using EmailServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailServer.Components
{
    public class EmailComponent
    {
        private readonly EmailServerContext _context;

        public EmailComponent(EmailServerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmailModel>> GetReceived()
        {
            var emails = await _context.Emails.Where(e => e.Type == EmailType.Received).ToListAsync();

            return emails.Select(MapEmailToEmailModel).ToList();
        }

        public async Task<IEnumerable<EmailModel>> GetSent()
        {
            var emails = await _context.Emails.Where(e => e.Type == EmailType.Sent).ToListAsync();

            return emails.Select(MapEmailToEmailModel).ToList();
        }

        public async Task<EmailModel> Get(int id)
        {
            var email = await _context.Emails.SingleAsync(e => e.Id == id);
            var emailModel = MapEmailToEmailModel(email);

            return emailModel;
        }

        public async Task Send(EmailModel emailModel)
        {
            var email = MapEmailModelToEmail(emailModel);

            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var email = new Email { Id = id };

            _context.Entry(email).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public EmailModel MapEmailToEmailModel(Email email)
        {
            return new EmailModel
            {
                Id = email.Id,
                Subject = email.Subject,
                Body = email.Body,
                Type = email.Type
            };
        }

        public Email MapEmailModelToEmail(EmailModel emailModel)
        {
            return new Email
            {
                Id = emailModel.Id,
                Subject = emailModel.Subject,
                Body = emailModel.Body,
                Type = emailModel.Type
            };
        }
    }
}
