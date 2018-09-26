using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositorioGeek.Data;

namespace RepositorioGeek.Services
{
    public class RepositoryService<T>
    {
        private readonly ApplicationDbContext _context;

        public RepositoryService(ApplicationDbContext contexto)
        {
            _context = contexto;
        }
/*
        public async Task<IEnumerable<T>> GetItemAsync(bool? criterio)
        {
            if (criterio != null)
            {
                var items = await _context.Filmes
                        .Where(t=> t.Concluido == criterio)
                        .ToArrayAsync();

                return items;
            }
            else
            {
                var items = await _context.Filmes.ToArrayAsync();
                return items;
            }
        }                
 */
    }
}