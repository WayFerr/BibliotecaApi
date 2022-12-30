using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaApi.Dominio.Model
{
    [Table("Editoras")]
    public class Editora
    {
        public Editora()
        {
            Livros = new Collection<Livro>();
        }
        
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
