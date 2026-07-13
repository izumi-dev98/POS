using POS.DOMAIN.Features.MenuCategory.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.MenuCategory
{
    public interface IMenuCag
    {
        Task<Result<IEnumerable<MenuCagResponse>>> GetAllMenu();
        Task<Result<MenuCagResponse>> CreateMenuCag(MenuCagRequest request);

        Task<Result<MenuCagResponse>> DeleteMenuCag(int id);

        Task<Result<MenuCagResponse>> UpdateMenuCag(MenuCagRequest request);
        Task<Result<MenuCagResponse>> PatchMenuCag(int id, MenuCagRequest request);
    }
}
