using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using seminarskiBooks.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace seminarskiBooks.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class AutorController : ControllerBase
    {
        masterContext db = new masterContext();
        [HttpGet]
        public IActionResult getAutor()
        {
            List<Autor> a = db.Autors.OrderBy(a => a.Idautor).ToList();
            return Ok(a);
        }





        [HttpGet(Name = "/{name}")]



        public IActionResult po_ImenuPrezimenu(string name)
        {
            List<Autor> au = db.Autors.Where(r => (r.ImeAuotra + r.PrezimeAuotra).Contains(name)).ToList();
            return Ok(au);
        }
    }
}
