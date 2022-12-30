using BibliotecaApi.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Infra
{
    public class BibliotecaApiContext : DbContext
    {
        public BibliotecaApiContext(DbContextOptions<BibliotecaApiContext> options) : base(options)
        {

        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editora> Editoras { get; set; }
    }
}
