using Universidad.Entidades.DTO;

namespace Universidad.DAL.DAO;

public class PersonasDAO
{
    private readonly DatosPersonalesDAO _datosDAO = new DatosPersonalesDAO();

    public int Crear(ProfesorDTO profesor)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = _datosDAO.Crear(profesor.Datos);
                profesor.Datos.IdDatos = id;
                cnn.Open();
                const string sql = "INSERT INTO profesores (id_datos)" +
                    "VALUES (@id)" +
                    "SELECT LAST_INSERT_ID()";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", profesor.Datos.IdDatos);
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

    public int Crear(AlumnoDTO alumno)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                int id = _datosDAO.Crear(alumno.Datos);
                alumno.Datos.IdDatos = id;
                cnn.Open();
                const string sql = "INSERT INTO alumnos (id_datos)" +
                    "VALUES (@id)" +
                    "SELECT LAST_INSERT_ID()";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", alumno.Datos.IdDatos);
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

    public ProfesorDTO BuscarProfesorPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = "SELECT p.id_profesor, d.id_datos, d.dni, d.nombre, d.apellido, d.email FROM profesores AS p" +
                    "JOIN datos_personales AS d ON p.id_datos=d.id_datos " +
                    "WHERE d.dni=@dni";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@dni", dni);
                var reader = cmd.ExecuteReader();
                ProfesorDTO profesor = new ProfesorDTO();
                profesor.Datos = new DatosPersonalesDTO();
                while (reader.Read())
                {
                    profesor.Id = reader.GetInt32(0);
                    profesor.Datos.IdDatos = reader.GetInt32(1);
                    profesor.Datos.DNI = reader.GetString(2);
                    profesor.Datos.Nombre= reader.GetString(3);
                    profesor.Datos.Apellido= reader.GetString(4);
                    profesor.Datos.Email = reader.GetString(5);
                }
                return profesor;
            }
            catch (Exception)
            { throw; }
            finally
            {
                cnn.Close();
            }
        }
    }

    public AlumnoDTO BuscarAlumnoPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                cnn.Open();
                const string sql = "SELECT a.id_alumno, d.id_datos, d.dni, d.nombre, d.apellido, d.email FROM alumnos AS a" +
                    "JOIN datos_personales AS d ON a.id_datos=d.id_datos " +
                    "WHERE d.dni=@dni";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@dni", dni);
                var reader = cmd.ExecuteReader();
                AlumnoDTO alumno = new AlumnoDTO();
                alumno.Datos = new DatosPersonalesDTO();
                while (reader.Read())
                {
                    alumno.Id = reader.GetInt32(0);
                    alumno.Datos.IdDatos = reader.GetInt32(1);
                    alumno.Datos.DNI = reader.GetString(2);
                    alumno.Datos.Nombre = reader.GetString(3);
                    alumno.Datos.Apellido = reader.GetString(4);
                    alumno.Datos.Email = reader.GetString(5);
                }
                return alumno;
            }
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
                ProfesorDTO profesor = BuscarProfesorPorDNI(dni);
                _datosDAO.EliminarPorId(profesor.Datos.IdDatos);
                cnn.Open();
                const string sql = "DELETE FROM profesores WHERE id_profesor=@id LIMIT 1";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", profesor.Id);
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

    public void EliminarAlumnoPorDNI(string dni)
    {
        using (var cnn = MySQLConexion.Con())
        {
            try
            {
                AlumnoDTO alumno = BuscarAlumnoPorDNI(dni);
                _datosDAO.EliminarPorId(alumno.Datos.IdDatos);
                cnn.Open();
                const string sql = "DELETE FROM alumnos WHERE id_alumno=@id LIMIT 1";
                var cmd = cnn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", alumno.Id);
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