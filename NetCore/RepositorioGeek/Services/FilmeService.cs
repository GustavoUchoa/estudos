using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositorioGeek.Data;
using RepositorioGeek.Models;

namespace RepositorioGeek.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly ApplicationDbContext _context;

        public FilmeService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IEnumerable<Filme>> GetItemAsync(bool? criterio, ApplicationUser user)
        {
            if (criterio != null)
            {
                var items = await _context.Filmes
                    .Where(t=> t.Concluido == criterio && t.IdProprietario == user.Id)
                    .ToArrayAsync();

                return items;
            }
            else
            {
                var items = await _context.Filmes
                    .Where(t=> t.IdProprietario == user.Id) 
                    .ToArrayAsync();

                return items;
            }
        }
        
        public async Task<bool> AdicionarFilme(Filme novoFilme)
        {
            var filme = new Filme
            {
                IdProprietario = novoFilme.IdProprietario,
                Nome = novoFilme.Nome,
                Concluido = false,
                Classificacao = 0,
                DataCadastro = DateTime.Now,
                DataConclusao = null
            };

            _context.Filmes.Add(filme);
            var resultado = await _context.SaveChangesAsync();
            return resultado == 1;
        }

        public async Task<bool> DeletarFilme(int? id)
        {
            Filme filme = _context.Filmes.Find(id);
            _context.Filmes.Remove(filme);
            var resultado = await _context.SaveChangesAsync();

            return resultado == 1;
        }

        public Filme GetFilmeById(int? id)
        {
            return _context.Filmes.Find(id);
        }

        public async Task AtualizarFilme(Filme filme, ApplicationUser user)
        {
            if (filme.IdProprietario == null)
                filme.IdProprietario = user.Id;
                
            if (filme == null)
                throw new ArgumentException(nameof(filme));

            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
        }
    }
}