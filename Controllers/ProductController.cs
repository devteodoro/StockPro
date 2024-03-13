using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockPro.Data;
using StockPro.Extensions;
using StockPro.Models;
using StockPro.ViewModels;

namespace StockPro.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("v1/products")]
        public async Task<IActionResult> GetAsync([FromServices] StockProDataContext context)
        {
            try
            {
                var products = await context.Products.ToListAsync();
                return Ok(new ResultViewModel<List<Product>>(products));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Product>>("Falha interna no servidor"));
            }
        }

        [HttpGet("v1/products/{id:int}")]
        public async Task<IActionResult> GetAsyncById([FromServices] StockProDataContext context, [FromRoute] int id)
        {
            try
            {
                var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                    return NotFound(new ResultViewModel<Product>("Produto não encontrado"));

                return Ok(new ResultViewModel<Product>(product));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Product>("Falha interna no servidor"));
            }
        }

        [HttpPost("v1/products")]
        public async Task<IActionResult> PostAsync([FromServices] StockProDataContext context, [FromBody] EditorProductViewModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Product>(ModelState.GetErrors()));

            try
            {
                var product = new Product
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{product.Id}", product);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Product>("Não foi possivel incluir o produto"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Product>("Falha interna no servidor"));
            }
        }


        [HttpPut("v1/products/{id:int}")]
        public async Task<IActionResult> PutAsync([FromServices] StockProDataContext context, [FromBody] EditorProductViewModel model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Product>(ModelState.GetErrors()));

            try
            {
                var product = await context
                                .Products
                                .FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                    return NotFound(new ResultViewModel<Product>("Produto não encontrado!"));

                product.Name = model.Name;
                product.Description = model.Description;

                context.Products.Update(product);
                context.SaveChanges();

                return Ok(new ResultViewModel<Product>(product));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Product>("Falha interna no servidor"));
            }
        }


        [HttpDelete("v1/products/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromServices] StockProDataContext context, [FromRoute] int id)
        {
            try
            {
                var product = await context.
                                Products.
                                FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                    return NotFound(new ResultViewModel<Product>("Conteudo não encontrado!"));

                context.Products.Remove(product);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Product>(product));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new ResultViewModel<Product>("Não foi possivel excluir o produto"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Product>("Falha interna no servidor"));
            }
        }
    }
}
