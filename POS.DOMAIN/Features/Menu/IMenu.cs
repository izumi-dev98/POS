using POS.DOMAIN.Features.Menu.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu
{
    public interface  IMenu
    {
        Task<Result<IEnumerable<MenuResponse>>> GetAllMenu();

        Task<Result<MenuResponse>> CreateMenu(MenuRequest request);
    }
}
