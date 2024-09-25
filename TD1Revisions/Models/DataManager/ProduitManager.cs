using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TD1Revisions.Models.EntityFramework;
using TD1Revisions.Models.Repository;

namespace TD1Revisions.Models.DataManager
{
    public class ProduitManager : IDataRepository<Produit>
    {
        readonly ProduitsDBContext _dbContext;

        public ProduitManager() { }

        public ProduitManager(ProduitsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Produit entity)
        {
            await _dbContext.Produits.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Produit entity)
        {
            _dbContext.Produits.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Produit>>> GetAllAsync()
        {
            return await _dbContext.Produits.ToListAsync();
        }

        public async Task<ActionResult<Produit>> GetByIdAsync(int idProduit)
        {
            return await _dbContext.Produits.FirstOrDefaultAsync(p => p.IdProduit == idProduit);
        }

        public async Task<ActionResult<Produit>> GetByStringAsync(string nomProduit)
        {
            return await _dbContext.Produits.FirstOrDefaultAsync(p => p.NomProduit.ToUpper() == nomProduit.ToUpper());
        }

        public async Task UpdateAsync(Produit produit, Produit entity)
        {
            _dbContext.Entry(produit).State = EntityState.Modified;
            produit.IdProduit = entity.IdProduit;
            produit.NomProduit = entity.NomProduit;
            produit.Description = entity.Description;
            produit.NomPhoto = entity.NomPhoto;
            produit.UriPhoto = entity.UriPhoto;
            produit.StockReel = entity.StockReel;
            produit.StockMin = entity.StockMin;
            produit.StockMax = entity.StockMax;
            produit.IdMarqueNavigation = entity.IdMarqueNavigation;
            produit.IdTypeProduitNavigation = entity.IdTypeProduitNavigation;
            await _dbContext.SaveChangesAsync();
        }
    }
}
