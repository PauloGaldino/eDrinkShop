using System.Collections.Generic;
using Application.Interfaces.IAppPessoas;
using Domain.Entities.Pessoas;
using Domain.Interfaces.IPessoas;

namespace Application.Aplications.AppPessoas
{
    public class AppCliente : IAppCliente
    {
        ICliente _Cliente;
        public AppCliente(ICliente Cliente)
        {
            _Cliente = Cliente;
        }

        public void Adicionar(Cliente Objeto)
        {
            _Cliente.Adicionar(Objeto);
        }

        public void Atualizar(Cliente Objeto)
        {
            _Cliente.Atualizar(Objeto);
        }

        public void Excluir(Cliente Objeto)
        {
            _Cliente.Excluir(Objeto);
        }

        public IList<Cliente> Listar()
        {
            return _Cliente.Listar();
        }

        public Cliente ObterPorId(int Id)
        {
          return  _Cliente.ObterPorId(Id);
        }
    }
}
