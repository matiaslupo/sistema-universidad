using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class MateriasAdmin : IMateriasAdministrador
{
    private readonly MateriasDAO _datos = new();

    public Resultado<MateriaDTO> Crear(MateriaDTO materia)
    {
        var resultado = new Resultado<MateriaDTO>();
        try
        {
            materia.Id = _datos.Crear(materia);
            resultado.Entidad = materia;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Materia);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar materia");
        }
        return resultado;
    }

    public List<MateriaDTO> Listar()
    {
        return _datos.Listar();
    }
}
