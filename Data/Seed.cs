using CityPharmacyAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CityPharmacyAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!await roleManager.RoleExistsAsync(AppRole.Admin))
                    await roleManager.CreateAsync(new AppRole { Name = AppRole.Admin });
                if (!await roleManager.RoleExistsAsync(AppRole.Staff))
                    await roleManager.CreateAsync(new AppRole { Name = AppRole.Staff });   

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "brayljamesamaquin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "Brayl_James",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        FirstName = "Brayl James",
                        LastName = "Amaquin",
                        DateJoined = DateTime.Now
                    };
                    await userManager.CreateAsync(newAdminUser, "Amaquin123!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string staffEmail = "nedreygolosino@gmail.com";

                var appUser = await userManager.FindByEmailAsync(staffEmail);
                if (appUser == null)
                {
                    var newCustomerUser = new AppUser()
                    {
                        UserName = "Ned_Golosno",
                        Email = staffEmail,
                        EmailConfirmed = true,
                        FirstName = "Nedrey",
                        LastName = "Golosno",
                        DateJoined = DateTime.Now
                    };
                    await userManager.CreateAsync(newCustomerUser, "Golosino123!");
                    await userManager.AddToRoleAsync(newCustomerUser, UserRoles.Staff);
                }

                string sellerUserEmail = "seller@gmail.com";          
            }
        }

        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder.ApplicationServices
               .CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Cetaphil Gentle Skin Cleanser",
                        Manufacturer = "Galderma",
                        Category = "Skincare",
                        Description = "A gentle, soap-free cleanser for sensitive skin.",
                        DirectionsForUse = "Apply to wet skin, massage gently, and rinse.",
                        WarningsPrecautions = "For external use only. Avoid contact with eyes.",
                        PackagingSize = "500 ml",
                        Price = 599.99m,
                        StorageConditions = "Store at room temperature.",
                        StorageLocation = "Aisle A Rack B Shelf 1",
                        Image = "https://lyskin.com/wp-content/uploads/2022/08/LySkin-Cetaphil-gentle-skin-cleanser-for-sensitive-or-dry-skin-237ml-8-fl.oz-CET00005.webp",
                        Quantity = 60
                    },
                    new Product
                    {
                        Name = "Gatorade Thirst Quencher",
                        Manufacturer = "PepsiCo",
                        Category = "Sports Drinks",
                        Description = "A refreshing sports drink to hydrate and replenish electrolytes during physical activity.",
                        DirectionsForUse = "Consume during or after exercise to replenish fluids and electrolytes.",
                        WarningsPrecautions = "Keep out of reach of children. Not suitable for individuals with certain medical conditions.",
                        PackagingSize = "591 ml",
                        Price = 69.99m,
                        StorageConditions = "Store in a cool, dry place.",
                        StorageLocation = "Aisle A Rack B Shelf 1",
                        Image = "https://i5.walmartimages.com/seo/Gatorade-Thirst-Quencher-Cool-Blue-Sports-Drinks-20-fl-oz-Bottle_87c0e278-748f-4c87-a4a5-63f3bf89146d.10cc699d48882d535c7c3cda5b2eb3de.jpeg",
                        Quantity = 1
                    },
                    new Product
                    {
                        Name = "Neutrogena Hydro Boost Water Gel Moisturizer",
                        Manufacturer = "Johnson & Johnson",
                        Category = "Skincare",
                        Description = "A hydrating water gel moisturizer for dry skin.",
                        DirectionsForUse = "Apply evenly to face and neck after cleansing.",
                        WarningsPrecautions = "For external use only. Avoid contact with eyes.",
                        PackagingSize = "50 ml",
                        Price = 390.99m,
                        StorageConditions = "Store in a cool, dry place.",
                        StorageLocation = "Aisle A Rack B Shelf 1",
                        Image = "https://ph-test-11.slatic.net/p/b2ab69155156bd29f87a5ab38f97e57f.jpg",
                        Quantity = 1
                    },
                    new Product
                    {
                        Name = "Colgate Total Advanced Toothpaste",
                        Manufacturer = "Colgate-Palmolive",
                        Category = "Oral Care",
                        Description = "An advanced toothpaste for whole mouth health.",
                        DirectionsForUse = "Brush thoroughly at least twice a day.",
                        WarningsPrecautions = "Keep out of reach of children under 6 years of age.",
                        PackagingSize = "100 g",
                        Price = 140.99m,
                        StorageConditions = "Store in a cool, dry place.",
                        StorageLocation = "Aisle A Rack B Shelf 1",
                        Image = "https://blueberrymart.net/cdn/shop/products/Colgate-Total-Advanced-Health-Toothpaste-120G.jpg?v=1673263769",
                        Quantity = 1
                    },
                    new Product
                    {
                        Name = "Nivea Sun Protect & Moisture Sunscreen SPF 50",
                        Manufacturer = "Beiersdorf",
                        Category = "Skin Care",
                        Description = "A sunscreen lotion with SPF 50 for broad spectrum sun protection.",
                        DirectionsForUse = "Apply liberally and evenly to all exposed areas of skin.",
                        WarningsPrecautions = "Avoid prolonged exposure to the sun, even while using a sunscreen product.",
                        PackagingSize = "200 ml",
                        Price = 120.49m,
                        StorageConditions = "Store below 25°C.",
                        StorageLocation = "Aisle A Rack B Shelf 1",
                        Image = "https://static.beautytocare.com/cdn-cgi/image/width=1600,height=1600,f=auto/media/catalog/product//n/i/nivea-sun-protect-moisture-lotion-spf50-200ml.jpg",
                        Quantity = 1
                    }

                );
                context.SaveChanges();
            }

            if (!context.Medicines.Any())
            {
                context.Medicines.AddRange(
                    new Medicine
                    {
                        Name = "Paracetamol",
                        BrandName = "Biogesic",
                        GenericName = "Paracetamol",
                        Manufacturer = "Unilab",
                        NationalDrugCode = "123456789",
                        Description = "Pain reliever and fever reducer.",
                        Strength = "500 mg",
                        DosageForm = "Tablet",
                        PackagingSize = "10 tablets",
                        PackagingType = "Bottle",
                        TherapeuticIndications = "Headache, fever, muscle aches",
                        IntendedUse = "Relief of mild to moderate pain and fever.",
                        Price = 100m,
                        StorageConditions = "Store at room temperature.",
                        StorageLocation = "Aisle A Rack B Shelf 1",
                        Image = "https://api.watsons.com.ph/medias/prd-front-10098317.jpg?context=bWFzdGVyfGltYWdlc3w4ODcxMzF8aW1hZ2UvanBlZ3xhREExTDJnd01pODVNVFF3TXpJMk9ESTJNREUwTDFkVVExQklMVEV3TURrNE16RTNMV1p5YjI1MExtcHdad3xkODQ4NGI0Mzg0MTY2NGFlOTRmZTVjNDUxMGZiNjRlYWE4YWZlNzdhYzFlMWRkZDI0ZDkwYTI1YjhkNjg2ZDBi",
                        Quantity = 60
                    },
                    new Medicine
                    {
                        Name = "Ibuprofen",
                        BrandName = "Advil",
                        GenericName = "Ibuprofen",
                        Manufacturer = "Pfizer",
                        NationalDrugCode = "987654321",
                        Description = "Nonsteroidal anti-inflammatory drug (NSAID).",
                        Strength = "200 mg",
                        DosageForm = "Tablet",
                        PackagingSize = "50 tablets",
                        PackagingType = "Bottle",
                        TherapeuticIndications = "Pain, inflammation, fever",
                        IntendedUse = "Relief of pain, inflammation, and fever.",
                        Price = 150m,
                        StorageConditions = "Store at room temperature.",
                        StorageLocation = "Aisle A Rack B Shelf 2",
                        Image = "https://mimsshst.blob.core.windows.net/drug-resources/PH/packshot/Advil6001PPS0.JPG",
                        Quantity = 40
                    },
                    new Medicine
                    {
                        Name = "Aspirin",
                        BrandName = "Bayer",
                        GenericName = "Aspirin",
                        Manufacturer = "Bayer",
                        NationalDrugCode = "112233445",
                        Description = "Pain reliever, anti-inflammatory, and antipyretic.",
                        Strength = "325 mg",
                        DosageForm = "Tablet",
                        PackagingSize = "100 tablets",
                        PackagingType = "Bottle",
                        TherapeuticIndications = "Pain, inflammation, fever, cardiovascular protection",
                        IntendedUse = "Relief of pain, inflammation, and fever; cardiovascular protection.",
                        Price = 200m,
                        StorageConditions = "Store at room temperature.",
                        StorageLocation = "Aisle A Rack B Shelf 3",
                        Image = "https://southstardrug.com.ph/cdn/shop/products/33644_800x.jpg?v=1667352444",
                        Quantity = 30
                    },
                    new Medicine
                    {
                        Name = "Cetirizine",
                        BrandName = "Zyrtec",
                        GenericName = "Cetirizine",
                        Manufacturer = "Johnson & Johnson",
                        NationalDrugCode = "556677889",
                        Description = "Antihistamine for allergy relief.",
                        Strength = "10 mg",
                        DosageForm = "Tablet",
                        PackagingSize = "30 tablets",
                        PackagingType = "Bottle",
                        TherapeuticIndications = "Allergic rhinitis, urticaria",
                        IntendedUse = "Relief of allergy symptoms such as runny nose, sneezing, and itching.",
                        Price = 120m,
                        StorageConditions = "Store at room temperature.",
                        StorageLocation = "Aisle A Rack B Shelf 4",
                        Image = "https://m.media-amazon.com/images/I/712A8IGjooL._AC_SL1500_.jpg",
                        Quantity = 50
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
