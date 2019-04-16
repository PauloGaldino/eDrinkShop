using System.Collections.Generic;
using Application.Interfaces.IAppContatos;
using Domain.Entities.Contatos;
using Domain.Interfaces.IContatos;

namespace Application.Aplications.AppContatos
{
    public class AppEndereco : IAppEndereco
    {
        IEndereco _IEndereco;
        public AppEndereco(IEndereco IEndereco)
        {
            _IEndereco = IEndereco;
        }

        public void Adicionar(Endereco Objeto)
        {
            _IEndereco.Adicionar(Objeto);
        }

        public void Atualizar(Endereco Objeto)
        {
            _IEndereco.Atualizar(Objeto);
        }

        public void Excluir(Endereco Objeto)
        {
            _IEndereco.Excluir(Objeto);
        }

        public IList<Endereco> Listar()
        {
            return _IEndereco.Listar();
        }

        public Endereco ObterPorId(int Id)
        {
           return _IEndereco.ObterPorId(Id);
        }
    }
}
