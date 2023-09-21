using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Telerik_Project15.Models;

namespace Telerik_Project15.Controllers
{
    public class DestinationViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Destination
        public ActionResult Index()
        {
            var destinations = db.DestinationViewModel;
            return View(destinations);
        }

        // GET: DestinationViewModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationViewModel destinationViewModel = await db.DestinationViewModel.FindAsync(id);
            if (destinationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(destinationViewModel);
        }

        // GET: DestinationViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinationViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,ImageUrl,Rating")] DestinationViewModel destinationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.DestinationViewModel.Add(destinationViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(destinationViewModel);
        }

        // GET: DestinationViewModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationViewModel destinationViewModel = await db.DestinationViewModel.FindAsync(id);
            if (destinationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(destinationViewModel);
        }

        // POST: DestinationViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,ImageUrl,Rating")] DestinationViewModel destinationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinationViewModel).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(destinationViewModel);
        }

        // GET: DestinationViewModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationViewModel destinationViewModel = await db.DestinationViewModel.FindAsync(id);
            if (destinationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(destinationViewModel);
        }

        // POST: DestinationViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DestinationViewModel destinationViewModel = await db.DestinationViewModel.FindAsync(id);
            db.DestinationViewModel.Remove(destinationViewModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    public class DestinationManagementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DestinationManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinationManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DestinationViewModel destinationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.DestinationViewModel.Add(destinationViewModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Destination");
            }

            return View(destinationViewModel);
        }

        // GET: DestinationManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DestinationViewModel destinationViewModel = db.DestinationViewModel.Find(id);

            if (destinationViewModel == null)
            {
                return HttpNotFound();
            }

            return View(destinationViewModel);
        }

        // POST: DestinationManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DestinationViewModel destinationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinationViewModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Destination");
            }

            return View(destinationViewModel);
        }

        // GET: DestinationManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DestinationViewModel destinationViewModel = db.DestinationViewModel.Find(id);

            if (destinationViewModel == null)
            {
                return HttpNotFound();
            }

            return View(destinationViewModel);
        }

        // POST: DestinationManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DestinationViewModel destinationViewModel = db.DestinationViewModel.Find(id);
            db.DestinationViewModel.Remove(destinationViewModel);
            db.SaveChanges();
            return RedirectToAction("Index", "Destination");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
