using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class ClientController : Controller
    {
        IServiceClient sc;
        IServiceConseiller sco;
        public ClientController(IServiceClient sc, IServiceConseiller sco)
        {
            this.sc = sc;
            this.sco = sco;
        }
        // GET: ClientController
        public ActionResult Index(string? login)
        {
            if (login == null)
                return View(sc.GetAll());
            else
                return View(sc.GetMany(c => c.Login.Equals(login)));
            
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View(sc.GetById(id));
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.ConseillerFK = new SelectList(sco.GetAll(), "ConseillerId", "ConseillerId");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client collection, IFormFile Photo)
        {
            try
            {
                //sauvegarder l'image sous uploads
                if (Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),

                    "wwwroot", "uploads", Photo.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    Photo.CopyTo(stream);
                    collection.Photo = Photo.FileName;
                }
                sc.Add(collection);
                sc.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
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

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
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
