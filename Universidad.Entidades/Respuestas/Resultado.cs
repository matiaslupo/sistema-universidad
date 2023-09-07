using Universidad.Entidades.Helpers;
using Universidad.Entidades.Interfaces;

namespace Universidad.Entidades.Respuestas;

public class Resultado<T> where T : IDTO
{
    public T? Entidad { get; set; }
    public ResultadoOperacionEnum Operacion { get; set; }
    public string Mensaje { get; set; } = string.Empty;
}
