using System.Collections.Generic;
using ApiFilmes.Models;
using ApiFilmes.Repositorio;
using System.Linq;

namespace ApiFilmes.Repositorio
{
    public class FilmeRepositorio : IFilmeRepositorio
    {
        private readonly FilmeDbContext _contexto;

        public FilmeRepositorio(FilmeDbContext ctx)
        {
            _contexto = ctx;
        }

        public void Add(Filme filme)
        {
            _contexto.Filmes.Add(filme);
            _contexto.SaveChanges();
        }

        public IEnumerable<Filme> GetAll()
        {
            return _contexto.Filmes.ToList();
        }

        public Filme Find(long id)
        {
            return _contexto.Filmes.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Filme> FindByNome(string nome)
        {
            return _contexto.Filmes.Where(f => f.Nome.Contains(nome));
        }

        public void Remove(long id)
        {
            var entity = _contexto.Filmes.First(f => f.Id == id);
            _contexto.Filmes.Remove(entity);
            _contexto.SaveChanges();
        }
        
        public void Update(Filme filme)
        {        
            _contexto.Filmes.Update(filme);
            _contexto.SaveChanges();           
        }
    }
}