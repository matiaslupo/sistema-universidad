using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class AsignaturasAdmin : IAsignaturasAdministrador
{
    private readonly AsignaturasDAO _datos;

    public Resultado<AsignaturaDTO> Crear(AsignaturaDTO asignatura)
    {
        var resultado = new Resultado<AsignaturaDTO>();
        try
        {
            asignatura.Id = _datos.Crear(asignatura);
            resultado.Entidad = asignatura;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Asignatura);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar asignatura");
        }
        return resultado;
    }

    public List<AsignaturaDTO> Listar()
    {
        return _datos.Listar();
    }
}
