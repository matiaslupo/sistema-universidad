using Universidad.Entidades.DTO;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface IInscripcionesAdministrador
{
    public Resultado<InscripcionDTO> Inscribir(AlumnoDTO alumno, MateriaDTO materia);
    public List<InscripcionDTO> ListarInscripciones(AlumnoDTO alumno);
}
