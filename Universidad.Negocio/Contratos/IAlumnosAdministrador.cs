using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface IAlumnosAdministrador
{
    public Resultado<AlumnoDTO> AgregarAlumno(AlumnoDTO alumno);
    public Resultado<AlumnoDTO> BuscarAlumnoPorDNI(string dni);
    public Resultado<IDTO> EliminarAlumnoPorDNI(string dni);
}
