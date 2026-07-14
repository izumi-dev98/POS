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
        M.[Status],       
        M.[IsDelete],      
        CASE 
            WHEN M.[Status] = 1 THEN 'Active' 
            ELSE 'Inactive' 
        END AS StatusText
    FROM [dbo].[Menu] M
    INNER JOIN [dbo].[MenuCategories] C ON M.[MenuCategoryId] = C.[id]
    WHERE M.[Status] = 1 
      AND M.[IsDelete] = 0;";

        //

        public const string GetByName = @"SELECT [id]
                             ,[MenuName]
                             ,[Status]
                             ,[IsDelete]
                             FROM [dbo].[Menu] Where UPPER(MenuName) = UPPER(@MenuName)  Collate latin1_General_CI_AS";


        //

        public const string Restore = @"UPDATE [dbo].[Menu]
                                         SET 
                                           [Status] = 1
                                           ,[IsDelete] = 0

                                           ,[UpdatedAt] = GETDATE()
     
                                            WHERE id = @id";


        ///

        public const string CreateMenu = @"INSERT INTO [dbo].[Menu]
           ([MenuName]
           ,[Price]
           ,[MenuCategoryId]
              )
            VALUES
           (@MenuName
           ,@Price
           ,@MenuCategoryId)";
    }
}
