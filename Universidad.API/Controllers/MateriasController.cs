using Microsoft.AspNetCore.Mvc;
using Universidad.Entidades.DTO;
using Universidad.Negocio.Admin;
using Universidad.Negocio.Contratos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Universidad.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private IMateriasAdministrador _materias = new MateriasAdmin();

        // GET: api/<MateriasController>
        [HttpGet]
        public async Task<IEnumerable<MateriaDTO>> Get()
        {
            List<MateriaDTO> datos= _materias.Listar();
            return datos;
        }

        // GET api/<MateriasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MateriasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MateriasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MateriasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
