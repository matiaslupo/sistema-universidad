using MySql.Data.MySqlClient;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

internal class CargosDAO : ICRUD<CargoDTO>
{
    public int Crear(CargoDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = ConsultaInsertarCargo;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@descripcion", datos.Descripcion);
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

    public CargoDTO ObtenerPorId(int id)
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
                CargoDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Descripcion = reader.GetString(1);
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

    public void EliminarPorId(int id)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = ConsultaEliminarCargo;
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

    public List<CargoDTO> Listar()
    {
        using(var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                List<CargoDTO> lista = new();
                const string sql = ConsultaListarCargos;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                CargoDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Descripcion = reader.GetString(1);
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

    private const string ConsultaInsertarCargo = "INSERT INTO cargos (descripcion)" +
                    "VALUES (@descripcion)" +
                    "SELECT LAST_INSERT_ID()";

    private const string ConsultaBuscarPorId = "SELECT id_cargo, descripcion " +
                    "FROM cargos WHERE id_cargo=@id LIMIT 1";

    private const string ConsultaEliminarCargo = "DELETE FROM cargos WHERE id_cargo=@id LIMIT 1";

    private const string ConsultaListarCargos = "SELECT id_cargo, descripcion FROM cargos";
}
