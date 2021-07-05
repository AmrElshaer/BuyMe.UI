using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.NumberSequence.Commonds;
using BuyMe.Application.NumberSequence.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.NumberSequence
{
    public class NumberSequencyService : INumberSequencyService
    {
        private readonly IBuyMeDbContext _context;
        private readonly IMediator _mediator;
        public NumberSequencyService(IBuyMeDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<string> GetCurrentNumberSequence(string module)
        {
          
             var lastNum=   await _mediator.Send(new CreatEditNSCommond() { 
                 Prefix=module,
                 NumberSequenceName=module,
                 Module=module
                });
             return $"{lastNum.ToString().PadLeft(5, '0')}#{module}";
        }
    }
}
