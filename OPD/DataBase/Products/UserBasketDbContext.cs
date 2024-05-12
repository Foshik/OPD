using Microsoft.EntityFrameworkCore;

namespace OPD.DataBase.Products;

public class UserBasketDbContext 
{
    private readonly ApplicationDbContext _dbContext;

    public UserBasketDbContext(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(int productId,int userId)
    {
        var product =await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == productId);
        var basket =(await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == userId)).UserBasket;
        basket.Products.Add(product);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Remove(int productId,int userId)
    {
        var product =await _dbContext.Products.FirstOrDefaultAsync(c => c.Id == productId);
        var basket =(await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == userId)).UserBasket;
        basket.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
   
    public async Task<UserBasket> GetUserBasketById(int id)
    {
        return (await _dbContext.Users.FirstOrDefaultAsync(b => b.Id == id)).UserBasket;
    }
    

   
}