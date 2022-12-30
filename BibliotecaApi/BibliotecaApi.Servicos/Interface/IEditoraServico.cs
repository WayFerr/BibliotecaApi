using BibliotecaApi.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Servicos.Interface
{
    public interface IEditoraServico
    {
        Task<List<Editora>> FindAll();
        Task<Editora> FindById(long id);
        Task<Editora> FindByName(string nome);
        Task<Editora> Create(Editora editora);
        Task<Editora> Update(Editora editora);
        Task<bool> Delete(long id);
    }
}
