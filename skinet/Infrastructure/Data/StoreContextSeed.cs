
using System.Text.Json;
using Core.Entities;
using Infrastructue.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any()) // checking if there's already some products in the db
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");//getting the data from a jason file
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);// from a json format to a list
                context.ProductBrands.AddRange(brands); // from a list to db
            } 
            if (!context.ProductTypes.Any()) 
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types); 
            }

            if (!context.Products.Any()) 
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products); 
            } 
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();     
        
        }
    }
}