using System.Collections.Generic;
using Application.Interfaces.IAppContatos;
using Domain.Entities.Contatos;
using Domain.Interfaces.IContatos;

namespace Application.Aplications.AppContatos
{
   public class AppTelefone : IAppTelefone
    {
        ITelefone _ITelefone;
        public AppTelefone(ITelefone ITelefone)
        {
            _ITelefone = ITelefone;
        }

        public void Adicionar(Telefone Objeto)
        {
            _ITelefone.Adicionar(Objeto);
        }

        public void Atualizar(Telefone Objeto)
        {
            _ITelefone.Atualizar(Objeto);
        }

        public void Excluir(Telefone Objeto)
        {
            _ITelefone.Excluir(Objeto);
        }

        public IList<Telefone> Listar()
        {
            return _ITelefone.Listar();
        }

        public Telefone ObterPorId(int Id)
        {
          return  _ITelefone.ObterPorId(Id);
        }
    }
}
