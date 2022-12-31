using BibliotecaApi.Dominio.Interface;
using BibliotecaApi.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Infra._4._1___Infra
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaApiContext _context;

        public LivroRepository(BibliotecaApiContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> FindAll()
        {
            return await _context.Livros.ToListAsync();
        }
        public async Task<Livro> FindById(long id)
        {
            return await _context.Livros.Where(l => l.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Livro> FindByName(string nome)
        {
            return await _context.Livros.Where(l => l.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Livro> Create(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
        public async Task<Livro> Update(Livro livro)
        {
            var livroEncontrado = await _context.Livros.Where(l => l.Id == livro.Id).FirstOrDefaultAsync();
            if (livroEncontrado == null) return null;

            livroEncontrado.Nome = livro.Nome;
            livroEncontrado.Paginas = livro.Paginas;
            livroEncontrado.Sinopse = livro.Sinopse;
            livroEncontrado.Genero = livro.Genero;
            livroEncontrado.DataPublicacao = livro.DataPublicacao;
            livroEncontrado.AutorId = livro.AutorId;
            livroEncontrado.EditoraId = livro.EditoraId;

            _context.Livros.Update(livroEncontrado);
            await _context.SaveChangesAsync();

            return livroEncontrado;
        }
        public async Task<bool> Delete(long id)
        {
            var livroEncontrado = await _context.Livros.Where(l => l.Id == id).FirstOrDefaultAsync();
            if (livroEncontrado == null) return false;

            _context.Livros.Remove(livroEncontrado);
            _context.SaveChangesAsync();

            return true;
        }
    }
}
