using Microsoft.ILP.ProductService.Models;
using System.Text.Json;

namespace Microsoft.ILP.ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _filePath = "Data/products.json";

        public List<Product> GetAll()
        {
            if (!File.Exists(_filePath)) return new List<Product>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public Product? GetById(int id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            var products = GetAll();
            products.Add(product);
            Save(products);
        }

        public void Update(Product product)
        {
            var products = GetAll();
            var index = products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                products[index] = product;
                Save(products);
            }
        }

        public void Delete(int id)
        {
            var products = GetAll().Where(p => p.Id != id).ToList();
            Save(products);
        }

        public int GetNextId()
        {
            var products = GetAll();
            return products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;
        }

        private void Save(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory("Data");
            File.WriteAllText(_filePath, json);
        }
    }
}
