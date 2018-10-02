using System;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Acessando API, Aguarde...");

            var repositorio = new FilmeRepositorio();
            var filmeTask = repositorio.GetFilmesAsync();

            filmeTask.ContinueWith(task =>
            {
                var filmes = task.Result;

                foreach(var f in filmes)
                    WriteLine(f.ToString());

                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);

            ReadLine();
        }
    }
}
