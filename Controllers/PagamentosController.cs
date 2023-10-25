using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.DTOS;
using sistemaFolhaDePagamento.Models;

using sistemaFolhaDePagamento.Models;
using System;
using System.Collections.Generic;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly Service.IPagamentoService _pagamentoService;

        public PagamentosController(Service.IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Pagamento> pagamentos = _pagamentoService.GetPagamentos();
                return Ok(pagamentos);
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
                CalcResponse pagamento = _pagamentoService.GetPagamentoById(id);

                if (pagamento == null)
                {
                    return NotFound("Funcionário não encontrado");
                }

                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pagamento pagamento)
        {
            try
            {
                _pagamentoService.CreatePagamento(pagamento);
                return CreatedAtAction(nameof(GetById), new { id = pagamento.Id }, pagamento);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Pagamento pagamento)
        {
            try
            {
                _pagamentoService.UpdatePagamento(id, pagamento);
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
                _pagamentoService.DeletePagamento(id);
                return Ok("Funcionário excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
