using BuyMe.Application.Common.Behaviour;
using BuyMe.Application.Common.Interfaces;
using BuyMe.Application.Common.Mapping;
using BuyMe.Application.Company;
using BuyMe.Application.Employee;
using BuyMe.Application.NumberSequence;
using BuyMe.Application.SalesOrder;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuyMe.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(typeof(IBuyMeDbContext).Assembly)
             .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<INumberSequencyService, NumberSequencyService>();
            services.AddTransient<ISalesOrderService, SalesOrderService>();
            return services;
        }
    }
}