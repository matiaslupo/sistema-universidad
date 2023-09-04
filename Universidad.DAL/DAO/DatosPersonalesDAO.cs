using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

internal class DatosPersonalesDAO : CRUD<DatosPersonalesDTO> 
{
    public int Crear(DatosPersonalesDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = "INSERT INTO datos_personales (dni, nombre, apellido, email)" +
                    "VALUES (@dni, @nombre, @apellido, @email)" +
                    "SELECT LAST_INSERT_ID()";
                var cmd= cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@dni", datos.DNI);
                cmd.Parameters.AddWithValue("@nombre", datos.Nombre);
                cmd.Parameters.AddWithValue("@apellido", datos.Apellido);
                cmd.Parameters.AddWithValue("@email", datos.Email);
                var reader= cmd.ExecuteReader();
                while(reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                return id;
            }
            catch (Exception)
            { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    public DatosPersonalesDTO ObtenerPorId(int id)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = "SELECT id_datos, dni, nombre, apellido, email FROM datos_personales WHERE id_datos=@id LIMIT 1";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                DatosPersonalesDTO datos = new DatosPersonalesDTO();
                while (reader.Read())
                {
                    datos.IdDatos = reader.GetInt32(0);
                    datos.DNI = reader.GetString(1);
                    datos.Nombre = reader.GetString(2);
                    datos.Apellido = reader.GetString(3);
                    datos.Email = reader.GetString(4);
                }
                return datos;
            }
            catch (Exception)
            { throw; }
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
                const string sql = "DELETE FROM datos_personales WHERE id_datos=@id LIMIT 1";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
            }
            catch (Exception)
            { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }


}
