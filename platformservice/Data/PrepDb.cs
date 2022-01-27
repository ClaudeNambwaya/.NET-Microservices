using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using platformservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScop = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScop.ServiceProvider.GetRequiredService<AppDbContext>());
            }
        }
               

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                new Platform() { Name="Dot Net", Publisher="Microsoft", Cost="Free"},
                new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kubernetres", Publisher = "Cloud Native Computing", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }

    }
}
