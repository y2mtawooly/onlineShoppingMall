using System.Configuration;
using System.Data.SqlClient;

namespace OnlineShoppingMall.Adapters.Core
{
    public class OnlineShoppingMallAdapter
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["tawoolyConnectionString"].ConnectionString;

        public SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionString);
                }
                return _connection;
            }
        }

        
    }
}