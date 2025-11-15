using AutoMapper;
using FluentValidation;
using PetShop.Application.Contract;
using PetShop.Application.Core;
using PetShop.Application.Dtos.Product;
using PetShop.Domain.Entities;
using PetShop.Infrastructure.Interfaces; 

namespace PetShop.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductCreateDto> _validator;

        public ProductService(IProductRepository productRepository,
                              IMapper mapper,
                              IValidator<ProductCreateDto> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResult<IEnumerable<ProductDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<ProductDto>>();
            var products = await _productRepository.GetAll();
            result.Data = _mapper.Map<IEnumerable<ProductDto>>(products);
            return result;
        }

        public async Task<ServiceResult<ProductDto>> GetById(int id)
        {
            var result = new ServiceResult<ProductDto>();
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                result.Success = false;
                result.Message = "Producto no encontrado.";
                return result;
            }
            result.Data = _mapper.Map<ProductDto>(product);
            return result;
        }

        public async Task<ServiceResult<ProductDto>> Add(ProductCreateDto createDto)
        {
            var result = new ServiceResult<ProductDto>();

            
            var validation = await _validator.ValidateAsync(createDto);
            if (!validation.IsValid)
            {
                result.Success = false;
                result.Message = validation.Errors.FirstOrDefault()?.ErrorMessage;
                return result;
            }

            
            var product = _mapper.Map<Product>(createDto);

            
            await _productRepository.Add(product);

            
            result.Data = _mapper.Map<ProductDto>(product);
            return result;
        }
    }
}