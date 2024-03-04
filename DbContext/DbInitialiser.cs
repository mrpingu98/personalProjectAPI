using System;
using System.IO.Pipelines;
using personalProjectAPI.Domains;

namespace personalProjectAPI.Db
{
    public static class DbInitialiser
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            PersonalProjectDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PersonalProjectDbContext>();
            if (!context.Product.Any())
            {
                context.AddRange
                (
                    new Product { Name = "Linkin Park ReAnimation", Description = "Perfection", Price = 999}
                );
            }

            context.SaveChanges();
        }
    }
}
