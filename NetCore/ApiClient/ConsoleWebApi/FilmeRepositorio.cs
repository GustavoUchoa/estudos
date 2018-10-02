using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleWebApi
{
    public class FilmeRepositorio
    {
        HttpClient cliente = new HttpClient();

        public FilmeRepositorio()
        {
            cliente.BaseAddress = new Uri("http://localhost:56997/");

            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<List<Filme>> GetFilmesAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/filmes");

            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Filme>>(dados);
            }
            
            return new List<Filme>();
        }
    }
}
