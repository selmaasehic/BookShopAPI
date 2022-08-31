using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using seminarskiBooks.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace seminarskiBooks.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ZanrController : ControllerBase
    {
        masterContext db = new masterContext();
        [HttpGet]

        public IActionResult getZanr()

        {
            List<Zanr> z = db.Zanrs.OrderBy(a => a.Idzanr).ToList();
            return Ok(z);
        }

        [HttpGet(Name = "/{zanr}")]


        public IActionResult po_Nazivu(string naziv)
        {
            List<Zanr> au = db.Zanrs.Where(r => (r.NazivZanra).Contains(naziv)).ToList();
            return Ok(au);
        }
    }

}
