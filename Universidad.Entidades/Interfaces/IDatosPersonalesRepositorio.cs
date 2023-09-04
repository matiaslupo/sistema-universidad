using Universidad.Entidades.DTO;

namespace Universidad.Entidades.Interfaces;

public interface IDatosPersonalesRepositorio
{
    public int Crear(DatosPersonalesDTO datos);
    public DatosPersonalesDTO ObtenerPorId(int id);

    public void EliminarPorId(int id);
}
