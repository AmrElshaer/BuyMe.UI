using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int CompanyId { get;}
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
