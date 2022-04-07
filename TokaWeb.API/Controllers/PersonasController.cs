using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TokaWeb.API.Context;
using TokaWeb.API.DTOs;
using TokaWeb.API.Interface;
using TokaWeb.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TokaWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IPersonas _personasService;
        public PersonasController(AppDbContext context, IPersonas personas)
        {
            this.context = context;
            this._personasService = personas;
        }
        // GET: api/<PersonasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var personas = await _personasService.GetPersonasFisicasAsync();
             
            return Ok(personas);
        }

        // GET api/<PersonasController>/5
        [HttpGet("{IdPersonaFisica}")]
        public async Task<IActionResult> Get(int IdPersonaFisica)
        {
            var persona = await _personasService.GetPersonaFisicaByIDAsync(IdPersonaFisica);
            if (persona == null)
            {
                return StatusCode((int)HttpStatusCode.OK, "No encontrado");

            }
            return Ok(persona);
        }

        // POST api/<PersonasController>
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] DTOsPersonasFisicas personaFisicas)
        {
            bool nuevaPersona = await _personasService.SaveAsync(personaFisicas);
            if (nuevaPersona)
            { 
                 return StatusCode((int)HttpStatusCode.OK, "Success"); 
            }
            else { 
                return StatusCode((int)HttpStatusCode.BadGateway, "error"); 
            }
        }
         

        // PUT api/<PersonasController>/5
        [HttpPut("{IdPersonaFisica}")]
        public async Task<IActionResult> Put(int IdPersonaFisica, [FromBody] DTOsPersonasFisicas personaFisica)
        {
 
            bool nuevaPersona = await _personasService.UpdateAsync(IdPersonaFisica,personaFisica);
            if (nuevaPersona)
            {
                return StatusCode((int)HttpStatusCode.OK, "Success");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadGateway, "error");
            }
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{IdPersonaFisica}")]
        public async Task<IActionResult> Delete(int IdPersonaFisica)
        {
            bool nuevaPersona = await _personasService.DeleteAsync(IdPersonaFisica);
            if (nuevaPersona)
            {
                return StatusCode((int)HttpStatusCode.OK, "Success");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadGateway, "error");
            }
        }
    }
}
