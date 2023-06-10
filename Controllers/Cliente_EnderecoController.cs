using Api.Data;
using api.Models;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("/v1")]
    public class Cliente_EnderecoController : ControllerBase
    {
        [HttpGet]
        [Route(template: "clientes_enderecos")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {

            var clientes_enderecos = await context
                .Clientes_Enderecos
                .AsNoTracking()
                .ToListAsync();

            return Ok(clientes_enderecos);
        }

        [HttpGet]
        [Route("clientes_enderecos/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] AppDbContext context,
            [FromRoute] int id)
        {

            var cliente_endereco = await context
                .Clientes_Enderecos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return cliente_endereco == null
                ? NotFound()
                : Ok(cliente_endereco);
        }

        [HttpPost("clientes_enderecos")]
        public async Task<IActionResult> PostAsync(
           [FromServices] AppDbContext context,
           [FromBody] CreateClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = new Cliente
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                Senha_Criptografada = model.Senha.ConvertToMD5(),
                Data_Cadastro = DateTime.Now,
                Ativo = true
            };

            try
            {
                await context.Clientes.AddAsync(cliente);
                await context.SaveChangesAsync();
                return Created(uri: $"clientes/{cliente.Id}", cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("clientes/{id}")]
        public async Task<IActionResult> PutAsync(
           [FromServices] AppDbContext context,
           [FromBody] CreateClienteViewModel model,
           [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = await context
                .Clientes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound();

            try
            {
                cliente.Nome = model.Nome;
                cliente.Email = model.Email;
                cliente.Senha = model.Senha;
                cliente.Senha_Criptografada = model.Senha.ConvertToMD5();

                context.Clientes.Update(cliente);
                await context.SaveChangesAsync();

                return Ok(cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("clientes/{id}")]
        public async Task<IActionResult> PutAsync(
           [FromServices] AppDbContext context,
           [FromRoute] int id)
        {
            var cliente = await context
                .Clientes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound();

            try
            {
                context.Clientes.Remove(cliente);
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
