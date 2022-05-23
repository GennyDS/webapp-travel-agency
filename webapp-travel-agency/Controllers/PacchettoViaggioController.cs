using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.DATABASE;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class PacchettoViaggioController : Controller
    {
        [HttpGet] 
        public IActionResult Index()
        {

            using (PVContext db = new PVContext())
            {
                List<PacchettoViaggio> pv= new List<PacchettoViaggio>();
                pv = db.PacchettoViaggio.ToList<PacchettoViaggio>();
                return View("Admin", pv );
            }
        }



        //---------------------------------------------------------


        [HttpGet]
        public IActionResult Dettagli(int id)
        {


                PacchettoViaggio? pvFound = null;
                using (PVContext db = new PVContext())
                {
                    pvFound = db.PacchettoViaggio
                        .Where(PacchettoViaggio => PacchettoViaggio.Id == id)
                        .FirstOrDefault();


                }

                if (pvFound != null)
                {
                    return View("DettagliADMIN", pvFound);
                }
                else
                {
                    return NotFound("Il Viaggio con id " + id + " non è stato trovato");
                }
        }



        //---------------------------------------------------------


        [HttpGet]
        public IActionResult Create()
        {
            return View("CreaADMIN");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacchettoViaggio nuovoViaggio)
        {
            if (!ModelState.IsValid)
            {
                return View("CreaADMIN", nuovoViaggio);
            }

            using (PVContext db = new PVContext())
            {


             PacchettoViaggio viaggioDaCreare = new PacchettoViaggio(nuovoViaggio.nome, nuovoViaggio.prezzo, nuovoViaggio.descrizione, nuovoViaggio.img );

                db.PacchettoViaggio.Add(viaggioDaCreare);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        //---------------------------------------------------------


        [HttpGet]
        public IActionResult Modifica(int id)
        {

            PacchettoViaggio? pvFound = null;
            using (PVContext db = new PVContext())
            {
                pvFound = db.PacchettoViaggio
                    .Where(pv => pv.Id == id)
                    .FirstOrDefault();


            }

            if (pvFound == null)
            {
                return NotFound();
            }
            else
            {
                return View("ModificaADMIN", pvFound);
            }
           

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modifica(int id, PacchettoViaggio model)
        {

            if (!ModelState.IsValid)
            {
                return View("ModificaADMIN", model);
            }
            PacchettoViaggio? pvToEdit = null;
            using (PVContext db = new PVContext())
            {
                pvToEdit = db.PacchettoViaggio
                   .Where(pv => pv.Id == id)
                   .FirstOrDefault();

                if (pvToEdit != null)
                {
                    pvToEdit.nome = model.nome;
                    pvToEdit.descrizione = model.descrizione;
                    pvToEdit.img = model.img;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

        }
        //---------------------------------------------------------


        

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            using (PVContext db = new PVContext())
            {
                PacchettoViaggio? pvToDelete = db.PacchettoViaggio
                    .Where(pv => pv.Id == id)
                    .FirstOrDefault();

                if (pvToDelete != null)
                {
                    db.PacchettoViaggio.Remove(pvToDelete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
