using System.Collections.Generic;
using Application.Interfaces.IAppPessoas;
using Domain.Entities.Pessoas;
using Domain.Interfaces.IPessoas;

namespace Application.Aplications.AppPessoas
{
    public class AppJuridica : IAppJuridica
    {
        IJuridica _IJuridica;
        public AppJuridica(IJuridica IJuridica)
        {
            _IJuridica = IJuridica;
        }

        public void Adcionar(Juridica Objeto)
        {
            _IJuridica.Adcionar(Objeto);
        }

        public void Atualizar(Juridica Objeto)
        {
            _IJuridica.Atualizar(Objeto);
        }

        public void Excluir(Juridica Objeto)
        {
            _IJuridica.Excluir(Objeto);
        }

        public IList<Juridica> Listar()
        {
            return _IJuridica.Listar();
        }

            public Juridica ObterPorId(int Id)
        {
            return _IJuridica.ObterPorId(Id);
        }
    }
}
