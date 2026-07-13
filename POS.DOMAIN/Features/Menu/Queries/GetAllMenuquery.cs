using MediatR;
using POS.DOMAIN.Features.Menu.Models;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.Queries
{
    public class GetAllMenuquery :IRequest<Result<IEnumerable<MenuResponse>>>
    {
        public int id { get; set; }

        public string MenuName { get; set; }

        public decimal? Price { get; set; }

        public string CategoryName { get; set; }
        public string StatusText { get; set; }
    }
}
