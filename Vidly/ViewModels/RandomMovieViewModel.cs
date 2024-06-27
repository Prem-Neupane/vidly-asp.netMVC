using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    
    public class RandomMovieViewModel
    {
        public List<Movie> Movies { get; set; }

        //public List<Customer> Customers { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public Customer Customer;
    }
}