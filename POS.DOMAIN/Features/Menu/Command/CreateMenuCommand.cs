using MediatR;
using POS.DOMAIN.Features.Menu.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.Command
{
   public class CreateMenuCommand : IRequest<Result<MenuResponse>>
    {
        public int id { get; set; }

        public string MenuName { get; set; }

        public decimal? Price { get; set; }

        public int? Status { get; set; }
        public int MenuCategoryId { get; set; }

        public int? IsDelete { get; set; }
    }
}
