using Universidad.Entidades.DTO;
using Universidad.Entidades.Interfaces;
using Universidad.Entidades.Respuestas;

namespace Universidad.Negocio.Contratos;

public interface IPersonaAdministrador<T> where T : IDTO
{
    public Resultado<T> Agregar(T persona);
    public Resultado<T> BuscarPorDNI(string dni);
    public Resultado<IDTO> EliminarPorDNI(string dni);
}
