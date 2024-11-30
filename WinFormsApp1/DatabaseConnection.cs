using MySql.Data.MySqlClient;
public interface IDbConnectionService
{
    void OpenConnection();
    void CloseConnection();
    MySqlConnection GetConnection();
}

namespace WinFormsApp1
{
    public class DatabaseConnection: IDbConnectionService
    {
        private readonly string server = "localhost";
        private readonly string uid = "byron";
        private readonly string password = "password";
        private readonly string database = "winformlab";

        private MySqlConnection connection;

        public DatabaseConnection()
        {
            string connectString = $"server={server};uid={uid};pwd={password};database={database}";
            connection = new MySqlConnection(connectString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
