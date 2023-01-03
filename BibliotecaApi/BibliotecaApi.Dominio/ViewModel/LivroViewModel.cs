using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.ViewModel
{
    public class LivroViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Paginas { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        public long AutorId { get; set; }
        public long EditoraId { get; set; }
    }
}
