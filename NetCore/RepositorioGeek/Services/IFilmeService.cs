using System.Collections.Generic;
using System.Threading.Tasks;
using RepositorioGeek.Models;

namespace RepositorioGeek.Services
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> GetItemAsync(bool? criterio, ApplicationUser user);
        Task<bool> AdicionarFilme(Filme novoFilme);
        Task<bool> DeletarFilme(int? id);
        Filme GetFilmeById(int? id);
        Task AtualizarFilme(Filme filme, ApplicationUser user);
    }
}