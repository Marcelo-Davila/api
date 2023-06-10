using Api.Data;
using api.Models;
using api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

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
           [FromBody] CreateCliente_EnderecoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente_endereco = new Cliente_Endereco
            {
                Bairro = model.Bairro,
                CEP = model.CEP,
                Cidade = model.Cidade,
                Complemento = model.Complemento,
                Rua = model.Rua,
                Rua_Nro = model.Rua_Nro,
                Cliente_Id = model.Cliente_Id,
                Endereco_Tipo_Id = model.Endereco_Tipo_Id
            };

            try
            {
                await context.Clientes_Enderecos.AddAsync(cliente_endereco);
                await context.SaveChangesAsync();
                return Created(uri: $"clientes_enderecos/{cliente_endereco.Id}", cliente_endereco);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("clientes_enderecos/{id}")]
        public async Task<IActionResult> PutAsync(
           [FromServices] AppDbContext context,
           [FromBody] CreateCliente_EnderecoViewModel model,
           [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente_endereco = await context
                .Clientes_Enderecos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cliente_endereco == null)
                return NotFound();

            try
            {
                cliente_endereco.Bairro = model.Bairro;
                cliente_endereco.CEP = model.CEP;
                cliente_endereco.Cidade = model.Cidade;
                cliente_endereco.Complemento = model.Complemento;
                cliente_endereco.Rua = model.Rua;
                cliente_endereco.Rua_Nro = model.Rua_Nro;
                cliente_endereco.Cliente_Id = model.Cliente_Id ;
                cliente_endereco.Endereco_Tipo_Id = model.Endereco_Tipo_Id;

                context.Clientes_Enderecos.Update(cliente_endereco);
                await context.SaveChangesAsync();

                return Ok(cliente_endereco);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("clientes_enderecos/{id}")]
        public async Task<IActionResult> PutAsync(
           [FromServices] AppDbContext context,
           [FromRoute] int id)
        {
            var cliente_endereco = await context
                .Clientes_Enderecos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (cliente_endereco == null)
                return NotFound();

            try
            {
                context.Clientes_Enderecos.Remove(cliente_endereco);
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
