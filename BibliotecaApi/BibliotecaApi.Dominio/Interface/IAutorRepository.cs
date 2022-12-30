using BibliotecaApi.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Dominio.Interface
{
    public interface IAutorRepository
    {
        Task<List<Autor>> FindAll();
        Task<Autor> FindById(long id);
        Task<Autor> FindByName(string nome);
        Task<Autor> Create(Autor autor);
        Task<Autor> Update(Autor autor);
        Task<bool> Delete(long id);

    }
}
