using Universidad.Entidades.DTO;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface IMateriasAdministrador
{
    public Resultado<MateriaDTO> Crear(MateriaDTO materia);
    public List<MateriaDTO> Listar();
}
