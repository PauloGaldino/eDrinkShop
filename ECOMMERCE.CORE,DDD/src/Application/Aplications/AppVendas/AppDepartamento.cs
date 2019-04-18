using System.Collections.Generic;
using Application.Interfaces.IAppVendas;
using Domain.Entities.Vendas;
using Domain.Interfaces.IVendas;

namespace Application.Aplications.AppVendas
{
    public class AppDepartamento : IAppDepartamento
    {
        IDepartamento _IDepartamento;
        public AppDepartamento(IDepartamento IDepartamento)
        {
            _IDepartamento = IDepartamento;
        }

        public void Adicionar(Departamento Objeto)
        {
            _IDepartamento.Adicionar(Objeto);
        }

        public void Atualizar(Departamento Objeto)
        {
            _IDepartamento.Atualizar(Objeto);
        }

        public void Excluir(Departamento Objeto)
        {
            _IDepartamento.Excluir(Objeto);
        }

        public IList<Departamento> Listar()
        {
            return _IDepartamento.Listar();
        }

        public Departamento ObterPorId(int Id)
        {
            return _IDepartamento.ObterPorId(Id);
        }
    }
}
