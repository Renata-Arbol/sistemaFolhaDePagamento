using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentesController : ControllerBase
    {
        private readonly IDependenteService _dependenteService;

        public DependentesController(IDependenteService dependenteService)
        {
            _dependenteService = dependenteService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Dependente> dependentes = _dependenteService.GetDependentes();
                return Ok(dependentes);
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
                Dependente dependente = _dependenteService.GetDependenteById(id);

                if (dependente == null)
                {
                    return NotFound("Dependente não encontrado");
                }

                return Ok(dependente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Dependente dependente)
        {
            try
            {
                _dependenteService.CreateDependente(dependente);
                return CreatedAtAction(nameof(GetById), new { id = dependente.Id }, dependente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Dependente dependente)
        {
            try
            {
                _dependenteService.UpdateDependente(id, dependente);
                return Ok("Dependente atualizado com sucesso");
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
                _dependenteService.DeleteDependente(id);
                return Ok("Dependente excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
