using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BibliotecaApi.Dominio.Model
{
    public class Editora
    {
        public Editora()
        {
            Livros = new Collection<Livro>();
        }
        
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
