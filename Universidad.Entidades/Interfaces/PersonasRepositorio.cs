using Universidad.Entidades.DTO;

namespace Universidad.Entidades.Interfaces;

public interface PersonasRepositorio
{
    public int Crear(ProfesorDTO profesor);
    public int Crear(AlumnoDTO alumno);
    public ProfesorDTO BuscarProfesorPorDNI(string dni);
    public AlumnoDTO BuscarAlumnoPorDNI(string dni);
    public void EliminarProfesorPorDNI(string dni);
    public void EliminarAlumnoPorDNI(string dni);
}
