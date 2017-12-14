using MVC5App.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5App.ViewModel;

namespace MVC5App.Controllers
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
            //var customers = Getcustomers();
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id) {
            //var customers = Getcustomers().SingleOrDefault(c => c.Id == id);
            var customers = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();
            return View(customers);
        }
        public ActionResult AddNew() {
            var MemberShips = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MemberShipTypes = MemberShips
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel{
                    Customer = customer,
                    MemberShipTypes = _context.MembershipType.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id==0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var customerView = new CustomerFormViewModel() {
                Customer = customer,
                MemberShipTypes = _context.MembershipType.ToList()
            };

            return View("CustomerForm", customerView);
        }
        //private IEnumerable<Customer> Getcustomers() {
        //    return new List<Customer> {
        //        new Customer{Id = 1, Name = "Customer1"},
        //        new Customer{Id = 2, Name = "Customer2"}
        //    };
        //}
    }
}