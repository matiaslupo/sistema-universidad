using Universidad.Entidades.DTO;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface ICarrerasAdministrador
{
    public Resultado<CarreraDTO> Crear(CarreraDTO carrera);
    public List<CarreraDTO> Listar();
}
