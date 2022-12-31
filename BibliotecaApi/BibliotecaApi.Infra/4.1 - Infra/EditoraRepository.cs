using BibliotecaApi.Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApi.Infra._4._1___Infra
{
    public class EditoraRepository
    {
        private readonly BibliotecaApiContext _context;

        public EditoraRepository(BibliotecaApiContext context)
        {
            _context = context;
        }

        public async Task<List<Editora>> FindAll()
        {
            return await _context.Editoras.ToListAsync();
        }
        public async Task<Editora> FindById(long id)
        {
            return await _context.Editoras.Where(e => e.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Editora> FindByName(string nome)
        {
            return await _context.Editoras.Where(e => e.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Editora> Create(Editora editora)
        {
            await _context.Editoras.AddAsync(editora);
            await _context.SaveChangesAsync();

            return editora;
        }
        public async Task<Editora> Update(Editora editora)
        {
            var editoraEncontrada = _context.Editoras.Where(e => e.Id == editora.Id).FirstOrDefault();
            if (editoraEncontrada == null) return null;

            editoraEncontrada.Nome = editora.Nome;

            _context.Editoras.Update(editoraEncontrada);
            await _context.SaveChangesAsync();

            return editoraEncontrada;
        }
        public async Task<bool> Delete(long id)
        {
            var editoraEncontrada = await _context.Editoras.Where(e => e.Id == id).FirstOrDefaultAsync();
            if (editoraEncontrada == null) return false;

            _context.Editoras.Remove(editoraEncontrada);
            _context.SaveChangesAsync();

            return true;
        }
    }
}
