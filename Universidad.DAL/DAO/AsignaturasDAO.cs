using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

public class AsignaturasDAO : CRUD<AsignaturaDTO>
{
    public int Crear(AsignaturaDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = "INSERT INTO asignaturas (horas, id_profesor, id_cargo, id_materia)" +
                    "VALUES (@horas, @id_profesor, @id_cargo, @id_materia)" +
                    "SELECT LAST_INSERT_ID()";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@horas", datos.Horas);
                cmd.Parameters.AddWithValue("@id_profesor", datos.Profesor.Id);
                cmd.Parameters.AddWithValue("@id_cargo", datos.Cargo.Id);
                cmd.Parameters.AddWithValue("@id_materia", datos.Materia.Id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
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

    public AsignaturaDTO ObtenerPorId(int id)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = "SELECT id_asignatura, horas, id_profesor, id_materia, id_cargo " +
                    "FROM asignaturas WHERE id_asignatura=@id LIMIT 1";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                AsignaturaDTO datos = new AsignaturaDTO();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Horas = reader.GetString(1);
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
        throw new NotImplementedException();
    }

}
