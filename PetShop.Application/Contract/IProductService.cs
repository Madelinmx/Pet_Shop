using PetShop.Application.Core;
using PetShop.Application.Dtos.Product;

namespace PetShop.Application.Contract
{
    public interface IProductService
    {
        Task<ServiceResult<IEnumerable<ProductDto>>> GetAll();
        Task<ServiceResult<ProductDto>> GetById(int id);
        Task<ServiceResult<ProductDto>> Add(ProductCreateDto createDto);
        
    }
}