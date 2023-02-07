using ProductStore.Data.Models;
using ProductStore.Migrations;

namespace ProductStore.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {
            Store nicca = new Store { TitleName = "Ницца", Adress = "Адрес : ул. энтузиастов 8", };
            Store pyatachok = new Store { TitleName = "Пятачок", Adress = "Адрес : ул. Полбина 14" };
            context.Stores.AddRange(nicca, pyatachok);


            Product ananas = new Product { ProductsName = "Ананс", Desc = "Большие , спелые ананасы прямо из Португалии", Available = true, Price = 249 };
            Product bumaga = new Product { ProductsName = "Туалетная бумага", Desc = "4 слойная мягкая бумага", Available = true, Price = 55, };
            Product moloko = new Product { ProductsName = "Молоко", Desc = "Лебедянское молоко без консервантов , сухого молока,растительных жиров и ГМО", Available = true, Price = 99 };
            context.Products.AddRange(ananas,bumaga,moloko);

            
            context.SaveChangesAsync();

        }
       
    }

}
