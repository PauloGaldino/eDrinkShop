
using Domain.Interfaces.IUser;
using Infra.Data.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories.RIdentity
{
    public class PepositorioUser : RepositorioGenerico<IUser>
    {
        private readonly IUser _user;
        public PepositorioUser(IUser user)
        {
            _user = user;
        }
        //public void Adicionar(ContextoGeral contexto)
        //{
        //    contexto.Users = _user.Nome;
        //    DbContext.ContextoGeral.Add(contexto);
        //    DbContext.SaveChanges();

        //}
    }
}
