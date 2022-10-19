using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI_Contatos_Core.Controllers
{
    [Route("api/[controller]")]
    public class ContatosController : Controller
    {
        public IContatosRepositorio contatosRepo { get; set; }
        public ContatosController(IContatosRepositorio _repo)
        {
            contatosRepo = _repo;
        }
        [HttpGet]
        public IEnumerable<Contato> GetTodos()
        {
            return contatosRepo.GetTodos();
        }
        [HttpGet("{id}", Name = "GetContatos")]
        public IActionResult GetPorId(string id)
        {
            var item = contatosRepo.Encontrar(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Criar([FromBody] Contato item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            contatosRepo.Adicionar(item);
            return CreatedAtRoute("GetContatos", new { Controller = "Contatos", id = item.Telefone }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(string id, [FromBody] Contato item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = contatosRepo.Encontrar(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            contatosRepo.Atualizar(item);
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public void Deletar(string id)
        {
            contatosRepo.Remover(id);
        }
    }
}
