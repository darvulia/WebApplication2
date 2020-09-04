using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.EFModels;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumasController : ControllerBase
    {
        private readonly apiPruebaContext _context;

        public  SumasController(apiPruebaContext context)
        {
            _context = context;
        }


        // GET: api/Sumas
        [HttpGet]
        public async Task<List<Sumas>> Get()
        {
            var resultado = await _context.Sumas.ToListAsync();

            return resultado;
        }


        // GET: api/Sumas/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Sumas> Get(int id)
        {

            var resultado = await _context.Sumas.FirstOrDefaultAsync(x => x.Id == id);

            return resultado;

        }



        // POST: api/Sumas
        [HttpPost]
        public async Task<Sumas> Post([FromBody] Sumas suma)
        {
            suma.Resultado = suma.Valor1 + suma.Valor2;
            await _context.Sumas.AddAsync(suma);
            await _context.SaveChangesAsync();
            return suma;


        }

        // PUT: api/Sumas/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Sumas suma)
        {
            if (id != suma.Id)
            {
                return BadRequest();
            }

            suma.Resultado = suma.Valor1 + suma.Valor2;
            _context.Entry(suma).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(suma);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var sumId = await _context.Sumas.FirstOrDefaultAsync(x => x.Id == id);

            if (sumId ==null)
            {
                return BadRequest();
            }

             _context.Sumas.Remove(sumId);
            await _context.SaveChangesAsync();

            return Ok(sumId);

        }
    }
}
