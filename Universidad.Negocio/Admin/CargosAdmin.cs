using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class CargosAdmin : ICargoAdministrador
{
    private readonly CargosDAO _datos = new();

    public Resultado<CargoDTO> Crear(CargoDTO cargo)
    {
        var resultado = new Resultado<CargoDTO>();
        try
        {
            cargo.Id = _datos.Crear(cargo);
            resultado.Entidad = cargo;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Cargo);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar cargo");
        }
        return resultado;
    }

    public List<CargoDTO> Listar()
    {
        return _datos.Listar();
    }
}
