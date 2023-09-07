using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.DTO;

public class CarreraDTO : IDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
