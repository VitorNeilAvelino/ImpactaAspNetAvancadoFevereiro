using Empresa.Dominio;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Empresa.Mvc.Controllers
{
    public class ContatosController : Controller
    {
        private readonly EmpresaDbContext _db;

        public ContatosController(EmpresaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Contatos.ToList());
        }

        public IActionResult Create()
        {
            return View(new Contato());
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _db.Contatos.Add(contato);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}