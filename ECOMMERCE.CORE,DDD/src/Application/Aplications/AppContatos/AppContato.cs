using System.Collections.Generic;
using Application.Interfaces.IAppContatos;
using Domain.Entities.Contatos;
using Domain.Interfaces.IContatos;

namespace Application.Aplications.AppContatos
{
    public class AppContato : IAppContato
    {
        IContato _IContato;
            public AppContato(IContato IContato)
        {
            _IContato = IContato;
        }

        public void Adicionar(Contato Objeto)
        {
            _IContato.Adicionar(Objeto);
        }

        public void Atualizar(Contato Objeto)
        {
            _IContato.Atualizar(Objeto);
        }

        public void Excluir(Contato Objeto)
        {
            _IContato.Excluir(Objeto);
        }

        public IList<Contato> Listar()
        {
           return _IContato.Listar();
        }

        public Contato ObterPorId(int Id)
        {
           return  _IContato.ObterPorId(Id);
        }
    }
}
