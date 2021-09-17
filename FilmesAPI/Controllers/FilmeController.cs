using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    //definindo a classe como um controlador
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int Id = 1;

        [HttpPost]
        //precia indicar que  do postman ta vindo requisição com [FromBody]
        public void AdicionaFilme([FromBody] Filme filme )
        {
            filme.Id = Id++;
            filmes.Add(filme);
                //só para validar visualmente para saber o filme que está passando.
                Console.WriteLine(filme.Titulo);

        } 
        //método para recuperar filmes que foi enviado
        // utilizando IEnumerable<> alterar os metodos e não vai quebrar endpoint
        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes() 
        {
            return filmes;
        
        }

    }
}
