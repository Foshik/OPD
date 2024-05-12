using Microsoft.AspNetCore.Mvc;
using OPD.DataBase.Products;

namespace OPD.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController: Controller
{
    private ProductBasketSerivce _productBasketSerivce;

    public ProductController(ProductBasketSerivce productBasketSerivce)
    {
        _productBasketSerivce = productBasketSerivce;
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
    {
        await _productBasketSerivce.AddProduct(productViewModel);
        return Ok();
    }
    [HttpDelete("Delete")]
    public async Task<IActionResult> CreateProduct(int id)
    {
        await _productBasketSerivce.RemoveProduct(id);
        return Ok();
    }
    [HttpPost("AddProductInBasket")]
    public async Task<IActionResult> AddProductInBasket(int productId)
    {
        string token = Request.Cookies["jwt"];
        await _productBasketSerivce.AddProductInBasket(productId,token);
        return Ok();
    }
    [HttpPost("DeleteProductInBasket")]
    public async Task<IActionResult> DeleteProductInBasket(int productId)
    {
        string token = Request.Cookies["jwt"];
        await _productBasketSerivce.AddProductInBasket(productId,token);
        return Ok();
    }
}