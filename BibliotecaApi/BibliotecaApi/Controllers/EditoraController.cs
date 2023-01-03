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
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraServico _editora;
        private readonly IMapper _mapper;

        public EditoraController(IEditoraServico editora, IMapper mapper)
        {
            _editora = editora;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var editoraEncontrada = await _editora.FindAll();
            if (editoraEncontrada == null) return NotFound("Editoras não encontradas");

            return Ok(editoraEncontrada);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var editoraEncontrada = await _editora.FindById(id);
            if (editoraEncontrada == null) return NotFound("Editora não encontrada");

            return Ok(editoraEncontrada);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> FindByName(string nome)
        {
            var editoraEncontrada = await _editora.FindByName(nome);
            if (editoraEncontrada == null) return NotFound("Editora não encontrada");

            return Ok(editoraEncontrada);
        }
        [HttpPost]
        public async Task<IActionResult> Create(EditoraViewModel editora)
        {
            if (editora == null) return BadRequest();
            var entidade = _mapper.Map<Editora>(editora);
            await _editora.Create(entidade);

            return Ok(editora);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EditoraViewModel editora)
        {
            if (editora == null) return BadRequest();
            var entidade = _mapper.Map<Editora>(editora);
            await _editora.Update(entidade);

            return Ok(editora);
        }
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var editoraEncontrada = await _editora.FindById(id);
            if (editoraEncontrada == null) return BadRequest();

            await _editora.Delete(editoraEncontrada.Id);

            return Ok(editoraEncontrada);
        }
    }
}
