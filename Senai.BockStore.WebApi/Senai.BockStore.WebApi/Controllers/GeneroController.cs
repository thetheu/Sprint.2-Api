using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BockStore.WebApi.Repositories;

namespace Senai.BockStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/Json")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();
        [HttpGet]
        public IActionResult Listar()
        {
            GeneroRepository.Listar();
            return Ok();
        }
    }
}