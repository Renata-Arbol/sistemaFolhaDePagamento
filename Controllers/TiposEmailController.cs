using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEmailController : ControllerBase
    {
        private readonly ITipoEmailService _tipoEmailService;

        public TiposEmailController(ITipoEmailService tipoEmailService)
        {
            _tipoEmailService = tipoEmailService;
        }

        [HttpGet(Name = "TiposEmail")]
        public IActionResult Get()
        {
            var tiposEmail = _tipoEmailService.GetTiposEmail();
            return Ok(tiposEmail);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tipoEmail = _tipoEmailService.GetTipoEmailById(id);
            if (tipoEmail == null)
            {
                return NotFound();
            }

            return Ok(tipoEmail);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TipoEmail tipoEmail)
        {
            if (tipoEmail == null)
            {
                return BadRequest();
            }

            _tipoEmailService.CreateTipoEmail(tipoEmail);
            return CreatedAtRoute("TiposEmail", new { id = tipoEmail.Id }, tipoEmail);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoEmail tipoEmail)
        {
            if (tipoEmail == null || tipoEmail.Id != id)
            {
                return BadRequest();
            }

            var existingTipoEmail = _tipoEmailService.GetTipoEmailById(id);
            if (existingTipoEmail == null)
            {
                return NotFound();
            }

            _tipoEmailService.UpdateTipoEmail(id, tipoEmail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tipoEmail = _tipoEmailService.GetTipoEmailById(id);
            if (tipoEmail == null)
            {
                return NotFound();
            }

            _tipoEmailService.DeleteTipoEmail(id);
            return NoContent();
        }
    }
}
