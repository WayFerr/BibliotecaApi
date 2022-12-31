using BibliotecaApi.Dominio.Interface;
using BibliotecaApi.Dominio.Model;
using BibliotecaApi.Servicos.Interface;

namespace BibliotecaApi.Servicos.Servicos
{
    public class EditoraServico : IEditoraServico
    {
        private readonly IEditoraRepository _editora;

        public EditoraServico(IEditoraRepository editora)
        {
            _editora = editora;
        }

        public async Task<List<Editora>> FindAll()
        {
            return await _editora.FindAll();
        }
        public async Task<Editora> FindById(long id)
        {
            return await _editora.FindById(id);
        }
        public async Task<Editora> FindByName(string nome)
        {
            return await _editora.FindByName(nome);
        }
        public async Task<Editora> Create(Editora editora)
        {
            var editoraEncontrada = await _editora.FindByName(editora.Nome);
            if (editoraEncontrada != null) return null;

            return await _editora.Create(editora);
        }
        public Task<Editora> Update(Editora editora)
        {
            return _editora.Update(editora);
        }
        public async Task<bool> Delete(long id)
        {
            var editoraEncontrada = await _editora.FindById(id);
            if (editoraEncontrada == null) return false;

            return await _editora.Delete(id);
        }
    }
}
