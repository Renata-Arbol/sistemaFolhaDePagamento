using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;

using sistemaFolhaDePagamento.Models;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly Service.IFuncionarioService _funcionarioService;

        public FuncionariosController(Service.IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Funcionario> funcionarios = _funcionarioService.GetFuncionarios();
                return Ok(funcionarios);
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
                Funcionario funcionario = _funcionarioService.GetFuncionarioById(id);

                if (funcionario == null)
                {
                    return NotFound("Funcionário não encontrado");
                }

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionario)
        {
            try
            {
                _funcionarioService.CreateFuncionario(funcionario);
                return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Funcionario funcionario)
        {
            try
            {
                _funcionarioService.UpdateFuncionario(id, funcionario);
                return Ok("Funcionário atualizado com sucesso");
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
                _funcionarioService.DeleteFuncionario(id);
                return Ok("Funcionário excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
