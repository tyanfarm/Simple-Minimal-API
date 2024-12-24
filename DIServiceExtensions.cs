using Gatto.ORM.DataAccess;

namespace MSC_55
{
    public static class DIServiceExtensions
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services)
        {
            DbContextFactory.Instance.AddConnectionInfo(CreateConnection());

            return services;
        }

        static Gatto.ORM.DataAccess.ConnectionInfo CreateConnection()
        {
            var connectionInfo = new Gatto.ORM.DataAccess.ConnectionInfo();
            connectionInfo.ConnectionString = "server=localhost;username=postgres;password=Quangtuyen@2706;database=snapboto;port=5432;";
            //connectionInfo.ApplicationName = "tyan";
            connectionInfo.Name = "local";
            connectionInfo.Driver = "postgresql";
            //connectionInfo.Server = "127.0.0.1";
            //connectionInfo.Username = "postgres";
            //connectionInfo.Password = "Quangtuyen@2706";
            //connectionInfo.Database = "snapboto";
            //connectionInfo.Port = 5432;

            return connectionInfo;
        }
    }
}
