using AppWebMVC.Models;
using AppWebMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppWebMVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IActionResult Index()
        {
           var pessoas =  _pessoaRepository.GetAll();
            return View(pessoas);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult EditUser(int id)
        {
            var pessoas = _pessoaRepository.ListarPorId(id);

            return View(pessoas);
        }
        public IActionResult DeletedConfirmed(int id)  
        {
            var pessoas = _pessoaRepository.ListarPorId(id);
            return View(pessoas);
        }

        public IActionResult Remove(int id)
        {
            _pessoaRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(PessoaModel pessoa)
        {
            if (ModelState.IsValid)
            {
                _pessoaRepository.Adicionar(pessoa);
                return RedirectToAction("Index");

            }
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult EditUser(PessoaModel pessoa)  
        {
            _pessoaRepository.Atualizar(pessoa);
            return RedirectToAction("Index");
        }
    }
}
