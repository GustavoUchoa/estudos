using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositorioGeek.Models;
using RepositorioGeek.Services;

namespace RepositorioGeek.Controllers
{
    [Authorize]
    public class FilmeController : Controller
    {
        IFilmeService _filmeService;

        private readonly UserManager<ApplicationUser> _userManager;

        public FilmeController(IFilmeService filmeService, UserManager<ApplicationUser> userManager)
        {
            _filmeService = filmeService;
            _userManager = userManager;
        }

        // Lista de Filmes
        public async Task<IActionResult> Index(bool? criterio)
        {
            var usuarioLogado = await _userManager.GetUserAsync(User);
            var filmes = await _filmeService.GetItemAsync(criterio, usuarioLogado);            
            var model = new FilmeViewModel();
            {
                model.filmes = filmes;
            }

            return View(model);
        }

        public IActionResult AdicionarFilme()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarFilme([Bind("Id, Nome, Concluido, Classificacao, DataCadastro, DataConclusao")] Filme filme)
        {
            var usuarioLogado = await _userManager.GetUserAsync(User);
            filme.IdProprietario = usuarioLogado.Id;

            if (ModelState.IsValid)
            {
                await _filmeService.AdicionarFilme(filme);
                return RedirectToAction(nameof(Index));
            }

            return View(filme);
        }

        public IActionResult DeletarFilme(int? id)
        {
            if  (id == null)
                return NotFound();

            var filme = _filmeService.GetFilmeById(id);

            if (filme == null)
                return NotFound();

            return View(filme);
        }

        [HttpPost, ActionName("DeletarFilme")]
        public async Task<IActionResult> DeletarFilmeConfirmar(int id)
        {
            await _filmeService.DeletarFilme(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AtualizarFilme(int? id)
        {
            if  (id == null)
                return NotFound();

            var filme = _filmeService.GetFilmeById(id);

            if (filme == null)
                return NotFound();

            return View(filme);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFilme(int id, [Bind("Id, Nome, Concluido, Classificacao, DataCadastro, DataConclusao")] Filme filme)
        {
            if (id != filme.Id)
                return NotFound();

            var usuarioLogado = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)                
            {
                try
                {
                    await _filmeService.AtualizarFilme(filme, usuarioLogado);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(filme);
        }
    }
}