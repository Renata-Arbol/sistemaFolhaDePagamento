using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatosController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Contato> contatos = _contatoService.GetContatos();
                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                Contato contato = _contatoService.GetContatoById(id);

                if (contato == null)
                {
                    return NotFound("Contato não encontrado");
                }

                return Ok(contato);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contato contato)
        {
            try
            {
                _contatoService.CreateContato(contato);
                return CreatedAtAction(nameof(GetById), new { id = contato.Id }, contato);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Contato contato)
        {
            try
            {
                _contatoService.UpdateContato(id, contato);
                return Ok("Contato atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _contatoService.DeleteContato(id);
                return Ok("Contato excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
