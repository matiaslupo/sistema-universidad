using Universidad.Entidades.DTO;

namespace Universidad.Entidades.Interfaces;

public interface IPersona
{
    public int Id { get; set; }
    public DatosPersonalesDTO Datos { get; set; }
}
