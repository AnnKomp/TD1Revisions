using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using BlazorTD1Revisions.Models;

namespace BlazorTD1Revisions.Services
{
    public class WSService : IService
    {
        private readonly HttpClient httpClient;

        public WSService(string uri)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Produit>> GetProduitsAsync(string nomControleur)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Produit>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Produit> GetProduitAsync(string nomControleur, int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<Produit>(string.Concat(nomControleur, "/", id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostProduitAsync(string nomControleur, Produit produit)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<Produit>(nomControleur, produit);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PutProduitAsync(string nomControleur, Produit produit)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(string.Concat(nomControleur, "/", produit.IdProduit), produit);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduitAsync(string nomControleur, Produit produit)
        {
            try
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(string.Concat(nomControleur, "/", produit.IdProduit));
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
