using APPLICATION.CORE.Interfaces.Generic;
using INFRASTRUCTURE.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFRASTRUCTURE.Data.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenerichal<T>, IDisposable where T: class
    {
        private readonly DbContextOptions<GeneralContext> _OptionsBuilder;
        public GenericRepository()
        {
            _OptionsBuilder = new DbContextOptions<GeneralContext>();
        }

        public void Adcionar(T Objeto)
        {
            using (var banco = new GeneralContext(_OptionsBuilder))
            {
                banco.Set<T>().Add(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Atualizar(T Objeto)
        {
            using (var banco = new GeneralContext(_OptionsBuilder))
            {
                banco.Set<T>().Update(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public void Excluir(T Objeto)
        {
            using (var banco = new GeneralContext(_OptionsBuilder))
            {
                banco.Set<T>().Remove(Objeto);
                banco.SaveChangesAsync();
            }
        }

        public IList<T> Listar()
        {
            using (var banco = new GeneralContext(_OptionsBuilder))
            {
               return banco.Set<T>().AsNoTracking().ToList();
            }
        }

        public T ObterPorId(int Id)
        {
            using (var banco = new GeneralContext(_OptionsBuilder))
            {
                return banco.Set<T>().Find();
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }

}
