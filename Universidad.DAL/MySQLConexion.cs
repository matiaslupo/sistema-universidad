using MySql.Data.MySqlClient;

namespace Universidad.DAL;

public static class MySQLConexion
{
    private static string _connectionString= "server=localhost;database=universidad;user=root;password=;"; 

    public static MySqlConnection Con()
    {
        return new MySqlConnection(_connectionString);
    }
}
