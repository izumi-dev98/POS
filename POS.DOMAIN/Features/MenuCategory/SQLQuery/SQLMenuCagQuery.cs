using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.MenuCategory.SQLQuery
{
    public static class SQLMenuCagQuery
    {
        public const string GetAllMenuCag = @"SELECT [Id]
                                            ,[MenuCag_Name]
                                            ,[MenuCag_Des]
                                            ,[IsDelete]
                                            ,[CreatedAt]
                                            ,[DeletedAt]
                                            ,[UpdatedAt]
                                            FROM [dbo].[MenuCategories] 
                                            WHERE IsDelete = 0";
        // 

        public const string GetByMenuCagName =  @"SELECT [Id]
                                                 ,[MenuCag_Name] 
                                                 ,[IsDelete]
                                                  FROM [dbo].[MenuCategories]
                                                  WHERE UPPER(MenuCag_Name) = UPPER(@MenuCag_Name) Collate latin1_General_CI_AS ";
        //

        public const  string restoreQuery = @"
                                               UPDATE MenuCategories
                                                   SET
                                                  IsDelete = 0,
                                                  UpdatedAt = GETDATE()
                                                  WHERE id = @id";

        //

        public const string createMenuCagQuery = @"INSERT INTO [dbo].[MenuCategories]
                                                    ([MenuCag_Name]
                                                    ,[MenuCag_Des])
                                                      VALUES
                                                      (@MenuCag_Name
                                                      ,@MenuCag_Des
                                                             )";

        //

        public const string deleteMenucCagQuery = @"UPDATE [dbo].[MenuCategories] 
                                      SET [IsDelete] = 1, 
                                       [DeletedAt] = GETDATE() 
                                         WHERE id = @id";

        //

        public const string UpdateMenuCagQuery = @"
                                      UPDATE [dbo].[MenuCategories] 
                                      SET [MenuCag_Name] = @MenuCag_Name,
                                      [MenuCag_Des] = @MenuCag_Des,
                                      [UpdatedAt] = GETDATE()
                                      WHERE id = @id";

        //

        public const string PatchBase = @"
                                        UPDATE [dbo].[MenuCategories]
                                        SET ";

        public const string PatchFooter = " WHERE id = @id";
    }
}
