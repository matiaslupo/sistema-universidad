using Microsoft.AspNetCore.Mvc;
using Universidad.API.Models.Request;
using Universidad.Entidades.DTO;
using Universidad.Entidades.Helpers;
using Universidad.Entidades.Interfaces;
using Universidad.Entidades.Respuestas;
using Universidad.Negocio.Contratos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Universidad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private IMateriasAdministrador _materias;

        public MateriasController(IMateriasAdministrador admin)
        { 
            _materias = admin;
        }

        // GET: api/<MateriasController>
        [HttpGet]
        public ActionResult<IEnumerable<MateriaDTO>> Listar()
        {
            var datos= _materias.Listar();
            return Ok(datos);
        }

        // POST api/<MateriasController>
        [HttpPost]
        public ActionResult<Resultado<MateriaDTO>> Crear([FromBody] NuevaMateria materia)
        {
            MateriaDTO dto = new()
            {
                Nombre = materia.Nombre,
                Carrera = new CarreraDTO { Id = materia.IdCarrera }
            };
            var resultado = _materias.Crear(dto);
            if (resultado.Operacion == ResultadoOperacionEnum.Error)
                return BadRequest(resultado);

            return Ok(resultado);
        }

       
    }
}
