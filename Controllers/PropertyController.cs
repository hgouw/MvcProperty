using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProperty.Models;

namespace MvcProperty.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyDBContext db = new PropertyDBContext();

        //
        // GET: /Property/

        public ActionResult Index()
        {
            return View(db.Properties.ToList());
        }

        //
        // GET: /Property/Details/5

        public ActionResult Details(string street = null, string number = null, string suburb = null, string state = null, string postcode = null)
        {
            Property property = db.Properties.Find(street, number, suburb, state, postcode);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        //
        // GET: /Property/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Property/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(property);
        }

        //
        // GET: /Property/Edit/5

        public ActionResult Edit(string street = null, string number = null, string suburb = null, string state = null, string postcode = null)
        {
            Property property = db.Properties.Find(street, number, suburb, state, postcode);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        //
        // POST: /Property/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(property);
        }

        //
        // GET: /Property/Delete/5

        public ActionResult Delete(string street = null, string number = null, string suburb = null, string state = null, string postcode = null)
        {
            Property property = db.Properties.Find(street, number, suburb, state, postcode);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        //
        // POST: /Property/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string street = null, string number = null, string suburb = null, string state = null, string postcode = null)
        {
            Property property = db.Properties.Find(street, number, suburb, state, postcode);
            db.Properties.Remove(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}