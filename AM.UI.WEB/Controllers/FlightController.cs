using AM.Applicationcore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.Applicationcore.Domain;
using AM.Applicationcore.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private IServiceFlight serviceFlight;
        private IServicePlane servicePlane;

        public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }
        // GET: FlightController
        //public ActionResult Index(string destination)
        //{
        //    var list = serviceFlight.GetAll().ToList();
        //    if (destination != null)
        //    {
        //        list = list.Where(x => x.Destination.Contains(destination)).ToList();
        //    }
        //    return View(list);
        //}
        public ActionResult Sort()
        {
            return View("Index", serviceFlight.SortFlights());
        }
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
                return View(serviceFlight.GetAll().ToList());
            else
                return
                View(serviceFlight.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }
        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.Planes = 
                new SelectList(servicePlane.GetAll().ToList(),
                "PlaneId", "Information");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection, IFormFile piloteFile)
        {
            try
            {
                if (piloteFile != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", piloteFile.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    piloteFile.CopyTo(stream);
                    collection.Pilote = piloteFile.FileName;
                }
                serviceFlight.Add(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }


        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = serviceFlight.GetById(id);
            ViewBag.Planes = new SelectList(servicePlane.GetAll(), "PlaneId", "Information");

            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                serviceFlight.Update(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
                serviceFlight.Delete(collection);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
