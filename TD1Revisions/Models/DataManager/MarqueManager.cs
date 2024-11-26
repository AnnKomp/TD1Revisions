using Microsoft.AspNetCore.Mvc;
using TD1Revisions.Models.EntityFramework;
using TD1Revisions.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace TD1Revisions.Models.DataManager
{
    public class MarqueManager : IDataRepository<Marque>
    {
        readonly ProduitsDBContext? _dbContext;

        public MarqueManager() { }

        public MarqueManager(ProduitsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Marque entity)
        {
            await _dbContext.Marques.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Marque entity)
        {
            _dbContext.Marques.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Marque>>> GetAllAsync()
        {
            return await _dbContext.Marques.ToListAsync();
        }

        public async Task<ActionResult<Marque>> GetByIdAsync(int idMarque)
        {
            return await _dbContext.Marques.FirstOrDefaultAsync(m => m.IdMarque == idMarque);
        }

        public async Task<ActionResult<Marque>> GetByStringAsync(string nomMarque)
        {
            return await _dbContext.Marques.FirstOrDefaultAsync(m => m.NomMarque.ToUpper() == nomMarque.ToUpper());
        }

        public async Task UpdateAsync(Marque marque, Marque entity)
        {
            _dbContext.Entry(marque).State = EntityState.Modified;
            marque.IdMarque = entity.IdMarque;
            marque.NomMarque = entity.NomMarque;
            await _dbContext.SaveChangesAsync();
        }


    }
}
