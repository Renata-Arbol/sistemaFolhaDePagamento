using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Departamento> departamentos = (IEnumerable<Departamento>)_departamentoService.GetDepartamentos();
                return Ok(departamentos);
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
                Departamento departamento = _departamentoService.GetDepartamentoById(id);

                if (departamento == null)
                {
                    return NotFound("Departamento não encontrado");
                }

                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            try
            {
                _departamentoService.CreateDepartamento(departamento);
                return CreatedAtAction(nameof(GetById), new { id = departamento.Id }, departamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Departamento departamento)
        {
            try
            {
                _departamentoService.UpdateDepartamento(id, departamento);
                return Ok("Departamento atualizado com sucesso");
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
                _departamentoService.DeleteDepartamento(id);
                return Ok("Departamento excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
