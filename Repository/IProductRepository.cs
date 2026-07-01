using ProductManagement.DTOs;

namespace ProductManagement.Repository
{
    public interface IProductRepository
    {
        void Add(ProductRequestDTO dto);
        List<ProductResponseDTO> GetAll();

        ProductResponseDTO GetById(int id);

        void Update(int id, ProductRequestDTO dto);

        void Delete(int id);

        //V2 

        List<ProductResponseDTO> SearchByName(string name);
        List<ProductResponseDTO> SearchByBrand(string brand);
        List<ProductResponseDTO> SearchByPrice(decimal minPrice, decimal maxPrice);

        List<ProductResponseDTO> SortByPrice();
        List<ProductResponseDTO> SortByName();
        List<ProductResponseDTO> Pagination(int page, int pageSize);

    }
}
