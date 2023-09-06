using MySql.Data.MySqlClient;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

internal class InscripcionesDAO : IRepositorio<InscripcionDTO>
{
    public int Crear(InscripcionDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = ConsultaInsertarInscripcion;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id_alumno", datos.Alumno.Id);
                cmd.Parameters.AddWithValue("@id_materia", datos.Materia.Id);
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
                const string sql = ConsultaEliminarInscripcion;
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

    public List<InscripcionDTO> Listar()
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                List<InscripcionDTO> lista = new();
                const string sql = ConsultaListarInscripciones;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                InscripcionDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Alumno = new AlumnoDTO { Id = reader.GetInt32(1) };
                    datos.Materia = new MateriaDTO { Id = reader.GetInt32(2) };
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

    public InscripcionDTO ObtenerPorId(int id)
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
                InscripcionDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Alumno = new AlumnoDTO { Id = reader.GetInt32(1) };
                    datos.Materia = new MateriaDTO { Id = reader.GetInt32(2) };
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

    private const string ConsultaInsertarInscripcion = @"INSERT INTO inscripciones (id_alumno, id_materia)
                                                       VALUES(@id_alumno, @id_materia)";

    private const string ConsultaEliminarInscripcion = "DELETE FROM inscripciones WHERE id_inscripcion=@id";

    private const string ConsultaListarInscripciones = @"SELECT i.id_inscripcion, i.id_alumno, i.id_materia
                                                            FROM inscripciones AS i";

    private const string ConsultaBuscarPorId = @"SELECT i.id_inscripcion, i.id_alumno, i.id_materia
                                                            FROM inscripciones AS i
                                                            WHERE i.id_inscripcion=@id";
}
