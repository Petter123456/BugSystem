using BugSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BugSystem.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<BugsContext>());
            }
        }

        public static void SeedData(BugsContext context)
        {
            System.Console.WriteLine("Appling Migration...");
            context.Database.Migrate();

            if (!context.Bugs.Any())
            {
                context.Bugs.AddRange(
                 new BugModel { Description = "no Image", Status = false, Id = Guid.NewGuid() },
                 new BugModel { Description = "no price", Status = false, Id = Guid.NewGuid() },
                 new BugModel { Description = "no name", Status = false, Id = Guid.NewGuid() }
                );
                context.SaveChanges(); 
            }            
        }
    }
}
