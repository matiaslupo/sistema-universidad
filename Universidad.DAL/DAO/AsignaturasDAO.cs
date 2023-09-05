using MySql.Data.MySqlClient;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

public class AsignaturasDAO : ICRUD<AsignaturaDTO>
{
    public int Crear(AsignaturaDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = ConsultaInsertarAsignatura;
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
            catch (MySqlException)
            { throw; }
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
                const string sql = ;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                AsignaturaDTO datos = new AsignaturaDTO();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Horas = reader.GetInt32(1);
                    datos.Profesor = new ProfesorDTO() { Id = reader.GetInt32(2) };
                    datos.Materia = new MateriaDTO() { Id = reader.GetInt32(3) };
                    datos.Cargo = new CargoDTO() { Id = reader.GetInt32(4) };
                }
                return datos;
            }
            catch (MySqlException)
            { throw; }
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
                const string sql = ConsultaEliminarAsignatura;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
            }
            catch (MySqlException)
            { throw; }
            catch (Exception)
            { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    public List<AsignaturaDTO> Listar()
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                List<AsignaturaDTO> lista = new();
                const string sql = ConsultaListarAsignaturas;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                AsignaturaDTO datos = new AsignaturaDTO();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Horas = reader.GetInt32(1);
                    datos.Profesor = new ProfesorDTO() { Id = reader.GetInt32(2) };
                    datos.Materia = new MateriaDTO() { Id = reader.GetInt32(3) };
                    datos.Cargo = new CargoDTO() { Id = reader.GetInt32(4) };
                    lista.Add(datos);
                }
                return lista;
            }
            catch (MySqlException)
            { throw; }
            catch (Exception)
            { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    private const string ConsultaInsertarAsignatura = "INSERT INTO asignaturas (horas, id_profesor, id_cargo, id_materia)" +
                    "VALUES (@horas, @id_profesor, @id_cargo, @id_materia)" +
                    "SELECT LAST_INSERT_ID()";

    private const string ConsultaBuscarPorId = "SELECT id_asignatura, horas, id_profesor, id_materia, id_cargo " +
                    "FROM asignaturas WHERE id_asignatura=@id LIMIT 1";

    private const string ConsultaEliminarAsignatura = "DELETE FROM asignaturas WHERE id_asignatura=@id LIMIT 1";

    private const string ConsultaListarAsignaturas = "SELECT id_asignatura, horas, id_profesor, id_materia, id_cargo FROM asignaturas ";
}
