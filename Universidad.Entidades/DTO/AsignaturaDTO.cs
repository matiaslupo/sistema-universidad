namespace Universidad.Entidades.DTO;

public class AsignaturaDTO
{
    public int Id { get; set; }
    public int Horas { get; set; }
    public ProfesorDTO Profesor { get; set; }
    public CargoDTO Cargo { get; set; }
    public MateriaDTO Materia { get; set; }
}
