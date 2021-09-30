using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cita.Models;
using Cita.Services;

namespace Cita.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitaController : ControllerBase
    {
        public CitaController()
        {
        }

        [HttpGet]
        public ActionResult<List<Cita>> GetAll() => CitaServices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Cita> Get(int id)
        {
            var cita = CitaServices.Get(id);

            if (cita == null)
                return NotFound();

            return cita;
        }

        [HttpPost]
        public IActionResult Create(Cita cita)
        {
            CitaServices.Add(cita);
            return CreatedAtAction(nameof(Create), new { id = cita.Id }, cita);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Cita cita)
        {
            if (id != cita.Id)
                return BadRequest();

            var existingCita = CitaServices.Get(id);
            if (existingCita is null)
                return NotFound();

            CitaServices.Update(cita);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = CitaServices.Get(id);

            if (pizza is null)
                return NotFound();

            CitaServices.Delete(id);

            return NoContent();
        }
    }
}