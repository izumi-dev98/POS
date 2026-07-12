using Dapper;
using Microsoft.AspNetCore.Mvc;
using POS.DATABASE;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POS.DOMAIN.Features.MenuCategory
{
    public class MenuCagService : IMenuCag
    {

        private readonly DbconnectionFactory _db;

        public MenuCagService(DbconnectionFactory db)
        {

            _db = db;

        }

        // Get Method

        public async Task<Result<IEnumerable<MenuCagResponse>>> GetAllMenu()
        {
            try
            {

                using (IDbConnection conn = _db.CreateConnection())
                {
                    string query = @"SELECT [Id]
                                                          ,[MenuCag_Name]
                                                          ,[MenuCag_Des]
                                                          ,[IsDelete]
                                                          ,[CreatedAt]
                                                          ,[DeletedAt]
                                                          ,[UpdatedAt]
                                                           FROM [dbo].[MenuCategories] WHERE IsDelete = 0";

                    var result = await conn.QueryAsync<MenuCagResponse>(query);

                    return Result<IEnumerable<MenuCagResponse>>.Success(result, "Data Found");
                }


            }
            catch (Exception ex)
            {

                return Result<IEnumerable<MenuCagResponse>>.Failure($"  {ex.Message} ", "An error occurred");
            }
        }

        public async Task<Result<MenuCagResponse>> CreateMenuCag(MenuCagRequest request)
        {
            try
            {

                using (IDbConnection conn = _db.CreateConnection())
                {
                    string searchQuery = @"SELECT [Id]
                                                          ,[MenuCag_Name]
                                                     
                                                          ,[IsDelete]
                                                    
                                                           FROM [dbo].[MenuCategories]

                                                           WHERE UPPER(MenuCag_Name) = UPPER(@MenuCag_Name) Collate latin1_General_CI_AS ";

                    var sr = await conn.QueryFirstOrDefaultAsync<MenuCagResponse>(searchQuery, request);

                    if (sr != null)
                    {
                        if (sr.IsDelete == 1) {



                            string restoreQuery = @"
                                          UPDATE MenuCategories
                                           SET
                                                  IsDelete = 0,
                                                  UpdatedAt = GETDATE()
                                          WHERE id = @id";

                            await conn.ExecuteAsync(restoreQuery, new
                            {
                                sr.id

                            });


                            return Result<MenuCagResponse>.Success(sr, "Your Data Is Already Exit , Restore is successFully");
                        }

                        return Result<MenuCagResponse>.Failure("Menu Category is Already Exit", "Duplicate Category");
                    }

                    string createQuery = @"INSERT INTO [dbo].[MenuCategories]
                                             ([MenuCag_Name]
                                              ,[MenuCag_Des])
                                          VALUES
                                           (@MenuCag_Name
                                           ,@MenuCag_Des
                                            )";

                    await conn.ExecuteAsync(createQuery, request);

                    return Result<MenuCagResponse>.Success(null, "New Menu Category Create is successfully");



                }


            }
            catch (Exception ex)
            {

                return Result<MenuCagResponse>.Failure("error is here bro", $"{ex.Message}");
            }
        }

        public async Task<Result<MenuCagResponse>> DeleteMenuCag(int id)
        {
            try
            {

                using (IDbConnection conn = _db.CreateConnection())
                {
                    string query = @"UPDATE [dbo].[MenuCategories] 
                 SET [IsDelete] = 1, 
                     [DeletedAt] = GETDATE() 
                 WHERE id = @id";

                 
                    int affectedRows = await conn.ExecuteAsync(query, new { id });

                    if (affectedRows == 0)
                    {
                        return Result<MenuCagResponse>.Failure("No record found with this ID.", "Not Found");
                    }

                    return Result<MenuCagResponse>.Success(null, "Menu Category deleted successfully.");
                }


            }
            catch (Exception ex)
            {

                return Result<MenuCagResponse>.Failure($"  {ex.Message} ", "An error occurred");
            }
        }


        public async Task<Result<MenuCagResponse>> UpdateMenuCag( MenuCagRequest request)
        {
            try
            {

                using (IDbConnection conn = _db.CreateConnection())
                {
                    string query = @"
                       UPDATE [dbo].[MenuCategories] 
                                     SET [MenuCag_Name] = @MenuCag_Name,
                                      [MenuCag_Des] = @MenuCag_Des,
                                         [UpdatedAt] = GETDATE()
                                           WHERE id = @id";


                    int result = await conn.ExecuteAsync(query, request);

                    if (result == 0)
                    {
                        return Result<MenuCagResponse>.Failure("No record found with this ID.", "Not Found");
                    }

                    return Result<MenuCagResponse>.Success(null, "Menu Category Update successfully.");
                }


            }
            catch (Exception ex)
            {

                return Result<MenuCagResponse>.Failure($"  {ex.Message} ", "An error occurred");
            }
        }
    }
    }


