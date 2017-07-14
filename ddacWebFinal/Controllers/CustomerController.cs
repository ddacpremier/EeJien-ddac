using ddacWebFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddacWebFinal.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Customer> customer = new List<Customer>();

            using (Model1Container container = new Model1Container())
            {
                customer = container.Customers.ToList();
            }

            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(addCustomerViewModel acvm)
        {
            var customer = new Customer();

            using (Model1Container container = new Model1Container())
            {
                customer.businesstype = acvm.businesstype;
                customer.companyname = acvm.companyname;
                customer.country = acvm.country;

                container.Customers.Add(customer);
                container.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = new Customer();

            using (Model1Container container = new Model1Container())
            {
                customer = container.Customers.Single(a => a.Id == id);
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer obj)
        {
            var customer = new Customer();

            using (Model1Container container = new Model1Container())
            {
                customer = container.Customers.Single(a => a.Id == obj.Id);
                customer.businesstype = obj.businesstype;
                customer.companyname = obj.companyname;
                customer.country = obj.country;

                container.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = new Customer();

            using (Model1Container container = new Model1Container())
            {
                customer = container.Customers.Single(a => a.Id == id);

                container.Customers.Remove(customer);
                container.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}