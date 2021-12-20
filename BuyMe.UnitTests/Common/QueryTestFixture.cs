using AutoMapper;
using BuyMe.Application.Common.Mapping;
using BuyMe.Persistence;
using System;

namespace BuyMe.UnitTests.Common
{
    public class QueryTestFixture :IDisposable
    {
        public BuyMeDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = BuyMeContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            BuyMeContextFactory.Destroy(Context);
        }
    }
}
