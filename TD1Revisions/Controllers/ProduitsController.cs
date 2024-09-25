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
    public class ProduitsController : ControllerBase
    {
        //private readonly ProduitsDBContext _context;

        private readonly IDataRepository<Produit> dataRepository;


        public ProduitsController(IDataRepository<Produit> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Produits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Produits/5
        [HttpGet]
        [Route("[action]/{id}")]
        [ActionName("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produit>> GetProduitById(int id)
        {
            var produit = await dataRepository.GetByIdAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        [HttpGet]
        [Route("[action]/{name}")]
        [ActionName("GetByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Produit>> GetProduitByName(string name)
        {
            var produit = await dataRepository.GetByStringAsync(name);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            if (id != produit.IdProduit)
            {
                return BadRequest();
            }

            var produitToUpdate = await dataRepository.GetByIdAsync(id);

            if (produitToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(produitToUpdate.Value, produit);
                return NoContent();
            }

        }

        // POST: api/Produits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await dataRepository.AddAsync(produit);

            return CreatedAtAction("GetById", new { id = produit.IdProduit }, produit);
        }

        // DELETE: api/Produits/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var produit = await dataRepository.GetByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(produit.Value);

            return NoContent();
        }

        //private bool ProduitExists(int id)
        //{
        //    return _context.Produits.Any(e => e.IdProduit == id);
        //}
    }
}
