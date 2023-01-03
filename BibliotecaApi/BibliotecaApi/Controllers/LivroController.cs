using AutoMapper;
using BibliotecaApi.Dominio.Model;
using BibliotecaApi.Dominio.ViewModel;
using BibliotecaApi.Servicos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroServico _livro;
        private readonly IMapper _mapper;

        public LivroController(ILivroServico livro, IMapper mapper)
        {
            _livro = livro;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<IActionResult> FindAll()
        {
            var livrosEncontrados = await _livro.FindAll();
            if (livrosEncontrados == null) return NotFound("Livros não encontrados");

            return Ok(livrosEncontrados);
        }
        [HttpGet("id/{id}")] 
        public async Task<IActionResult> FindById(long id)
        {
            var livroEncontrado = await _livro.FindById(id);
            if (livroEncontrado == null) return NotFound("Livro não encontrado");

            return Ok(livroEncontrado);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> FindByName(string nome)
        {
            var livroEncontrado = await _livro.FindByName(nome);
            if (livroEncontrado == null) return NotFound("Livro não encontrado");

            return Ok(livroEncontrado);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LivroViewModel livro)
        {
            if (livro == null) return BadRequest();

            var entidade = _mapper.Map<Livro>(livro);
            await _livro.Create(entidade);

            return Ok(livro);
        }
        [HttpPut]
        public async Task<IActionResult> Update(LivroViewModel livro)
        {
            if (livro.Id == null) return BadRequest();

            var entidade = _mapper.Map<Livro>(livro);
            await _livro.Update(entidade);

            return Ok(livro);
        }
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var livroEncontrado = await _livro.FindById(id);
            if (livroEncontrado == null) return NotFound("Livro não encontrado");

            await _livro.Delete(livroEncontrado.Id);
            
            return Ok(livroEncontrado);
        }
    }
}