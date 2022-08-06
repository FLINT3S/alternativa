using System.IO;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class DatabaseConfig
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string ConnectionString { get; set; }


        public DatabaseConfig()
        {
            Host = "85.193.89.172";
            Port = "5432";
            Database = "pgalternativa";
            User = "pgalternativa";
            Password = "kfN2dVD5bhZxvU";
            ConnectionString = $"Host={Host};Port={Port};User Id={User};Password={Password};Database={Database}";
        }
    }
}