using Microsoft.AspNetCore.Mvc;
using sistemaFolhaDePagamento.Models;
using sistemaFolhaDePagamento.Service;

namespace sistemaFolhaDePagamento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosCargosController : ControllerBase
    {
        private readonly IFuncionarioCargoService _funcionarioCargoService;

        public FuncionariosCargosController(IFuncionarioCargoService funcionarioCargoService)
        {
            _funcionarioCargoService = funcionarioCargoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<FuncionarioCargo> funcionarioCargos = _funcionarioCargoService.GetFuncionarioCargos();
                return Ok(funcionarioCargos);
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
                FuncionarioCargo funcionarioCargo = _funcionarioCargoService.GetFuncionarioCargoById(id);

                if (funcionarioCargo == null)
                {
                    return NotFound("FuncionárioCargo não encontrado");
                }

                return Ok(funcionarioCargo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] FuncionarioCargo funcionarioCargo)
        {
            try
            {
                _funcionarioCargoService.CreateFuncionarioCargo(funcionarioCargo);
                return CreatedAtAction(nameof(GetById), new { id = funcionarioCargo.Id }, funcionarioCargo);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FuncionarioCargo funcionarioCargo)
        {
            try
            {
                _funcionarioCargoService.UpdateFuncionarioCargo(id, funcionarioCargo);
                return Ok("FuncionárioCargo atualizado com sucesso");
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
                _funcionarioCargoService.DeleteFuncionarioCargo(id);
                return Ok("FuncionárioCargo excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}
