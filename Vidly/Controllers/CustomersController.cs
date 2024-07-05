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

        public ViewResult New()
        {
            var membershipsTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipsTypes,
                Customer = new Customer()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == id);
            if (customer == null) return HttpNotFound();

            var membershipsTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipsTypes,
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(p => p.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                //customerInDb.IsDelinquent = customer.IsDelinquent;
                // TryUpdateModel(customerInDb, "", new [] { nameof(customerDto.Name), nameof(customerDto.Birthdate), nameof(customerDto.MembershipTypeId), nameof(customerDto.IsSubscribedToNewsLetter) });
                // TryUpdateModel(customerInDb, "", new [] { "Name", "Birthdate", "MembershipTypeId", "IsSubscribedToNewsLetter" });
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}