using Microsoft.EntityFrameworkCore;

namespace ProductStore.Data.Models
{
    //реализация корзины 
    public class ShopCart
    {
        public Product Product { get; set; }
        private readonly AppDBContext appDbContent;
        public ShopCart(AppDBContext appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShoppingCart>? listShopingcart { get; set; }
       //проверяем добавлялись ли товары в корзину,если да то добавляем в эту же корзину,если нет создаем новую
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var content = service.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart(content) { ShopCartId = shopCartId };
        }
        //Добавление товара в корзину
        public void AddToCart(Product product)
        {
            appDbContent.shoppingCarts.Add(new ShoppingCart
            {
                ShoppingCartId = ShopCartId,
                Product = product,
                Price = product.Price
            });
            appDbContent.SaveChangesAsync();
        }
        //возвращаем все товары в корзине 
        public List<ShoppingCart> GetShoppingCarts()
        {
            return appDbContent.shoppingCarts.Where(c => c.ShoppingCartId == ShopCartId).Include(c => c.Product).ToList();
        }
        
    }
}
