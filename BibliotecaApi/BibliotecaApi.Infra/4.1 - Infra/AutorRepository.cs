using BibliotecaApi.Dominio.Interface;
using BibliotecaApi.Dominio.Model;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Infra._4._1___Infra
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaApiContext _context;

        public AutorRepository(BibliotecaApiContext context)
        {
            _context = context;
        }

        public async Task<List<Autor>> FindAll()
        {
            return await _context.Autores.ToListAsync();
        }
        public async Task<Autor> FindById(long id)
        {
            return await _context.Autores.Where(a => a.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Autor> FindByName(string nome)
        {
            return await _context.Autores.Where(a => a.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Autor> Create(Autor autor)
        {
            await _context.Autores.AddAsync(autor);
            await _context.SaveChangesAsync();

            return autor;
        }
        public async Task<Autor> Update(Autor autor)
        {
            var autorEncontrado = await _context.Autores.Where(a => a.Id == autor.Id).FirstOrDefaultAsync();
            if (autorEncontrado == null) return null;

            autorEncontrado.Nome = autor.Nome;
            autorEncontrado.Sobre = autor.Sobre;

            _context.Autores.Update(autorEncontrado);
            await _context.SaveChangesAsync();

            return autorEncontrado;
        }
        public async Task<bool> Delete(long id)
        {
            var autorEncontrado = await _context.Autores.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (autorEncontrado == null) return false;

            _context.Autores.Remove(autorEncontrado);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
