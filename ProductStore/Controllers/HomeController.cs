using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Data.Interfaces;
using ProductStore.Data.Models;
using ProductStore.ViewModels;


namespace ProductStore.Controllers
{
    //Контроллер для домашней стринцы со всеми продуктами
    public class HomeController :Controller
    {
        AppDBContext context;
        private readonly IAllProducts allProducts;
        private readonly IProductsStore productsStore;

        public HomeController(AppDBContext db, IAllProducts allProducts, IProductsStore productsStore)
        {
            this.allProducts = allProducts;
            this.productsStore = productsStore;
            context = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Страница с продуктами";
            
            return View(await context.Products.Include(i => i.Stores)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = new Product { Id = id.Value };
                context.Entry(product).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product? product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null) return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
