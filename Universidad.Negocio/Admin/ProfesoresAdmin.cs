using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Interfaces;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class ProfesoresAdmin : IProfesoresAdministrador
{
    private readonly PersonasDAO _datos = new();

    public Resultado<ProfesorDTO> AgregarProfesor(ProfesorDTO profesor)
    {
        var resultado = new Resultado<ProfesorDTO>();
        try
        {
            profesor.Id = _datos.Crear(profesor);
            resultado.Entidad = profesor;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Profesor);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar profesor");
        }
        return resultado;
    }

    public Resultado<ProfesorDTO> BuscarProfesorPorDNI(string dni)
    {
        var resultado = new Resultado<ProfesorDTO>();
        try
        {
            resultado.Entidad = _datos.BuscarProfesorPorDNI(dni);
            if (resultado.Entidad != null)
            {
                resultado.Operacion = ResultadoOperacionEnum.Encontrado;
                resultado.Mensaje = MensajesEstandar.Exito();
            } else
            {
                resultado.Operacion= ResultadoOperacionEnum.NoExiste;
                resultado.Mensaje = MensajesEstandar.NoEncontrado(EntidadesString.Profesor);
            }
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "buscar profesor");
        }
        return resultado;
    }

    public Resultado<IDTO> EliminarProfesorPorDNI(string dni)
    {
        var resultado = new Resultado<IDTO>();
        try
        {
            _datos.EliminarProfesorPorDNI(dni);
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.Exito();
        }
        catch (Exception ex)
        {
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "eliminar profesor");
        }
        return resultado;
    }
}
