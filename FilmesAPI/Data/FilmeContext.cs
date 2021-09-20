using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
       
        //criando construtor e passando parametro
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }
        // fazer a conexão com banco sem se preocupar de capsular
        public DbSet<Filme> Filmes { get; set; }
    }
}
