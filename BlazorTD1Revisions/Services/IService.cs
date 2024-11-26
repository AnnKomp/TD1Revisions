using BlazorTD1Revisions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTD1Revisions.Services
{
    public interface IService
    {
        Task<List<Produit>> GetProduitsAsync(string nomControleur);
        Task<Produit> GetProduitAsync(string nomControleur, int id);
        Task<bool> PostProduitAsync(string nomControleur, Produit produit);
        Task<bool> PutProduitAsync(string nomControleur, Produit produit);
        Task<bool> DeleteProduitAsync(string nomControleur, Produit produit);

    }
}
