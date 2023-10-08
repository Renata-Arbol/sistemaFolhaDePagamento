using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;
using sistemaFolhaDePagamento.DTOS;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPontosController : ControllerBase
    {
        private readonly IRegistroPontoService _registroPontoService;

        public RegistroPontosController(IRegistroPontoService registroPontoService)
        {
            _registroPontoService = registroPontoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<RegistroPonto> registrosPonto = _registroPontoService.GetRegistrosPonto();
                return Ok(registrosPonto);
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
                RegistroPonto registroPonto = _registroPontoService.GetRegistroPontoById(id);

                if (registroPonto == null)
                {
                    return NotFound("RegistroPonto não encontrado");
                }

                return Ok(registroPonto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult RegistrarPonto([FromBody] LoginDto login)
        {
            if (login == null)
                return BadRequest("Dados inválidos.");

            try
            {
                _registroPontoService.RegistrarPonto(login);
                return Ok("Ponto registrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegistroPonto registroPonto)
        {
            try
            {
                _registroPontoService.UpdateRegistroPonto(id, registroPonto);
                return Ok("RegistroPonto atualizado com sucesso");
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
                _registroPontoService.DeleteRegistroPonto(id);
                return Ok("RegistroPonto excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
