using AM.Core.Domain;
using AM.Core.Services;
using ExamDotNetAzizBenIsmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class PrestataireController : Controller
    {
        readonly IPrestataireService prestataireService;
        readonly IPrestationService PrestationService;

        public PrestataireController(IPrestataireService prestataireService, IPrestationService PrestationService) //injection de service
        {
            this.prestataireService = prestataireService;
            this.PrestationService = PrestationService;

        }

        // GET: PrestataireController
        public ActionResult Index()
        {
                return View(prestataireService.GetAll());
        }

        // GET: PrestataireController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PrestataireController/Create
        public ActionResult Create()
        {
            var Prestation = PrestationService.GetAll();
            //ViewBag => relation entre contr et la vue
            ViewBag.Planes = new SelectList(Prestation, "PrestataireFK");
            return View();
        }

        // POST: PrestataireController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestation p)
        {
            try
            {
                PrestationService.Add(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrestataireController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PrestataireController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PrestataireController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrestataireController/Delete/5
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
