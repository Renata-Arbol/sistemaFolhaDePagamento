using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;

        public TelefonesController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Telefone> telefones = _telefoneService.GetTelefones();
                return Ok(telefones);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Telefone telefone = _telefoneService.GetTelefoneById(id);

                if (telefone == null)
                {
                    return NotFound("Telefone não encontrado");
                }

                return Ok(telefone);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Telefone telefone)
        {
            try
            {
                _telefoneService.CreateTelefone(telefone);
                return CreatedAtAction(nameof(GetById), new { id = telefone.Id }, telefone);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Telefone telefone)
        {
            try
            {
                _telefoneService.UpdateTelefone(id, telefone);
                return Ok("Telefone atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _telefoneService.DeleteTelefone(id);
                return Ok("Telefone excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
