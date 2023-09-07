using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

internal interface IProfesoresAdministrador
{
    public Resultado<ProfesorDTO> AgregarProfesor(ProfesorDTO profesor);
    public Resultado<ProfesorDTO> BuscarProfesorPorDNI(string dni);
    public Resultado<IDTO> EliminarProfesorPorDNI(string dni);
}
