using BuyMe.Persistence;
using System;

namespace BuyMe.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly BuyMeDbContext buyMeDbContext;
        public CommandTestBase()
        {
            buyMeDbContext = BuyMeContextFactory.Create();
        }
        public void Dispose()
        {
            BuyMeContextFactory.Destroy(buyMeDbContext);
        }
    }
}
