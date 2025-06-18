using AutoMapper;
using Microsoft.ILP.ProductService.DTOs;
using Microsoft.ILP.ProductService.Models;
using Microsoft.ILP.ProductService.Repositories;

namespace Microsoft.ILP.ProductService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<ProductDto> GetAll()
        {
            var products = _repository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public ProductDto? GetById(int id)
        {
            var product = _repository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto Create(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            product.Id = _repository.GetNextId();
            _repository.Add(product);
            return _mapper.Map<ProductDto>(product);
        }

        public void Update(int id, UpdateProductDto dto)
        {
            var product = _repository.GetById(id);
            if (product == null) return;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Category = dto.Category;
            product.Stock = dto.Stock;

            _repository.Update(product);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
