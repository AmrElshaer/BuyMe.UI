using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Company.Commonds
{
    public class CreateEditCompanyCommondHandler : IRequestHandler<CreateEditCompanyCommond, int>
    {
        private readonly IBuyMeDbContext _context;
        private readonly IImageService imageService;

        public CreateEditCompanyCommondHandler(IBuyMeDbContext context, IImageService imageService)
        {
            _context = context;
            this.imageService = imageService;
        }

        public async Task<int> Handle(CreateEditCompanyCommond request, CancellationToken cancellationToken)
        {
            Domain.Entities.Company company;
            if (request.Id.HasValue)
            {
                var entity = await _context.Companies.FindAsync(request.Id);
                Guard.Against.Null(entity, request.Id);
                company = entity;
            }
            else
            {
                company = new Domain.Entities.Company();
                await _context.Companies.AddAsync(company);
            }
            company.Country = request.Country;
            company.City = request.City;
            company.Business = request.Business;
            if (!string.IsNullOrEmpty( company.Logo))
            {
                company.Logo= imageService.ResizeImage(request.Logo, 144, 144, ImageFormat.Png);
            }
            
            company.IsActive = request.IsActive;
            company.Name = request.Name;
            company.Telephone = request.Telephone;
            await _context.SaveChangesAsync(cancellationToken);
            return company.Id;
        }
    }
}