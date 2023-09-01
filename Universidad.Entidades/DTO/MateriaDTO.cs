namespace Universidad.Entidades.DTO;

public class MateriaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Horas { get; set; }
    public CarreraDTO Carrera { get; set; }
    public ProfesorDTO Profesor { get; set; }
}
