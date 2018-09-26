using System.Collections.Generic;
using ApiFilmes.Models;

namespace ApiFilmes.Repositorio
{
    public interface IFilmeRepositorio
    {
        void Add(Filme filme);

        IEnumerable<Filme> GetAll();

        Filme Find(long id);

        IEnumerable<Filme> FindByNome(string nome);

        void Remove(long id);
        
        void Update(Filme filme);
    }
}