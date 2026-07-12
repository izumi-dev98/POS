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
    public class DeleteMenuCagHandler : IRequestHandler<DeleteMenuCagCommand, Result<MenuCagResponse>>
    {
        private readonly IMenuCag _menuCag;

        public DeleteMenuCagHandler(IMenuCag menuCag)
        {
            _menuCag = menuCag;
        }

        public async Task<Result<MenuCagResponse>> Handle (DeleteMenuCagCommand request , CancellationToken cancellationToken)
        {
            return await _menuCag.DeleteMenuCag(request.id);
        }
    }
}
