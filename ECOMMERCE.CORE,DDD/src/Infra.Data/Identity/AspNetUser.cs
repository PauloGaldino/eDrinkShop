using System.Collections.Generic;
using System.Security.Claims;
using Domain.Interfaces.IUser;
using Microsoft.AspNetCore.Http;

namespace Infra.Data.Identity
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _acessor;
        public AspNetUser(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public string Nome =>_acessor.HttpContext.User.Identity.Name;

            public IEnumerable<Claim> GetCalimsIdentity()
        {
            return _acessor.HttpContext.User.Claims;
        }

        public bool IsAuthenthiticated()
        {
            return _acessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
