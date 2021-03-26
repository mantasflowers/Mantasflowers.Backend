namespace Mantasflowers.WebApi.Setup.Database
{
    public class DatabaseConfiguration
    {
        public string Name { get; set; }

        public string DataSource { get; set; }

        public bool WindowsAuthentication { get; set; }

        public bool IsInMemory { get; set; }
    }   
}