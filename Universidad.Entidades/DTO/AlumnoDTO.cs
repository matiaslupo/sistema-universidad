using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.DTO;

public class AlumnoDTO : IPersona
{
    public int Id { get; set; }
    public DatosPersonalesDTO Datos { get; set; }
}
