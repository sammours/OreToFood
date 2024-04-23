using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OreToFood.Models
{
    public class OdeToFoodDB : DbContext
    {
        public OdeToFoodDB() : base("name=Model1")
        {

        }
        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<RestuarantReview> RestuarantReviews { get; set; }
    }
}