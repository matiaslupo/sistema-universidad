using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.DTO;

public class ProfesorDTO : IPersona
{
    public int Id { get; set; }
    public DatosPersonalesDTO Datos { get; set; }
    public decimal SueldoPorHora { get; set; }
}
