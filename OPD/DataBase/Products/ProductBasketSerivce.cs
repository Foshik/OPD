using OPD.DataBase.Users;

namespace OPD.DataBase.Products;

public class ProductBasketSerivce
{
    private readonly UserDbContext _userDbContext;

    private UserBasketDbContext _userBasketDbContext;
    private ProductDbContext _productDbContext;

    public ProductBasketSerivce(UserBasketDbContext userBasketDbContext, ProductDbContext productDbContext,UserDbContext userDbContext)
    {
        _productDbContext = productDbContext;
        _userBasketDbContext = userBasketDbContext;
        _userDbContext = userDbContext;
    }

    public async Task AddProduct(ProductViewModel productViewModel)
    {
        await _productDbContext.CreateProduct(productViewModel);
    }

    public async Task RemoveProduct(int id)
    {
        await _productDbContext.DeleteProduct(id);
    }

    public async Task AddProductInBasket(int productId, string token)
    {
        var userId = (await _userDbContext.GetUserFromToken(token)).Id;
        await _userBasketDbContext.Add(productId, userId);
    }
    public async Task RemoveProductInBasket(int productId, string token)
    {
        var userId = (await _userDbContext.GetUserFromToken(token)).Id;
        await _userBasketDbContext.Remove(productId, userId);
    }
}