using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.Model
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Column(TypeName = "decimal(8,0)")]
        public decimal Paginas { get; set; }
        [StringLength(500)]
        public string Sinopse { get; set; }
        [StringLength(60)]
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
