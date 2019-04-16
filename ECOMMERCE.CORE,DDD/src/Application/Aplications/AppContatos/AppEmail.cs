using System.Collections.Generic;
using Application.Interfaces.IAppContatos;
using Domain.Entities.Contatos;
using Domain.Interfaces.IContatos;

namespace Application.Aplications.AppContatos
{
    public class AppEmail : IAppEmail
    {
        IEmail _IEmail;
        public AppEmail(IEmail IEmail)
        {
            _IEmail = IEmail; 
        }

        public void Adicionar(Email Objeto)
        {
            _IEmail.Adicionar(Objeto);
        }

        public void Atualizar(Email Objeto)
        {
            _IEmail.Atualizar(Objeto);
        }

        public void Excluir(Email Objeto)
        {
            _IEmail.Excluir(Objeto);
        }

        public IList<Email> Listar()
        {
          return  _IEmail.Listar();
        }

        public Email ObterPorId(int Id)
        {
            return _IEmail.ObterPorId(Id);
        }
    }
}
