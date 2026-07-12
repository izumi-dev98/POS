using MediatR;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.MenuCategory.Queries
{
    public class GetMenuCagAllQuery : IRequest<Result<IEnumerable<MenuCagResponse>>>
    {

        public int id { get; set; }

        public string MenuCag_Name { get; set; }

        public string MenuCag_Des { get; set; }
    }
}
