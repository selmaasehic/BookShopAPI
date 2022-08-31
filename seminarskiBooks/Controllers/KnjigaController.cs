using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using seminarskiBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace seminarskiBooks.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class KnjigaController : ControllerBase
    {
        masterContext db = new masterContext();
        [HttpGet]

        public IActionResult getKnjiga()
        {
            List<Knjiga> k = db.Knjigas.OrderBy(a => a.Idknjiga).ToList();
            return Ok(k);
        }



        [HttpGet(Name = "/{knjiga}")]



        public IActionResult po_NazivuKnjige(string name)
        {
            List<Knjiga> k = db.Knjigas.Where(r => r.NazivKnjige.Contains(name)).ToList();
            return Ok(k);
        }
    }

}
