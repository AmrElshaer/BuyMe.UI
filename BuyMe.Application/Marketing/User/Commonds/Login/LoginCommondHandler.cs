using BuyMe.Application.Common.Exceptions;
using BuyMe.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.Marketing.User.Commonds.Login
{
    public class LoginCommondHandler : IRequestHandler<LoginCommond, string>
    {

        private readonly IJwtFactoryService _jwtFactoryService;
        private readonly IBuyMeDbContext _context;
        private readonly IApplicationUserServcie _userService;
        public LoginCommondHandler(IJwtFactoryService jwtFactoryService, IBuyMeDbContext context, IApplicationUserServcie userService)
        {
            _jwtFactoryService = jwtFactoryService;
            _context = context;
            _userService = userService;
        }
        public async Task<string> Handle(LoginCommond request, CancellationToken cancellationToken)
        {
            var user =await _userService.TryGetUserAsync(request.Email,request.Password);
            if (!user.isRegister)
            {
              throw new NotFoundException("User", request.Email);
            } 

            var customer = await _context.Customers.FirstOrDefaultAsync(a => a.UserId == user.userId);
            return await _jwtFactoryService.GenerateEncodedToken(customer.UserId,customer.CustomerName, customer.Id, customer.CompanyId);
        }
    }
}
