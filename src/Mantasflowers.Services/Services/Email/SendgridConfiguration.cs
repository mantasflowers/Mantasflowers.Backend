namespace Mantasflowers.Services.Services.Email
{
    public class SendgridConfiguration
    {
        public string ApiKey { get; set; }

        public bool IsEnabled { get; set; }

        public string OrderUrl { get; set; }

        public string SenderEmail { get; set; }

        public string FromName { get; set; }

        public string EmailTemplatePath { get; set; }
    }
}