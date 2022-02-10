using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.NumberSequence.Commonds;
using MediatR;
using System.Threading.Tasks;

namespace BuyMe.Application.NumberSequence
{
    public class NumberSequencyService : INumberSequencyService
    {
        private readonly IMediator _mediator;

        public NumberSequencyService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> GetCurrentNumberSequence(string module)
        {
            var lastNum = await _mediator.Send(new CreatEditNSCommond()
            {
                Prefix = module,
                NumberSequenceName = module,
                Module = module
            });
            return $"{lastNum.ToString().PadLeft(5, '0')}#{module}";
        }
    }
}