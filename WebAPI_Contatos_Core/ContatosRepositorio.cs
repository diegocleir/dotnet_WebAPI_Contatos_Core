using System.Collections.Generic;
using System.Linq;

namespace WebAPI_Contatos_Core
{
    public class ContatosRepositorio : IContatosRepositorio
    {
        static List<Contato> ListaContatos = new List<Contato>();
        public void Adicionar(Contato item)
        {
            ListaContatos.Add(item);
        }
        public void Atualizar(Contato item)
        {
            var itemAtualizar = ListaContatos.SingleOrDefault(r => r.Telefone == item.Telefone);
            if (itemAtualizar != null)
            {
                itemAtualizar.Nome = item.Nome;
                itemAtualizar.Sobrenome = item.Sobrenome;
                itemAtualizar.IsParente = item.IsParente;
                itemAtualizar.Empresa = item.Empresa;
                itemAtualizar.Email = item.Email;
                itemAtualizar.Telefone = item.Telefone;
                itemAtualizar.Nascimento = item.Nascimento;
            }
        }
        public Contato Encontrar(string chave)
        {
            return ListaContatos.Where(e => e.Telefone.Equals(chave)).FirstOrDefault();
        }
        public IEnumerable<Contato> GetTodos()
        {
            return ListaContatos;
        }
        public void Remover(string Id)
        {
            var itemARemover = ListaContatos.SingleOrDefault(r => r.Telefone == Id);
            if (ListaContatos != null)
                ListaContatos.Remove(itemARemover);
        }
    }
}
