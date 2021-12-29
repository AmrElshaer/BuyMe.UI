using BuyMe.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.UnitTests.Common
{
    public class CurrentUserServiceTest : ICurrentUserService
    {
        public int CompanyId => 1;

        public string UserId => throw new NotImplementedException();

        public bool IsAuthenticated => throw new NotImplementedException();
    }
}