using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.MenuCategory.Models
{
    public class MenuCagRequest
    {
        public int id { get; set; }

        public string? MenuCag_Name { get; set; }

        public string? MenuCag_Des { get; set; }

        public int? IsDelete { get; set; }
    }
}
