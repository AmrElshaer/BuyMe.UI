
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.OutboxMessage.Commonds
{
    public class CreatOutboxMessageCommond : IRequest<Guid>
    {
        public CreatOutboxMessageCommond(string type, object data)
        {
            Type =type;
            Data =JsonConvert.SerializeObject(data);
        }

        public string Type { get; set; }
        public string Data { get; set; }
        public class CreatOutboxMessageCommondHandler : IRequestHandler<CreatOutboxMessageCommond, Guid>
        {
            private readonly IBuyMeDbContext context;

            public CreatOutboxMessageCommondHandler(IBuyMeDbContext context)
            {
                this.context = context;
            }
            public async Task<Guid> Handle(CreatOutboxMessageCommond request, CancellationToken cancellationToken)
            {
                Domain.Entities.OutboxMessage messBox = new(Guid.NewGuid(), DateTime.Today, request.Type,
                    request.Data);
                await this.context.OutboxMessages.AddAsync(messBox);
                await this.context.SaveChangesAsync();
                return messBox.Id;
            }
        }
    }
}
