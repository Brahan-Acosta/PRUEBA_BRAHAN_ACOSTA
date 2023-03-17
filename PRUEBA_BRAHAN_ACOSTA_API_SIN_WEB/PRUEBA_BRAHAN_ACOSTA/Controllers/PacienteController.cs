using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRUEBA_BRAHAN_ACOSTA.Data;
using PRUEBA_BRAHAN_ACOSTA.Models;

namespace PRUEBA_BRAHAN_ACOSTA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        // GET: LISTAR PACIENTES
        [HttpGet]
        public List<Paciente> Get()
        {
            return PacientesData.listarPaciente();
        }

        // GET LISTAR PACIENTE POR ID
        [HttpGet("{id}")]
        public Paciente Get(int id)
        {
            return PacientesData.listarPacienteId(id);
        }

        // POST CREAT PACIENTE
        [HttpPost]
        public bool Post([FromBody] Paciente _alumno)
        {
            return PacientesData.crearPaciente(_alumno);
        }

        // PUT ACTUALIZAR PACIENTE
        [HttpPut]
        public bool Put([FromBody] Paciente _alumno)
        {
            return PacientesData.actualizarPaciente(_alumno);
        }

        // DELETE ELIMINAR PACIENTE
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return PacientesData.eliminarPaciente(id);
        }
    }
}
