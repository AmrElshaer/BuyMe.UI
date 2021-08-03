using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface IJwtFactoryService
    {
        Task<string> GenerateEncodedToken(string identifierId, string name, int userId, int companyId);
    }
}
