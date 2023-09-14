using Universidad.Entidades.DTO;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface ICargoAdministrador
{
    public Resultado<CargoDTO> Crear(CargoDTO cargo);
    public List<CargoDTO> Listar();
}
