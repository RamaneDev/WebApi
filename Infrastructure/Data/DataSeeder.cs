using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataSeeder
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = serviceProvider.GetRequiredService<StoreContext>())
            {
                await dbContext.Database.EnsureDeletedAsync();

                await dbContext.Database.MigrateAsync();

                if (!dbContext.Products.Any())
                {
                    var product_List = new List<Product>()
                    {
                        new Product()
                        {

                            Name = "computer"
                        },
                        new Product()
                        {

                            Name = "mouse"
                        },
                        new Product()
                        {

                            Name = "cental unit"
                        },
                        new Product()
                        {

                            Name = "Monitor"
                        },
                        new Product()
                        {

                            Name = "cable"
                        },

                    };
                    dbContext.Products.AddRange(product_List);
                    dbContext.SaveChanges();
                }

            }
        }
    }
}


