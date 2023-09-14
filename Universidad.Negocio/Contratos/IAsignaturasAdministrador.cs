using MySqlX.XDevAPI.Common;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface IAsignaturasAdministrador
{
    public Resultado<AsignaturaDTO> Crear(AsignaturaDTO asignatura);
    public List<AsignaturaDTO> Listar();
}
