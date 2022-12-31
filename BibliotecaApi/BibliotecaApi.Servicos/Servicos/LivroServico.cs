using BibliotecaApi.Dominio.Interface;
using BibliotecaApi.Dominio.Model;
using BibliotecaApi.Servicos.Interface;

namespace BibliotecaApi.Servicos.Servicos
{
    public class LivroServico : ILivroServico
    {
        private readonly ILivroRepository _livro;
        
        public LivroServico(ILivroRepository livro)
        {
            _livro = livro;
        }

        public async Task<List<Livro>> FindAll()
        {
            return await _livro.FindAll();
        }

        public async Task<Livro> FindById(long id)
        {
            return await _livro.FindById(id);
        }

        public async Task<Livro> FindByName(string nome)
        {
            return await _livro.FindByName(nome);
        }
        public async Task<Livro> Create(Livro livro)
        {
            var livroEncontrado = await _livro.FindByName(livro.Nome);
            if (livroEncontrado != null) return null;

            return await _livro.Create(livro);

        }
        public async Task<Livro> Update(Livro livro)
        {
            return await _livro.Update(livro);
        }
        public async Task<bool> Delete(long id)
        {
            var livroEncontrado = await _livro.FindById(id);
            if (livroEncontrado == null) return false;

            return await _livro.Delete(id);
        }
    }
}
