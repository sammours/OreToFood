using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OreToFood.Models
{
    public class Restuarant
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public virtual ICollection<RestuarantReview> Reviews { get; set; }  

    }
}