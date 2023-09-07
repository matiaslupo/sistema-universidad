using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.DTO;

public class MateriaDTO : IDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public CarreraDTO? Carrera { get; set; }
}
