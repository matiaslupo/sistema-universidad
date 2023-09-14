using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class CarrerasAdmin : ICarrerasAdministrador
{
    private readonly CarrerasDAO _datos = new();

    public Resultado<CarreraDTO> Crear(CarreraDTO carrera)
    {
        var resultado = new Resultado<CarreraDTO>();
        try
        {
            carrera.Id = _datos.Crear(carrera);
            resultado.Entidad = carrera;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Carrera);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar carrera");
        }
        return resultado;
    }

    public List<CarreraDTO> Listar()
    {
        return _datos.Listar();
    }
}
