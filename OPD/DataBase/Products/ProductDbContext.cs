using Microsoft.EntityFrameworkCore;


namespace OPD.DataBase.Products
{
    public class ProductDbContext
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductDbContext(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateProduct(ProductViewModel productViewModel)
        {
            Product product = new Product(productViewModel.Name,productViewModel.Price,productViewModel.Quantity,productViewModel.Description);
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return "Product created successfully";
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<string> UpdateProduct(int id, Product updatedProduct)
        {
            var product = await GetProductById(id);
            if (product == null)
            {
                return "Product not found";
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return "Product updated successfully";
        }

        public async Task<string> DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product == null)
            {
                return "Product not found";
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return "Product deleted successfully";
        }
    }
}