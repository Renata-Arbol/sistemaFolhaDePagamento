using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecosController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Endereco> enderecos = _enderecoService.GetEnderecos();
                return Ok(enderecos);
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
                Endereco endereco = _enderecoService.GetEnderecoById(id);

                if (endereco == null)
                {
                    return NotFound("Endereço não encontrado");
                }

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                _enderecoService.CreateEndereco(endereco);
                return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Endereco endereco)
        {
            try
            {
                _enderecoService.UpdateEndereco(id, endereco);
                return Ok("Endereço atualizado com sucesso");
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
                _enderecoService.DeleteEndereco(id);
                return Ok("Endereço excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
