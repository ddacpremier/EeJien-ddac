using ddacWebFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ddacWebFinal.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Shipment> shipment = new List<Shipment>();

            using (Model1Container container = new Model1Container())
            {
                shipment = container.Shipments.ToList();
            }

            return View(shipment);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(addShipmentViewModel acvm)
        {
            var shipment = new Shipment();

            using (Model1Container container = new Model1Container())
            {
                shipment.departure = acvm.departure;
                shipment.destination = acvm.destination;
                shipment.date = acvm.date;
                shipment.weight = acvm.weight;
                shipment.status = acvm.status;

                container.Shipments.Add(shipment);
                container.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var shipment = new Shipment();

            using (Model1Container container = new Model1Container())
            {
                shipment = container.Shipments.Single(a => a.Id == id);
            }

            return View(shipment);
        }

        [HttpPost]
        public ActionResult Edit(Shipment obj)
        {
            var shipment = new Shipment();

            using (Model1Container container = new Model1Container())
            {
                shipment = container.Shipments.Single(a => a.Id == obj.Id);
                shipment.departure = obj.departure;
                shipment.destination = obj.destination;
                shipment.date = obj.date;
                shipment.weight = obj.weight;
                shipment.status = obj.status;

                container.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var shipment = new Shipment();

            using (Model1Container container = new Model1Container())
            {
                shipment = container.Shipments.Single(a => a.Id == id);

                container.Shipments.Remove(shipment);
                container.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}