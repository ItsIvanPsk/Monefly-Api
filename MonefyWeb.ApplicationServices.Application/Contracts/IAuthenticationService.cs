using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyWeb.ApplicationServices.Application.Contracts
{
    public interface IAuthenticationService
    {
        string GenerateToken(long userId);
    }
}
