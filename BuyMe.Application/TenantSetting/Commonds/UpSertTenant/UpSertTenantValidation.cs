using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Application.TenantSetting.Commonds.UpSertTenant
{
    public class UpSertTenantValidation:AbstractValidator<UpSertTenantCommond>
    {
        public UpSertTenantValidation()
        {
            RuleFor(d => d.TenantName).NotEmpty().WithMessage("Comapny Name must be empty");
        }
    }
}
