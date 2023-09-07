using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.DTO;

public class InscripcionDTO : IDTO
{
    public int Id { get; set; }
    public MateriaDTO? Materia { get; set; }
    public AlumnoDTO? Alumno { get; set; }
}
