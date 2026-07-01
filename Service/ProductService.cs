using ProductManagement.DTOs;
using ProductManagement.Exceptions;
using ProductManagement.Repository;
using System.Xml.Linq;

namespace ProductManagement.Service
{
    public class ProductService : IProductService { 
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public void Add(ProductRequestDTO dto)
        {
            repository.Add(dto);
        }

        public void Delete(int id)
        {
            var p = repository.GetById(id);
            if(p == null)
            {
               throw new ProductNotFoundException($"Product with Id {id} not found.");
            }
            repository.Delete(id);
        }

        public List<ProductResponseDTO> GetAll()
        {
            return repository.GetAll();
        }

        public ProductResponseDTO GetById(int id)
        {
            var p = repository.GetById(id);
            if(p == null)
            {
                throw new ProductNotFoundException($"Product with Id {id} not found.");
            }
            return p;
        }

        public List<ProductResponseDTO> Pagination(int page, int pageSize)
        {
            var p = repository.Pagination(page, pageSize);
            if (!p.Any())
            {
                throw new ProductNotFoundException($"NNo products found for the requested page.");
            }
            return p;
        }

        public List<ProductResponseDTO> SearchByBrand(string brand)
        {
            var p = repository.SearchByBrand(brand);
            if (p == null)
            {
                throw new ProductNotFoundException($"No products found with name '{brand}'.");
            }
            return p;
        }

        public List<ProductResponseDTO> SearchByName(string name)
        {
            var p = repository.SearchByName(name);
            if(p == null)
            {
                throw new ProductNotFoundException($"No products found with name '{name}'.");
            }
            return p;
        }


        public List<ProductResponseDTO> SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            var p = repository.SearchByPrice(minPrice, maxPrice);
            if (!p.Any())
            {
                throw new ProductNotFoundException($"No products found between ₹{minPrice} and ₹{maxPrice}.");
            }
            return p;
        }

        public List<ProductResponseDTO> SortByName()
        {
            var p = repository.SortByName();
            if (!p.Any())
            {
                throw new ProductNotFoundException("No products available.");
            }
            return p;

        }

        public List<ProductResponseDTO> SortByPrice()
        {
            var p = repository.SortByPrice();
            if (!p.Any())
            {
                throw new ProductNotFoundException("No products available.");
            }
            return p;
        }

        public void Update(int id, ProductRequestDTO dto)
        {
            var p = repository.GetById(id);
            if (p == null)
            {
                throw new ProductNotFoundException($"Product with Id {id} not found.");
            }
            repository.Update(id, dto);
        }
    }
}
