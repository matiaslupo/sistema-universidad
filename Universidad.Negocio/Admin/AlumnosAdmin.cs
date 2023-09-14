using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Interfaces;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class AlumnosAdmin : IPersonaAdministrador<AlumnoDTO>
{
    private readonly PersonasDAO _datos = new();

    public Resultado<AlumnoDTO> Agregar(AlumnoDTO alumno)
    {
        var resultado = new Resultado<AlumnoDTO>();
        try
        {
            alumno.Id = _datos.Crear(alumno);
            resultado.Entidad = alumno;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Alumno);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar alumno");
        }
        return resultado;
    }

    public Resultado<AlumnoDTO> BuscarPorDNI(string dni)
    {
        var resultado = new Resultado<AlumnoDTO>();
        try
        {
            resultado.Entidad = _datos.BuscarAlumnoPorDNI(dni);
            if (resultado.Entidad != null)
            {
                resultado.Operacion = ResultadoOperacionEnum.Encontrado;
                resultado.Mensaje = MensajesEstandar.Exito();
            }
            else
            {
                resultado.Operacion = ResultadoOperacionEnum.NoExiste;
                resultado.Mensaje = MensajesEstandar.NoEncontrado(EntidadesString.Profesor);
            }
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "buscar alumno");
        }
        return resultado;
    }

    public Resultado<IDTO> EliminarPorDNI(string dni)
    {
        var resultado = new Resultado<IDTO>();
        try
        {
            _datos.EliminarAlumnoPorDNI(dni);
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.Exito();
        }
        catch (Exception ex)
        {
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "eliminar alumno");
        }
        return resultado;
    }
}
