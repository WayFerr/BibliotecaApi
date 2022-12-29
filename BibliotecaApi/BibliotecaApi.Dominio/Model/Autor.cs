using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.Model
{
    public class Autor
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobre { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
