using MySql.Data.MySqlClient;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

public class MateriasDAO : IRepositorio<MateriaDTO>
{
    public int Crear(MateriaDTO datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = ConsultaInsertarMateria;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@nombre", datos.Nombre);
                cmd.Parameters.AddWithValue("@id_carrera", datos.Carrera.Id);
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
                const string sql = ConsultaEliminarMateria;
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

    public List<MateriaDTO> Listar()
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                List<MateriaDTO> lista = new();
                const string sql = ConsultaListarMaterias;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                MateriaDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Nombre = reader.GetString(1);
                    datos.Carrera = new CarreraDTO() { 
                        Id = reader.GetInt32(2) ,
                        Nombre = reader.GetString(3) ,
                    };
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

    public MateriaDTO ObtenerPorId(int id)
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
                MateriaDTO datos = new();
                while (reader.Read())
                {
                    datos.Id = reader.GetInt32(0);
                    datos.Nombre = reader.GetString(1);
                    datos.Carrera = new CarreraDTO
                    {
                        Id = reader.GetInt32(2),
                        Nombre = reader.GetString(3),
                    };
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

    private const string ConsultaInsertarMateria = @"INSERT INTO materias (nombre, id_carrera)
                                                       VALUES(@nombre, @id_carrera)";

    private const string ConsultaEliminarMateria = "DELETE FROM materias WHERE id_materia=@id";

    private const string ConsultaListarMaterias = @"SELECT m.id_materia, m.nombre, m.id_carrera, c.nombre FROM materias AS m
                                                    JOIN carreras AS c
                                                    ON m.id_carrera=c.id_carrera";

    private const string ConsultaBuscarPorId= @"SELECT m.id_materia, m.nombre, m.id_carrera, c.nombre FROM materias AS m
                                                    JOIN carreras AS c
                                                    ON m.id_carrera=c.id_carrera
                                                    WHERE id_materia= @id";
}
