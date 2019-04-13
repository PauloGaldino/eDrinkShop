using Domain.Interfaces;
using Infra.Data.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class RepositorioGenerico<T> : IGenerica<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextoGeral> _OptionsBuilder;
        public RepositorioGenerico()
        {
            _OptionsBuilder = new DbContextOptions<ContextoGeral>();
        }
        public void Adcionar(T Objeto)
        {

            using (var banco = new ContextoGeral(_OptionsBuilder))
            {
                banco.Set<T>().Add(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Atualizar(T Objeto)
        {

            using (var banco = new ContextoGeral(_OptionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Excluir(T Objeto)
        {
            using (var banco = new ContextoGeral(_OptionsBuilder))
            {
                banco.Set<T>().Remove(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public IList<T> Listar()
        {

            using (var banco = new ContextoGeral(_OptionsBuilder))
            {
                return banco.Set<T>().AsNoTracking().ToList();
            }
        }

        public T ObterPorId(int Id)
        {
            using (var banco = new ContextoGeral(_OptionsBuilder))
            {
                return banco.Set<T>().Find(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
