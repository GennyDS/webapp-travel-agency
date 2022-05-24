using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.DATABASE;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PvUtenteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string? search)
        {

            List<PacchettoViaggio> pv = new List<PacchettoViaggio>();
            using (PVContext db = new PVContext())
            {

                // LOGICA PER RICERCARE le CARD CHE CONTENGONO NEL TITOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (search != null && search != "")
                {
                    pv = db.PacchettoViaggio.Where(pv => pv.nome.Contains(search) || pv.descrizione.Contains(search)).ToList<PacchettoViaggio>();
                }
                else
                {
                    pv = db.PacchettoViaggio.ToList<PacchettoViaggio>();
                }
            }

            return Ok(pv);

        }
    }

}