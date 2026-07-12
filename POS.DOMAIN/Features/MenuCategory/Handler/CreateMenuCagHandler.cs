using MediatR;
using POS.DOMAIN.Features.MenuCategory.Command;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.MenuCategory.Handler
{
    public class CreateMenuCagHandler : IRequestHandler<CreateMenuCagCommand , Result<MenuCagResponse>>
    {
        private readonly IMenuCag _menucag;

        public CreateMenuCagHandler(IMenuCag menucag) {

            _menucag = menucag;
                
                }

        public async Task<Result<MenuCagResponse>> Handle (CreateMenuCagCommand request , CancellationToken cancellationToken)
        {
            return await _menucag.CreateMenuCag(new MenuCagRequest
            {
                
                MenuCag_Name = request.MenuCag_Name,
                MenuCag_Des     = request.MenuCag_Des
               
            });
        }
    }
}
