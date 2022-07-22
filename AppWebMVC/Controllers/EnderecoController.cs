using AppWebMVC.Models;
using AppWebMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppWebMVC.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            var enderecos = _enderecoRepository.GetAll();
            return View(enderecos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult EditAdrees(int id)
        {
            var enderecos = _enderecoRepository.ListarPorId(id);

            return View(enderecos);
        }
        public IActionResult DeletedConfirmed(int id)
        {
            var enderecos = _enderecoRepository.ListarPorId(id);
            return View(enderecos);
        }

        public IActionResult Remove(int id)
        {
            _enderecoRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(EnderecoModel enderecoModel)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepository.Adicionar(enderecoModel);
                return RedirectToAction("Index");

            }
            return View(enderecoModel);
        }

        [HttpPost]
        public IActionResult EditAdrees(EnderecoModel enderecoModel)
        {
            _enderecoRepository.Atualizar(enderecoModel);
            return RedirectToAction("Index");
        }
    }
}
