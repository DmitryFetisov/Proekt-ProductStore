using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Data.Interfaces;
using ProductStore.Data.Models;
using ProductStore.ViewModels;

namespace ProductStore.Controllers
{
    //Контроллер для страницы с магазинами
    public class StoresController : Controller
    {
        AppDBContext context;

        public StoresController(AppDBContext db)
        {
            
            context = db;
        }

        public IActionResult CreateStore()
        {
            return View();
        }

        public async Task<IActionResult> Grocery()
        {
            ViewBag.Title = "Страница Магазина";
            return View(await context.Stores.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(Store store)
        {
            context.Stores.Add(store);
            await context.SaveChangesAsync();
            return RedirectToAction("Grocery");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStore(int? id)
        {
            if (id != null)
            {
                Store store = new Store { StoreId = id.Value };
                context.Entry(store).State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return RedirectToAction("Grocery");
            }
            return NotFound();
        }

        public async Task<IActionResult> EditStore(int? storeid)
        {
            if (storeid != null)
            {
                Store? store = await context.Stores.FirstOrDefaultAsync(p => p.StoreId == storeid);
                if (store != null) return View(store);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditStore(Store store)
        {
            context.Stores.Update(store);
            await context.SaveChangesAsync();
            return RedirectToAction("Grocery");
        }

    }
}
    
    

