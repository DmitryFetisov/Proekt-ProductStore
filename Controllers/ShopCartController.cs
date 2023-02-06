using Microsoft.AspNetCore.Mvc;
using ProductStore.Data.Interfaces;
using ProductStore.Data.Models;
using ProductStore.Data.Repository;
using ProductStore.ViewModels;

namespace ProductStore.Controllers
{
    //Контроллер для корзины заказов
    public class ShopCartController : Controller
    {
        private readonly IAllProducts productint;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllProducts productint, ShopCart shopCart)
        {
            this.productint = productint;
            this.shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = shopCart.GetShoppingCarts();
            shopCart.listShopingcart = items;
            return View();
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = productint.Products.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                shopCart.AddToCart(item);

            }
            return RedirectToAction("Index");
        }
    }
}
