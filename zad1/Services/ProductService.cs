using zad1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zad1.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(product);
        }

        public async Task AddProductAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            await Task.CompletedTask;
        }
    }
}
