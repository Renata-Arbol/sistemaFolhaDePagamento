using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargosController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Cargo> cargos = _cargoService.GetCargos();
                return Ok(cargos);
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
                Cargo cargo = _cargoService.GetCargoById(id);

                if (cargo == null)
                {
                    return NotFound("Cargo não encontrado");
                }

                return Ok(cargo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cargo cargo)
        {
            try
            {
                _cargoService.CreateCargo(cargo);
                return CreatedAtAction(nameof(GetById), new { id = cargo.Id }, cargo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Cargo cargo)
        {
            try
            {
                _cargoService.UpdateCargo(id, cargo);
                return Ok("Cargo atualizado com sucesso");
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
                _cargoService.DeleteCargo(id);
                return Ok("Cargo excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
