using ProductManagement.Data;
using ProductManagement.DTOs;
using ProductManagement.Model;

namespace ProductManagement.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(ProductRequestDTO dto)
        {
            Product p = new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity,
                Brand = dto.Brand,
                SKU = dto.SKU
            };
            context.products.Add(p);
            context.SaveChanges();
            
        }

        public List<ProductResponseDTO> GetAll()
        {
            return context.products.Select(p=>new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU
            }).ToList();
        }

        public ProductResponseDTO GetById(int id)
        {
            var product = context.products.FirstOrDefault(p=>p.ProductId == id);
            if(product == null)
            {
                return null;
            }
            return new ProductResponseDTO
            {
                ProductId= product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                Brand = product.Brand,
                SKU = product.SKU
            };
             
        }
    

        public void Update(int id, ProductRequestDTO dto)
        {
            var product = context.products.FirstOrDefault(p => p.ProductId == id);
            if( product != null)
            {
                product.Name = dto.Name;
                product.Description = dto.Description;
                product.Price = dto.Price;
                product.Quantity = dto.Quantity;
                product.Brand = dto.Brand;
                product.SKU = dto.SKU;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = context.products.FirstOrDefault(p => p.ProductId == id);

            if (product != null)
            {
                context.products.Remove(product);
                context.SaveChanges();
            }
        }

        public List<ProductResponseDTO> SearchByName(string name)
        {
            return context.products.Where(p => p.Name.ToLower().Contains(name.ToLower())).Select(p => new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU

            }).ToList();
        }

        public List<ProductResponseDTO> SearchByBrand(string brand)
        {
            return context.products.Where(p=> p.Brand.ToLower().Contains(brand.ToLower())).Select(p=> new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU

            }).ToList();
        }

        public List<ProductResponseDTO> SearchByPrice(decimal minPrice, decimal maxPrice)
        {
            return context.products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).Select(p => new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU
            }).ToList();
        }

        public List<ProductResponseDTO> SortByPrice()
        {
            return context.products.OrderBy(p => p.Price).Select(p => new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU

            }).ToList();
            
        }

        public List<ProductResponseDTO> SortByName()
        {
            return context.products.OrderBy(p => p.Name).Select(p => new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU

            }).ToList();
        }

        public List<ProductResponseDTO> Pagination(int page, int pageSize)
        {
            return context.products.OrderBy(p => p.ProductId).Skip((page-1)*pageSize).Take(pageSize).Select(p=> new ProductResponseDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                Brand = p.Brand,
                SKU = p.SKU

            }).ToList();
        }


    }
}
