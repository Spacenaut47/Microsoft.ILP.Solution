using Microsoft.Extensions.Options;
using Microsoft.ILP.Web.Models;
using Microsoft.ILP.Web.Settings;
using System.Text.Json;

namespace Microsoft.ILP.Web.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllAsync();
    }

    public class ProductService : IProductService
    {
        private readonly string _productApiUrl;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IOptions<ServiceEndpoints> options, IHttpClientFactory factory)
        {
            _productApiUrl = options.Value.ProductService!;
            _httpClientFactory = factory;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_productApiUrl);
            if (!response.IsSuccessStatusCode) return new List<ProductViewModel>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductViewModel>>(json) ?? new();
        }
    }
}
