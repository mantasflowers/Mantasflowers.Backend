namespace Mantasflowers.WebApi.Setup.Database
{
    public class SqlConfiguration
    {
        private readonly string _connectionString;

        private readonly Secret _secrets;

        public DatabaseConfiguration DatabaseConfiguration {get; private set; }

        public SqlConfiguration(string connectionString, DatabaseConfiguration databaseConfiguration, Secret secrets)
        {
            _connectionString = connectionString;
            DatabaseConfiguration = databaseConfiguration;
            _secrets = secrets;
        }

        public string ConnectionString
            => string.Format(_connectionString, DatabaseConfiguration.DataSource, DatabaseConfiguration.Name, 
                            DatabaseConfiguration.WindowsAuthentication, _secrets.Username, _secrets.Password);
    }   
}