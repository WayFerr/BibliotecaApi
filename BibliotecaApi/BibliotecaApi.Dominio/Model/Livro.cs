using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.Model
{
    public class Livro
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public long Paginas { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        [ForeignKey("AutorId")]
        public long AutorId { get; set; }
        [ForeignKey("EditoraId")]
        public long EditoraId { get; set; }
        public Autor Autor { get; set; }
        public Editora Editora { get; set; }
    }
}
