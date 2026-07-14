using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.Models
{
    public class MenuResponse
    {

      //     ,[MenuName]
      //,[Price]
      //,[MenuCategoryId]
      //,[Status]
      //,[IsDelete]
      //,[CreatedAt]
      //,[UpdatedAt]
      //,[DeletedAt]

        public int id { get; set;  }

        public string MenuName { get; set; }

        public decimal? Price { get; set; }

        public string MenuCag_Name { get; set; } 
        public string StatusText { get; set; }

        public int ? Status { get; set; }

        public int ? IsDelete { get; set; }




    }
}
