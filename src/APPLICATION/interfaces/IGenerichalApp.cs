using System;
using System.Collections.Generic;
using System.Text;

namespace APPLICATION.interfaces
{
   public interface IGenerichalApp<T> where T : class
    {
        void Adcionar(T Objeto);

        void Atualizar(T Objeto);

        void Excluir(T Objeto);

        T ObterPorId(int Id);

        IList<T> Listar();
    }
}
