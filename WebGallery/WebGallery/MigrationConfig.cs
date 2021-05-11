using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGallery.Constants;
using WebGallery.Entities;
using WebGallery.Entities.Data;
using WebGallery.Entities.Identity;

namespace WebGallery
{
    public static class MigrationConfig
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var context = serviceScope.ServiceProvider.GetRequiredService<EFDataContext>();

                if (!roleManager.Roles.Any())
                {
                    var role = new AppRole
                    {
                        Name = Roles.Admin
                    };
                    var result = roleManager.CreateAsync(role).Result;
                }
            
                if (!context.Cars.Any())
                {
                    var cars = new List<Car>()
                    {
                        new Car
                        {
                            Mark = "Ford",
                            Model = "Thunderbird",
                            Year = 2021,
                            Fuel = "Бензин",
                            Capacity = 5.7F,
                            Image = "2021-Ford-Thunderbird-Rebord.jpg"
                        },
                        new Car
                        {
                            Mark = "Tesla",
                            Model = "ModelX",
                            Year = 2021,
                            Fuel = "Електро",
                            Capacity = 0.0F,
                            Image = "tesla-model-x-2021.jpg"
                        },
                        new Car
                        {
                            Mark = "Audi",
                            Model = "Q8",
                            Year = 2021,
                            Fuel = "Бензин",
                            Capacity = 4.2F,
                            Image = "Q8.jpg"
                        }
                    };
                    context.Cars.AddRange(cars);
                    context.SaveChanges();
                }
            }
        }
    }
}
