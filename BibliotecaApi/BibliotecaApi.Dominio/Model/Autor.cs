using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.Model
{
    [Table("Autores")]
    public class Autor
    {
        public Autor()
        {
            Livros = new Collection<Livro>();
        }
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [StringLength(400)]
        public string Sobre { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
