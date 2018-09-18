using EmailServer.Database.Enums;

namespace EmailServer.Database.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EmailType Type { get; set; }
    }
}
