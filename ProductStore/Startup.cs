

using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Data.Interfaces;
using ProductStore.Data.Models;
using ProductStore.Data.Repository;

namespace ProductStore
{
    public class Startup
    {
        private IConfigurationRoot _config;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _config = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("./dbsettings.json").Build();
        }
        //Подключаем сервисы
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProducts, ProductRepository>();
            services.AddTransient<IProductsStore, StoreRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));


            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        //работа с методами расширения
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();


            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(context);
            }
        }
    }
}
