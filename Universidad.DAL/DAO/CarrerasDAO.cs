using MySql.Data.MySqlClient;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

internal class CarrerasDAO : IRepositorio<CarreraDTO>
{
    public int Crear(CarreraDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = ConsultaInsertarCarrera;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nombre", datos.Nombre);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                return id;
            }
            catch (MySqlException) { throw; }
            catch (Exception) { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    public void EliminarPorId(int id)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = ConsultaEliminarCarrera;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
            }
            catch (MySqlException) { throw; }
            catch (Exception) { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    public List<CarreraDTO> Listar()
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                List<CarreraDTO> lista = new();
                const string sql = ConsultaListarCarreras;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                CarreraDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Nombre = reader.GetString(1);
                    lista.Add(datos);
                }
                return lista;
            }
            catch (MySqlException) { throw; }
            catch (Exception) { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    public CarreraDTO ObtenerPorId(int id)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = ConsultaBuscarPorId;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                CarreraDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Nombre = reader.GetString(1);
                }
                return datos;
            }
            catch (MySqlException) { throw; }
            catch (Exception) { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    private const string ConsultaInsertarCarrera = @"INSERT INTO carreras (nombre)
                                                       VALUES(@nombre)";

    private const string ConsultaEliminarCarrera = @"DELETE FROM carreras WHERE id_carrera=@id";

    private const string ConsultaBuscarPorId = @"SELECT id_carrera, nombre FROM carreras
                                                    WHERE id_carrera= @id";

    private const string ConsultaListarCarreras = "SELECT id_carrera, nombre FROM carreras";
}
