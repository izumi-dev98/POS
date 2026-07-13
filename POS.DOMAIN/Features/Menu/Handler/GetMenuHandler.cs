using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using POS.DOMAIN.Features.Menu.Models;
using POS.DOMAIN.Features.Menu.Queries;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.Handler
{
    public class GetMenuHandler : IRequestHandler<GetAllMenuquery , Result<IEnumerable<MenuResponse>>>
    {
        private readonly IMenu _menu;


        public GetMenuHandler(IMenu menu) { 
        
        _menu = menu;
        
        }

        public async Task<Result<IEnumerable<MenuResponse>>> Handle (GetAllMenuquery request , CancellationToken cancellationToken)
        {
            return await _menu.GetAllMenu();
        }
    }
}
