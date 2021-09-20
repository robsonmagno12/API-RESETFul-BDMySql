using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
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
        private FilmeContext _context;
        //fazendo mapper mapeamento do código
        private IMapper _mapper;
        //iniciando um construtor e inserindo no BD
        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        [HttpPost]
        //precia indicar que  do postman ta vindo requisição com [FromBody]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto )
        {
            //definindo o que está sendo enviado na requisição
            Filme filme = _mapper.Map<Filme>(filmeDto);

            //iserindo no banco os filmes 
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilmePorId), new {Id = filme.Id}, filme);

        }
        //método para recuperar filmes que foi enviado
        // utilizando IEnumerable<> alterar os metodos e não vai quebrar endpoint IEnumerable<Filme>
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes() 
        {
            //recuperar os filmes
            return _context.Filmes;
        
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmePorId(int id) 
        {
            // primeiro elemento que ele encontrar ou parametro.
            //recuperar o filme por id ou nulo se não encontrar na lista.
           Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

               return Ok(filmeDto); //200 retorna
            }
            return NotFound(); //404 não existe
        }

        [HttpPut("{id}")]
        //IActionResult traz informação para o usuario
        //alterar Filmes cadastrados
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) 
            {
                return NotFound(); // retornando não existe
            }
            // passando mapa 
            _mapper.Map(filmeDto, filme);
            /* atualizando campo a campo da class filme
            filme.Titulo = filmeDto.Titulo;
            filme.Diretor = filmeDto.Diretor;
            filme.Genero = filmeDto.Genero;
            filme.Duracao = filmeDto.Duracao;*/
            //salvar as mudanças  _context.SaveChanges();
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound(); // retornando não existe
            }
            //removendo filme
            _context.Remove(filme);
            //salva as alterações
            _context.SaveChanges();
            return NoContent();
        }
    }
}
