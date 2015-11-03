using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeaSideCodeChallenge.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public String firstName{get; set;}

        [Required]
        public String lastName { get; set; }

        public String username { get; set; }

        public String address { get; set; }

        public String state { get; set; }

        public String country { get; set; }
    }

    public class CustomerDBContext : DbContext
    {
        public DbSet<CustomerModel> Customers { get; set; }
    }
}