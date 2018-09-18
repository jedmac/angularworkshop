using EmailServer.Database.Enums;

namespace EmailServer.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public EmailType Type { get; set; }
    }
}
