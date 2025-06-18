using Microsoft.ILP.ProductService.DTOs;

namespace Microsoft.ILP.ProductService.Services
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto? GetById(int id);
        ProductDto Create(CreateProductDto dto);
        void Update(int id, UpdateProductDto dto);
        void Delete(int id);

    }
}
