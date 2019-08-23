using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repository;

namespace Senai.Filmes.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmesController : ControllerBase
    {

        FilmesRepository FilmesRepository = new FilmesRepository();

        [HttpGet]
        public IEnumerable<FilmesDomain> ListarTodos()
        {
            return FilmesRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FilmesDomain filmesDomain = FilmesRepository.BuscarPorId(id);
            if (filmesDomain == null)
                return NotFound();
            return Ok(filmesDomain);
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmesDomain filme)
        {
            try
            {
                FilmesRepository.Cadastrar(filme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu erro ai rapaz!" + ex.Message });

            }
        }

    }
}