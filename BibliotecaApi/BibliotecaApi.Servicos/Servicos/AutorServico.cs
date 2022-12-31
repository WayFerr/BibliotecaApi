using BibliotecaApi.Dominio.Interface;
using BibliotecaApi.Dominio.Model;
using BibliotecaApi.Servicos.Interface;

namespace BibliotecaApi.Servicos.Servicos
{
    public class AutorServico : IAutorServico
    {
        private readonly IAutorRepository _autor;

        public AutorServico(IAutorRepository autor)
        {
            _autor = autor;
        }

        public async Task<List<Autor>> FindAll()
        {
            return await _autor.FindAll();
        }
        public async Task<Autor> FindById(long id)
        {
            return await _autor.FindById(id);
        }
        public async Task<Autor> FindByName(string nome)
        {
            return await _autor.FindByName(nome);
        }
        public async Task<Autor> Create(Autor autor)
        {
            var autorEncontrado = await _autor.FindByName(autor.Nome);
            if (autorEncontrado != null) return null;

            return await _autor.Create(autor);
        }
        public async Task<Autor> Update(Autor autor)
        {
            return await _autor.Update(autor);
        }
        public async Task<bool> Delete(long id)
        {
            var autorEncontrado = await _autor.FindById(id);
            if (autorEncontrado == null) return false;

            return await _autor.Delete(id);
        }
    }
}
