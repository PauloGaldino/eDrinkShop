using System.Collections.Generic;
using System.Security.Claims;

namespace Domain.Interfaces.IUser
{
    public interface IUser
    {
         string Nome { get; }
        bool IsAuthenthiticated();
        IEnumerable<Claim> GetCalimsIdentity();
    }
}
