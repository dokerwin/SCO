using SCO.ProductService.Domain.Entities;

namespace SCO.ProductService.EntityFramework.Seed;

public class ProductSeeder
{
    public static IEnumerable<Product> GetProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e0"),
                Barcode = "ABC-abc-1229",
                Name = "Fanta without suggar",
                ShortName = "Fanta Zero",
                CategoryId = Guid.Parse("712228de-18de-4c4c-a2ea-7858b9fe8c2f"),
                Price = 1.50,
                VatId = Guid.Parse("59227363-61dc-43c1-bd3b-90309d2333a6"),
                ProductTypeId =  Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e4"),
                ProductOwnerId = Guid.Parse("8b64dc6b-c521-4e0a-a578-daf410b0a123"),
            },
            new Product()
            {
                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e1"),
                Barcode = "ABC-abc-1230",
                Name = "Coca-Cola without suggar",
                ShortName = "Cola Zero",
                CategoryId = Guid.Parse("712228de-18de-4c4c-a2ea-7858b9fe8c2f"),
                Price = 1.50,
                VatId = Guid.Parse("59227363-61dc-43c1-bd3b-90309d2333a6"),
                ProductTypeId =  Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e4"),
                ProductOwnerId = Guid.Parse("8b64dc6b-c521-4e0a-a578-daf410b0a123"),
            },
            new Product()
            {
                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e2"),
                Barcode = "ABC-abc-1231",
                Name = "Apples Ligol",
                ShortName = "Ligol apple",
                CategoryId = Guid.Parse("5f2f1f9b-5da0-4a7f-b963-9b7a4af19c6d"),
                Price = 1,
                VatId = Guid.Parse("59227363-61dc-43c1-bd3b-90309d2333a6"),
                ProductTypeId = Guid.Parse("9f8c3920-b559-47b7-a9d1-f595a823df13"),
                ProductOwnerId = Guid.Parse("8b64dc6b-c521-4e0a-a578-daf410b0a123"),
            },
            new Product()
            {
                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e3"),
                Name = "Short cucumber",
                ShortName = "Cucumber",
                Barcode = "ABC-abc-1232",
                CategoryId = Guid.Parse("daa8cb2e-64db-49e6-ae5a-e1e4f012fb97"),
                Price = 7.50,
                VatId = Guid.Parse("59227363-61dc-43c1-bd3b-90309d2333a6"),
                ProductTypeId = Guid.Parse("9f8c3920-b559-47b7-a9d1-f595a823df13"),
                ProductOwnerId = Guid.Parse("8b64dc6b-c521-4e0a-a578-daf410b0a123")
            }
        };
    }


    public static IEnumerable<ProductType> GetProductTypes()
    {
        return new List<ProductType>()
        {
            new ProductType()
            {
                Id = Guid.Parse("36dc193f-d101-43d5-8449-28c268a115e4"),
                TypeName = "Wet",
            },
            new ProductType()
            {
                Id = Guid.Parse("9f8c3920-b559-47b7-a9d1-f595a823df13"),
                TypeName = "Dry",
            }
        };
    }

    public static IEnumerable<Category> GetCategories()
    {
        return new List<Category>()
        {
            new Category()
            {
                Id = Guid.Parse("5f2f1f9b-5da0-4a7f-b963-9b7a4af19c6d"),
                Name = "Fruits",
            },
            new Category()
            {
                 Id = Guid.Parse("daa8cb2e-64db-49e6-ae5a-e1e4f012fb97"),
                Name = "Vegetables",
            },
            new Category()
            {
                 Id = Guid.Parse("712228de-18de-4c4c-a2ea-7858b9fe8c2f"),
                Name = "Drinks", 
            },
            new Category()
            {
                 Id = Guid.Parse("f3e60156-2e8f-4447-b43c-1ebf18b74183"),
                Name = "Meat",
            },
            new Category()
            {
                Id = Guid.Parse("2b536c22-4f6d-45e0-ae68-8db1b0a91193"),
                Name = "Сereal",
            },
        };
    }

    public static IEnumerable<ProductOwner> GetProductOwners()
    {
        return new List<ProductOwner>()
        {
            new ProductOwner()
            {
                Id = Guid.Parse("8b64dc6b-c521-4e0a-a578-daf410b0a123"),
                Name = "Station",
            },
            new ProductOwner()
            {
                Id = Guid.Parse("0ec72b34-34ef-4ffb-b2ed-00dbfb6eb7ef"),
                Name = "Supplier",
            }
        };
    }
    public static IEnumerable<Vat> GetVats()
    {
        return new List<Vat>()
        {
            new Vat()
            {
                Id = Guid.Parse("59227363-61dc-43c1-bd3b-90309d2333a6"),
                Name = "Standard rate",
                Percent = 23

            },
            new Vat()
            {   
                Id = Guid.Parse("2274546e-5c28-4769-9d83-376340e3d07f"),
                Name = "Reduced rates",
                Percent = 5
            },
            new Vat()
            {   
                Id = Guid.Parse("8b6fdbb4-3049-4cdf-b730-03e0fb8b3a99"),
                Name = "Zero rate",
                Percent = 0
            }
        };
    }
}