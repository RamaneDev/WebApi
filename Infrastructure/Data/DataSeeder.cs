using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Infrastructure.Data
{
    public class DataSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetRequiredService<StoreContext>())
            {
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                await context.Database.EnsureCreatedAsync();

                try
                {
                    if (!context.ProductBrands.Any())
                    {
                        var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                        foreach (var item in brands)
                        {
                            context.ProductBrands.Add(item);
                        }

                        await context.SaveChangesAsync();
                    }

                    if (!context.ProductTypes.Any())
                    {
                        var TypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                        var types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                        foreach (var item in types)
                        {
                            context.ProductTypes.Add(item);
                        }

                        await context.SaveChangesAsync();
                    }

                    if (!context.Products.Any())
                    {
                        var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                        var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                        foreach (var item in products)
                        {
                            context.Products.Add(item);
                        }

                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex.Message);
                }

            }
        }
    }
}


