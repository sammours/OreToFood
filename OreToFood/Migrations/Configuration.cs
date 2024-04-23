namespace OreToFood.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OreToFood.Models.OdeToFoodDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OreToFood.Models.OdeToFoodDB";
        }

        protected override void Seed(OreToFood.Models.OdeToFoodDB context)
        {
            context.Restuarants.AddOrUpdate(
                r => r.Name,
                new Restuarant { Name = "chic1", City = "Chicago", Country = "USA"},
                new Restuarant { Name = "karls1", City = "Karlsruhe", Country = "Germany" },
                new Restuarant { Name = "stutt1", City = "Stuttgart", Country = "Germany",
                    Reviews = new List<RestuarantReview> { new RestuarantReview { Rating = 9, Body = "Great!", ReviewerName="Samy" } }
                }
                );

            for(int i = 1; i<= 1000; i++)
            {
                context.Restuarants.AddOrUpdate(r => r.Name,
                    new Restuarant { Name = "Res" + i, City = "City" + i, Country = "Germany" + i });
            }
        }
    }
}
