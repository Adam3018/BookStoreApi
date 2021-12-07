using BookStoreApi.EF;
using BookStoreApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private BookStoreContext _db;
        public MainController(BookStoreContext db)
        {
            _db = db;
        }

        [Route("GetAllAutor")]
        [HttpGet]
        public IActionResult GetAllAutor()
        {
            var autori = _db.Autors.ToList();

            return Ok(autori);
        }

        [Route("GetAutor/{id}")]
        [HttpGet]
        public IActionResult GetAutor(int id)
        {
            var autor = _db.Autors.Find(id);

            if (autor == null)
                return BadRequest("ID nije pronadjen");


            return Ok(autor);
        }

        [Route("CreateAutor")]
        [HttpPost]
        public IActionResult CreateAutor(AutorModel model)
        {
            if (string.IsNullOrEmpty(model.ImeAutora) || string.IsNullOrEmpty(model.PrezimeAutora))
                return BadRequest("NoData");

            Autor autor = new Autor();
            autor.ImeAutora = model.ImeAutora;
            autor.PrezimeAutora = model.PrezimeAutora;

            _db.Autors.Add(autor);
            _db.SaveChanges();

            return Ok(autor);
        }

        [Route("UpdateAutor")]
        [HttpPut]
        public IActionResult UpdateAutor(AutorModel model)
        {
            if (model.IdAutora==0)
                return BadRequest("NoID");

            if (string.IsNullOrEmpty(model.ImeAutora) || string.IsNullOrEmpty(model.PrezimeAutora))
                return BadRequest("NoData");

            var autor = _db.Autors.Find(model.IdAutora);

            if(autor is null)
                return BadRequest("NoAutor");

            autor.ImeAutora = model.ImeAutora;
            autor.PrezimeAutora = model.PrezimeAutora;

            _db.Autors.Attach(autor);
            _db.SaveChanges();

            return Ok(autor);
        }

        [Route("DeleteAutor/{id}")]
        [HttpDelete]
        public IActionResult DeleteAutor(int id)
        {
            var autor = _db.Autors.Find(id);

            if (autor is null)
                return BadRequest("BadId");

            _db.Autors.Remove(autor);
            _db.SaveChanges();

            return Ok(autor);

        }

        [Route("GetAllZanr")]
        [HttpGet]
        public IActionResult GetAllZanr()
        {
            var zanrovi = _db.Zanrs.ToList();

            return Ok(zanrovi);
        }

        [Route("GetZanr/{id}")]
        [HttpGet]
        public IActionResult GetZanr(int id)
        {
            var zanr = _db.Zanrs.Find(id);

            if (zanr == null)
                return BadRequest("ID nije pronadjen");


            return Ok(zanr);
        }

        [Route("CreateZanr")]
        [HttpPost]
        public IActionResult CreateZanr(ZanrModel model)
        {
            if (string.IsNullOrEmpty(model.ZanrNaziv))
                return BadRequest("NoData");

            Zanr zanr = new Zanr();
            zanr.ZanrNaziv = model.ZanrNaziv;
            

            _db.Zanrs.Add(zanr);
            _db.SaveChanges();

            return Ok(zanr);
        }

        [Route("UpdateZanr")]
        [HttpPut]
        public IActionResult UpdateZanr(ZanrModel model)
        {
            if (model.IdZanra == 0)
                return BadRequest("NoID");

            if (string.IsNullOrEmpty(model.ZanrNaziv))
                return BadRequest("NoData");

            var zanr = _db.Zanrs.Find(model.IdZanra);

            if (zanr is null)
                return BadRequest("NoZanr");

            zanr.ZanrNaziv = model.ZanrNaziv;
            

            _db.Zanrs.Attach(zanr);
            _db.SaveChanges();

            return Ok(zanr);
        }

        [Route("DeleteZanr/{id}")]
        [HttpDelete]
        public IActionResult DeleteZanr(int id)
        {
            var zanr = _db.Zanrs.Find(id);

            if (zanr is null)
                return BadRequest("BadId");

            _db.Zanrs.Remove(zanr);
            _db.SaveChanges();

            return Ok(zanr);

        }

        [Route("GetAllKnjiga")]
        [HttpGet]
        public IActionResult GetAllKnjiga()
        {
            var knjige = _db.Knjigas.ToList();

            return Ok(knjige);
        }

        [Route("GetKnjiga/{id}")]
        [HttpGet]
        public IActionResult GetKnjiga(int id)
        {
            var kniga = _db.Knjigas.Find(id);

            if (kniga == null)
                return BadRequest("ID nije pronadjen");


            return Ok(kniga);
        }

        [Route("CreateKnjiga")]
        [HttpPost]
        public IActionResult CreateKnjiga(KnjigaModel model)
        {
            if (string.IsNullOrEmpty(model.KnjigaId.ToString()))
                return BadRequest("BadData");

            Knjiga knjiga = new Knjiga();
            knjiga.NazivKnjige = model.NazivKnjige;
            knjiga.CenaKnjige = model.CenaKnjige;
            knjiga.ZanrId = model.ZanrId;
            knjiga.AutorId= model.AutorId;


            _db.Knjigas.Add(knjiga);
            _db.SaveChanges();

            return Ok(knjiga);
        }

        [Route("UpdateKnjiga")]
        [HttpPut]
        public IActionResult UpdateKnjiga(KnjigaModel model)
        {
            if (model.KnjigaId == 0)
                return BadRequest("NoID");

            if (string.IsNullOrEmpty(model.NazivKnjige))
                return BadRequest("NoData");
            if (string.IsNullOrEmpty(model.CenaKnjige.ToString()))
                return BadRequest("NoData");

            var knjiga= _db.Knjigas.Find(model.KnjigaId);

            if (knjiga is null)
                return BadRequest("NoKnjiga");

            knjiga.NazivKnjige = model.NazivKnjige;
            knjiga.CenaKnjige = model.CenaKnjige;
            knjiga.ZanrId = model.ZanrId;
            knjiga.AutorId = model.AutorId;


            _db.Knjigas.Attach(knjiga);
            _db.SaveChanges();

            return Ok(knjiga);
        }

        [Route("DeleteKnjiga/{id}")]
        [HttpDelete]
        public IActionResult DeleteKnjiga(int id)
        {
            var knjiga = _db.Knjigas.Find(id);

            if (knjiga is null)
                return BadRequest("BadId");

            _db.Knjigas.Remove(knjiga);
            _db.SaveChanges();

            return Ok(knjiga);

        }

        [Route("GetKnjigeByAutor/{id}")]
        [HttpGet]
        public IActionResult GetBooksByAutorId(int id)
        {
           var knjige = _db.Knjigas.Where(x => x.AutorId == id).ToList();

            if (knjige is null)
                return BadRequest("BadId");

            return Ok(knjige);
        }

        [Route("GetAutoriByKnjige/{id}")]
        [HttpGet]
        public IActionResult GetAutorsByBook(int id)
        {
            var autori = _db.Autors.Where(x => x.Knjigas.Any(y => y.KnjigaId == id)).ToList();

            if (autori is null)
                return BadRequest("BadId");

            return Ok(autori);
        }

        [Route("GetKnjigeByZanr/{id}")]
        [HttpGet]
        public IActionResult GetBooksByGenre(int id)
        {
            var knjige = _db.Knjigas.Where(x => x.ZanrId == id).ToList();

            if (knjige is null)
                return BadRequest("BadId");

            return Ok(knjige);
        }

        [Route("GetAutoriByZanr/{id}")]
        [HttpGet]
        public IActionResult GetAutorsByGenre(int id)
        {
            var autori = _db.Autors.Where(x => x.Knjigas.Any(y => y.ZanrId == id)).ToList();

            if (autori is null)
                return BadRequest("BadId");

            return Ok(autori);
        }
    }
}
