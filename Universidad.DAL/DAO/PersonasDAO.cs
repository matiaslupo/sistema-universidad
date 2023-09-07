using MySql.Data.MySqlClient;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Interfaces;

namespace Universidad.DAL.DAO;

public class PersonasDAO : IPersonasRepositorio
{

    public int Crear(ProfesorDTO profesor)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = InsertarDatos(profesor);
                profesor.IdDatos = id;
                cnn.Open();
                const string sql = ConsultaInsertarProfesor;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", profesor.IdDatos);
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

    public int Crear(AlumnoDTO alumno)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = InsertarDatos(alumno);
                alumno.IdDatos = id;
                cnn.Open();
                const string sql = ConsultaInsertarAlumno;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", alumno.IdDatos);
                cmd.Parameters.AddWithValue("@carrera", alumno.Carrera?.Id);
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

    

    public ProfesorDTO? BuscarProfesorPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = ConsultaBuscarProfesor;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@dni", dni);
                var reader = cmd.ExecuteReader();
                ProfesorDTO? profesor = null;
                while (reader.Read())
                {
                    profesor = new ProfesorDTO();
                    profesor.Id = reader.GetInt32(0);
                    profesor.IdDatos = reader.GetInt32(1);
                    profesor.DNI = reader.GetString(2);
                    profesor.Nombre= reader.GetString(3);
                    profesor.Apellido= reader.GetString(4);
                    profesor.Email = reader.GetString(5);
                }
                return profesor;
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

    public AlumnoDTO? BuscarAlumnoPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = ConsultaBuscarAlumno;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@dni", dni);
                var reader = cmd.ExecuteReader();
                AlumnoDTO? alumno = null;
                while (reader.Read())
                {
                    alumno = new AlumnoDTO();
                    alumno.Carrera = new();

                    alumno.Id = reader.GetInt32(0);
                    alumno.IdDatos = reader.GetInt32(1);
                    alumno.DNI = reader.GetString(2);
                    alumno.Nombre = reader.GetString(3);
                    alumno.Apellido = reader.GetString(4);
                    alumno.Email = reader.GetString(5);
                    alumno.Carrera.Id = reader.GetInt32(6);
                    alumno.Carrera.Nombre = reader.GetString(7);
                }
                return alumno;
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

    public void EliminarProfesorPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                ProfesorDTO? profesor = BuscarProfesorPorDNI(dni);
                if (profesor == null)
                    throw new Exception(MensajesEstandar.NoEncontrado(EntidadesString.Profesor));
                EliminarDatos(profesor.IdDatos);
                cnn.Open();
                const string sql = ConsultaEliminarProfesor;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", profesor.Id);
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

    public void EliminarAlumnoPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                AlumnoDTO? alumno = BuscarAlumnoPorDNI(dni);
                if (alumno == null)
                    throw new Exception(MensajesEstandar.NoEncontrado(EntidadesString.Alumno));
                EliminarDatos(alumno.IdDatos);
                cnn.Open();
                const string sql = ConsultaEliminarAlumno;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", alumno.Id);
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

    private int InsertarDatos(IPersona datos)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = 0;
                cnn.Open();
                const string sql = ConsultaInsertarDatos;
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@dni", datos.DNI);
                cmd.Parameters.AddWithValue("@nombre", datos.Nombre);
                cmd.Parameters.AddWithValue("@apellido", datos.Apellido);
                cmd.Parameters.AddWithValue("@email", datos.Email);
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

    private void EliminarDatos(int id)
    {

        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = ConsultaEliminarDatos;
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

    //Consultas SQL

    private const string ConsultaInsertarProfesor = "INSERT INTO profesores (id_datos, sueldoporhora)" +
                    "VALUES (@id, @sueldoporhora)" +
                    "SELECT LAST_INSERT_ID()";

    private const string ConsultaInsertarAlumno = "INSERT INTO alumnos (id_datos, id_carrera)" +
                    "VALUES (@id, @carrera)" +
                    "SELECT LAST_INSERT_ID()";

    private const string ConsultaBuscarProfesor = "SELECT p.id_profesor, d.id_datos, d.dni, d.nombre, d.apellido, d.email, p.sueldoporhora FROM profesores AS p" +
                    "JOIN datos_personales AS d ON p.id_datos=d.id_datos " +
                    "WHERE d.dni=@dni";

    private const string ConsultaBuscarAlumno = "SELECT a.id_alumno, d.id_datos, d.dni, d.nombre, d.apellido, d.email, c.id_carrera, c.nombre FROM alumnos AS a" +
                    "JOIN datos_personales AS d ON a.id_datos=d.id_datos " +
                    "JOIN carreras AS c ON a.id_carrera= c.id_carrera" +
                    "WHERE d.dni=@dni";

    private const string ConsultaEliminarProfesor = "DELETE FROM profesores WHERE id_profesor=@id LIMIT 1";

    private const string ConsultaEliminarAlumno = "DELETE FROM alumnos WHERE id_alumno=@id LIMIT 1";

    private const string ConsultaInsertarDatos = "INSERT INTO datos_personales (dni, nombre, apellido, email)" +
                    "VALUES (@dni, @nombre, @apellido, @email)" +
                    "SELECT LAST_INSERT_ID()";

    private const string ConsultaEliminarDatos = "DELETE FROM datos_personales WHERE id_datos=@id LIMIT 1";


}