using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApplication1.Models
{
    public class PropertyDBContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
    }

    public class Property
    {
        [Key, Column(Order = 1)]
        public string Street { get; set; }
        [Key, Column(Order = 2)]
        public string Number { get; set; }
        [Key, Column(Order = 3)]
        public string Suburb { get; set; }
        [Key, Column(Order = 4)]
        public string State { get; set; }
        [Key, Column(Order = 5)]
        public string Postcode { get; set; }
        public byte Type { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
    }
}