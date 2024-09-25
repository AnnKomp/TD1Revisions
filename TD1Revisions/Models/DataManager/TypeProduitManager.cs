using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TD1Revisions.Models.EntityFramework;
using TD1Revisions.Models.Repository;

namespace TD1Revisions.Models.DataManager
{
    public class TypeProduitManager : IDataRepository<TypeProduit>
    {
        readonly ProduitsDBContext _dbContext;

        public TypeProduitManager() { }

        public TypeProduitManager(ProduitsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TypeProduit entity)
        {
            await _dbContext.TypeProduits.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TypeProduit entity)
        {
            _dbContext.TypeProduits.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<TypeProduit>>> GetAllAsync()
        {
            return await _dbContext.TypeProduits.ToListAsync();
        }

        public async Task<ActionResult<TypeProduit>> GetByIdAsync(int idTypeProduit)
        {
            return await _dbContext.TypeProduits.FirstOrDefaultAsync(t => t.IdTypeProduit == idTypeProduit);
        }

        public async Task<ActionResult<TypeProduit>> GetByStringAsync(string nomTypeProduit)
        {
            return await _dbContext.TypeProduits.FirstOrDefaultAsync(t => t.NomTypeProduit.ToUpper() == nomTypeProduit.ToUpper());
        }

        public async Task UpdateAsync(TypeProduit typeProduit, TypeProduit entity)
        {
            _dbContext.Entry(typeProduit).State = EntityState.Modified;
            typeProduit.IdTypeProduit = entity.IdTypeProduit;
            typeProduit.NomTypeProduit = entity.NomTypeProduit;
            await _dbContext.SaveChangesAsync();
        }
    }
}
