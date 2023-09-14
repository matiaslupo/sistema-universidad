using Universidad.DAL.DAO;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

namespace Universidad.Negocio.Admin;

public class InscripcionesAdmin : IInscripcionesAdministrador
{
    private readonly InscripcionesDAO _datos = new();

    public Resultado<InscripcionDTO> Inscribir(AlumnoDTO alumno, MateriaDTO materia)
    {
        var resultado = new Resultado<InscripcionDTO>();
        try
        {
            var inscripcion = new InscripcionDTO
            {
                Alumno = alumno,
                Materia = materia
            };
            inscripcion.Id = _datos.Crear(inscripcion);
            resultado.Entidad = inscripcion;
            resultado.Operacion = ResultadoOperacionEnum.Info;
            resultado.Mensaje = MensajesEstandar.EntidadCreada(EntidadesString.Inscripcion);
        }
        catch (Exception ex)
        {
            resultado.Entidad = null;
            resultado.Operacion = ResultadoOperacionEnum.Error;
            resultado.Mensaje = MensajesEstandar.Error(ex, "agregar inscripcion");
        }
        return resultado;
    }

    public List<InscripcionDTO> ListarInscripciones(AlumnoDTO alumno)
    {
        return _datos.Listar();
    }
}
