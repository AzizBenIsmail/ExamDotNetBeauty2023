using AM.Core.Services;
using ExamDotNetAzizBenIsmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        readonly IFlightService flightService;

        public FlightController(IFlightService flightService) //injection de service
        {
            this.flightService = flightService;
        }

        // GET: FlightController
        public ActionResult Index(string filter)
        {
            if (string.IsNullOrEmpty(filter) )
                return View(flightService.GetAll());
            return View(flightService.GetAll().Where(f => f.Name.CompareTo(filter) == 0));
        }
        public ActionResult SortFlight()
        {

            return View("Index", flightService.SortFlights());
        }   
        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View(flightService.Get(id));
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight,IFormFile file)
        {
            flight.Image = file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", file.FileName);
                using (System.IO.Stream stream = new FileStream(path,
                FileMode.Create, FileAccess.ReadWrite))
                {
                    file.CopyTo(stream);
                }
            } 
            try
            {
                
                flightService.Add(flight);
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
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight)
        {
            try
            {
                flight.FlightId= id;    
                flightService.Update(flight);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index", flightService.GetAll());
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            flightService.Delete(flightService.Get(id));
            return View("Index", flightService.GetAll());
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
