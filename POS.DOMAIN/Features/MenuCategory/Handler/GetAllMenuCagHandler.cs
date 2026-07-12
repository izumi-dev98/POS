using MediatR;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.DOMAIN.Features.MenuCategory.Queries;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.MenuCategory.Handler
{
    public class GetAllMenuCagHandler : IRequestHandler<GetMenuCagAllQuery , Result<IEnumerable<MenuCagResponse>>>
    {
        private readonly IMenuCag _menuCag;

        public GetAllMenuCagHandler(IMenuCag menuCag) {

            _menuCag = menuCag;
        }

        public async Task<Result<IEnumerable<MenuCagResponse>>> Handle(GetMenuCagAllQuery request, CancellationToken cancellationToken) {

            return await _menuCag.GetAllMenu();
        }
    }
}
