using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.Models
{
    public class MenuRequest
    {
        public int id { get; set; }

        public string? MenuName { get; set; }

        public decimal? Price { get; set; }

         public int  MenuCategoryId { get; set; }

    }
}
