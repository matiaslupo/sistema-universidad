using Universidad.Entidades.DTO;

namespace Universidad.Entidades.Interfaces;

public interface IPersona
{
    public int IdDatos { get; set; }
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
}
