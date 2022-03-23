using BuyMe.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuyMe.Application.User.Commonds.UpdateProfilePhoto
{
    public class UpdateProfilePhotoCommond:IRequest<Unit>
    {
        public string Photo { get; set; }
        public class UpdateProfilePhotoCommondHandler : IRequestHandler<UpdateProfilePhotoCommond, Unit>
        {
            private readonly IUserManagerService userManagerService;

            public UpdateProfilePhotoCommondHandler(IUserManagerService userManagerService)
            {
                this.userManagerService = userManagerService;
            }
            public async Task<Unit> Handle(UpdateProfilePhotoCommond request, CancellationToken cancellationToken)
            {
               await userManagerService.UpdateUserPhoto(request.Photo);
                return Unit.Value;
            }
        }
    }
}
