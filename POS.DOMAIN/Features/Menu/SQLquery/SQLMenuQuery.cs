using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu.SQLquery
{
    public static class SQLMenuQuery
    {
        public const string GetAllMenu = @"
                            SELECT 
                              M.[id], 
                            M.[MenuName], 
                                                M.[Price], 
                            C.[MenuCag_Name], 
                                CASE 
                             WHEN M.[Status] = 1 THEN 'Active' 
                               ELSE 'Inactive' 
                                   END AS StatusText
                          FROM [dbo].[Menu] M
                       INNER JOIN [dbo].[MenuCategories] C ON M.[MenuCategoryId] = C.[id]
                            WHERE M.[Status] = 1 
                                  AND M.[IsDelete] = 0;";
    }
}
