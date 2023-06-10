using Api.Data;
using api.Models;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("/v1")]
    public class Endereco_TipoController : ControllerBase
    {
        [HttpGet]
        [Route(template: "enderecos_tipos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {

            var endereco_tipos = await context
                .Endereco_Tipos
                .AsNoTracking()
                .ToListAsync();

            return Ok(endereco_tipos);
        }

        [HttpGet]
        [Route("enderecos_tipos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {

            var endereco_tipo = await context
                .Endereco_Tipos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return endereco_tipo == null
                ? NotFound()
                : Ok(endereco_tipo);
        }

        [HttpPost("enderecos_tipos")]
        public async Task<IActionResult> PostAsync(
           [FromServices] AppDbContext context,
           [FromBody] CreateEndereco_TipoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var endereco_tipo = new Endereco_Tipo
            {
                Descricao = model.Descricao
            };

            try
            {
                await context.Endereco_Tipos.AddAsync(endereco_tipo);
                await context.SaveChangesAsync();
                return Created(uri: $"enderecos_tipos/{endereco_tipo.Id}", endereco_tipo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("enderecos_tipos/{id}")]
        public async Task<IActionResult> PutAsync(
           [FromServices] AppDbContext context,
           [FromBody] CreateEndereco_TipoViewModel model,
           [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var endereco_tipo = await context
                .Endereco_Tipos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (endereco_tipo == null)
                return NotFound();

            try
            {
                endereco_tipo.Descricao = model.Descricao;

                context.Endereco_Tipos.Update(endereco_tipo);
                await context.SaveChangesAsync();

                return Ok(endereco_tipo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("enderecos_tipos/{id}")]
        public async Task<IActionResult> PutAsync(
           [FromServices] AppDbContext context,
           [FromRoute] int id)
        {
            var endereco_tipo = await context
                .Endereco_Tipos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (endereco_tipo == null)
                return NotFound();

            try
            {
                context.Endereco_Tipos.Remove(endereco_tipo);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
