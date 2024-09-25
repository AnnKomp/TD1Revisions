using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TD1Revisions.Models.EntityFramework;
using TD1Revisions.Models.Repository;

namespace TD1Revisions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeProduitsController : ControllerBase
    {
        //private readonly ProduitsDBContext _context;

        private readonly IDataRepository<TypeProduit> dataRepository;


        public TypeProduitsController(IDataRepository<TypeProduit> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/TypeProduits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeProduit>>> GetTypeProduits()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/TypeProduits/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProduit>> GetTypeProduit(int id)
        {
            var typeProduit = await dataRepository.GetByIdAsync(id);

            if (typeProduit == null)
            {
                return NotFound();
            }

            return typeProduit;
        }

        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeProduit>> GetTypeProduitByName(string name)
        {
            var typeProduit = await dataRepository.GetByStringAsync(name);

            if (typeProduit == null)
            {
                return NotFound();
            }

            return typeProduit;
        }

        // PUT: api/TypeProduits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTypeProduit(int id, TypeProduit typeProduit)
        {
            if (id != typeProduit.IdTypeProduit)
            {
                return BadRequest();
            }

            var typeToUpdate = await dataRepository.GetByIdAsync(id);

            if (typeToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(typeToUpdate.Value, typeProduit);
                return NoContent();
            }
        }

        // POST: api/TypeProduits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeProduit>> PostTypeProduit(TypeProduit typeProduit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(typeProduit);

            return CreatedAtAction("GetById", new { id = typeProduit.IdTypeProduit }, typeProduit);
        }

        // DELETE: api/TypeProduits/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTypeProduit(int id)
        {
            var typeProduit = await dataRepository.GetByIdAsync(id);
            if (typeProduit == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(typeProduit.Value);
            return NoContent();
        }

        //private bool TypeProduitExists(int id)
        //{
        //    return _context.TypeProduits.Any(e => e.IdTypeProduit == id);
        //}
    }
}
