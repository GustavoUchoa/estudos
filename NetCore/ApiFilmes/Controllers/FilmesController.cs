
using System.Collections.Generic;
using ApiFilmes.Models;
using ApiFilmes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilmes.Controllers
{
    [Route("api/[Controller]")]
    public class FilmesController : Controller
    {
        private readonly IFilmeRepositorio _filmeRepositorio;

        public FilmesController(IFilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio;
        }

        [HttpGet]
        public IEnumerable<Filme> GetAll()
        {
            return _filmeRepositorio.GetAll();
        }

        [HttpGet("{id}", Name="GetFilme")]
        public IActionResult GetById(long id)
        {
            var filme = _filmeRepositorio.Find(id);

            if (filme == null)
                return NotFound();

            return new ObjectResult(filme);
        }
        [Route("pesquisar/{nome}")]
        public IEnumerable<Filme> GetByIdByNome(string nome)
        {
            return _filmeRepositorio.FindByNome(nome);            
        }

        [HttpPost]
        public IActionResult Create([FromBody] Filme filme)
        {
            if (filme == null)
                return BadRequest();

            _filmeRepositorio.Add(filme);

            return CreatedAtRoute("GetFilme", new {id = filme.Id}, filme);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Filme filme)
        {
            if (filme == null || filme.Id != id)
                return BadRequest();

            var _filme =_filmeRepositorio.Find(id);

            if (_filme == null)
                return NotFound();

            _filme.Nome = filme.Nome;            
            _filmeRepositorio.Update(_filme);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var filme = _filmeRepositorio.Find(id);

            if (filme == null)
                return NotFound();

            _filmeRepositorio.Remove(id);

            return new NoContentResult();
        }
    }
}