using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using POS.DOMAIN.Features.Menu.Command;
using POS.DOMAIN.Features.Menu.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.Handler
{
    public class CreateMenuHandler : IRequestHandler<CreateMenuCommand , Result<MenuResponse>>
    {

        private readonly IMenu _menu;

        public CreateMenuHandler(IMenu menu) { 
        
            _menu = menu;
        }

        public async Task<Result<MenuResponse>> Handle (CreateMenuCommand request , CancellationToken cancellationToken)
        {
            return await _menu.CreateMenu(new MenuRequest
            {
                MenuName = request.MenuName,
                Price = request.Price,
                MenuCategoryId = request.MenuCategoryId
            });
        }
    }
}
