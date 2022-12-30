using BibliotecaApi.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.Interface
{
    public interface ILivroRepository
    {
        Task<List<Livro>> FindAll();
        Task<Livro> FindById(long id);
        Task<Livro> FindByName(string nome);
        Task<Livro> Create(Livro livro);
        Task<Livro> Update(Livro livro);
        Task<bool> Delete(long id);
    }
}
