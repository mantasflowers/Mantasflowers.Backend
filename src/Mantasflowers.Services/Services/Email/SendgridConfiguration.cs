namespace Mantasflowers.Services.Services.Email
{
    public class SendgridConfiguration
    {
        public string ApiKey { get; set; }

        public string From { get; set; }

        public string FromName { get; set; }
    }
}