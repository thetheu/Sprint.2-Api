using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstilosRepository EstilosRepository = new EstilosRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstilosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                EstilosRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Tá errado" + ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos EstiloBuscado = EstilosRepository.BuscarPorId(estilo.IdEstilo);
                    if (EstiloBuscado == null)
                    return NotFound();

                EstilosRepository.Atualizar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = "Tá errado" });
                
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorid(int id)
        {
            Estilos Estilo = EstilosRepository.BuscarPorId(id);
            if (Estilo == null)
                return NotFound();
            return Ok(Estilo);
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            EstilosRepository.Deletar(id);
            return Ok();
        }
    }
}