using AutoMapper;
using BibliotecaApi.Dominio.Model;
using BibliotecaApi.Dominio.ViewModel;
using BibliotecaApi.Servicos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorServico _autor;
        private readonly IMapper _mapper;

        public AutorController(IAutorServico autor, IMapper mapper)
        {
            _autor = autor;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var autoresEncontrados = await _autor.FindAll();
            if (autoresEncontrados == null) return NotFound("Autores não encontrados");

            return Ok(autoresEncontrados);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var autorEncontrado = await _autor.FindById(id);
            if (autorEncontrado == null) return NotFound("Autor não encontrado");

            return Ok(autorEncontrado);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> FindByName(string nome)
        {
            var autorEncontrado = await _autor.FindByName(nome);
            if (autorEncontrado == null) return NotFound("Autor não encontrado");

            return Ok(autorEncontrado);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AutorViewModel autor)
        {
            if (autor == null) return BadRequest();
            var entidade = _mapper.Map<Autor>(autor);
            await _autor.Create(entidade);

            return Ok(autor);
        }
        [HttpPut]
        public async Task<IActionResult> Update(AutorViewModel autor)
        {
            if (autor == null) return BadRequest();
            var entidade = _mapper.Map<Autor>(autor);
            await _autor.Update(entidade);

            return Ok(autor);
        }
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var autorEncontrado = await _autor.FindById(id);
            if (autorEncontrado == null) return BadRequest();

            await _autor.Delete(autorEncontrado.Id);
            return Ok(autorEncontrado);
        }
    }
}
