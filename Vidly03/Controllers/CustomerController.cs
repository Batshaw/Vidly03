using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly03.Models;
using System.Data.Entity;
using Vidly03.ViewModels;

namespace Vidly03.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipTypes).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]      // make sure it should only be call by http post.
        [ValidateAntiForgeryToken]      // Prevent Cross-site Request Forgery (CSRF)
        public ActionResult Save(Customers customers)       // use this method to create and edit a customer
        {                                                   // if the id == 0, create new customer, else edit the data of the customer
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("New", viewModel);
            }
            if (customers.Id == 0)
                _context.Customers.Add(customers);
            else
            {
                var customerInDbase = _context.Customers.Single(c => c.Id == customers.Id);
                customerInDbase.Name = customers.Name;
                customerInDbase.Id = customers.Id;
                customerInDbase.IsSubcribedToNewsletter = customers.IsSubcribedToNewsletter;
                customerInDbase.MembershipTypesId = customers.MembershipTypesId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes
            };
            
            return View("New", viewModel);
        }
    }
}