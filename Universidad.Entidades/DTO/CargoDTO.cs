using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.DTO;

public class CargoDTO : IDTO
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;    
    public decimal SueldoPorHora { get; set; }
}
