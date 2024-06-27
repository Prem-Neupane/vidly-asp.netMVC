using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Net.Mime;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
    private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext(); 
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index() 
        {
            //var customers = new List<Customer>
            //{
            //    new Customer {Name = "Customer1" },
            //    new Customer { Name = "Customer2"}
            //};

            //var viewModel = new RandomMovieViewModel
            //{
            //    Customers = customers
            //}; 
            //return View(viewModel);

            //var customers = _context.Customers.Include(p => p.MembershipType).ToList();
            var viewModel = new RandomMovieViewModel
            {
                Customers = _context.Customers.Include(p => p.MembershipType).ToList()
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(p => p.MembershipType).SingleOrDefault(p => p.Id == id);
            if (customer == null) return HttpNotFound();

            return View(customer);
        }
    }
}