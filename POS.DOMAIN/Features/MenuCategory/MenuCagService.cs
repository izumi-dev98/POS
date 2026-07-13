using Dapper;
using Microsoft.AspNetCore.Mvc;
using POS.DATABASE;
using POS.DOMAIN.Features.MenuCategory.Models;
using POS.DOMAIN.Features.MenuCategory.SQLQuery;
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
               

                    var result = await conn.QueryAsync<MenuCagResponse>(SQLMenuCagQuery.GetAllMenuCag);

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
                   

                    var sr = await conn.QueryFirstOrDefaultAsync<MenuCagResponse>(SQLMenuCagQuery.GetByMenuCagName, request);

                    if (sr != null)
                    {
                        if (sr.IsDelete == 1) {



                            await conn.ExecuteAsync(SQLMenuCagQuery.restoreQuery, new
                            {
                                sr.id

                            });


                            return Result<MenuCagResponse>.Success(sr, "Your Data Is Already Exit , Restore is successFully");
                        }

                        return Result<MenuCagResponse>.Failure("Menu Category is Already Exit", "Duplicate Category");
                    }

                   

                    await conn.ExecuteAsync(SQLMenuCagQuery.createMenuCagQuery, request);

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
                   
                 
                    int affectedRows = await conn.ExecuteAsync(SQLMenuCagQuery.deleteMenucCagQuery, new { id });

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
                    


                    int result = await conn.ExecuteAsync(SQLMenuCagQuery.UpdateMenuCagQuery, request);

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

        public async Task<Result<MenuCagResponse>> PatchMenuCag(int id, MenuCagRequest request)
        {
            try
            {

              using(IDbConnection conn = _db.CreateConnection())
                {
                    var updateFields = new List<string>();
                    var para = new DynamicParameters();

                    para.Add("id", id);

                    if(request.MenuCag_Name is not null)
                    {
                        updateFields.Add("MenuCag_Name = @MenuCag_Name");
                        para.Add("MenuCag_Name", request.MenuCag_Name);
                    }

                    if(request.MenuCag_Des is not null)
                    {
                        updateFields.Add("MenuCag_Des = @MenuCag_Des");
                        para.Add("MenuCag_Des", request.MenuCag_Des);
                    }

                 
                    if (updateFields.Count == 0)
                        return Result<MenuCagResponse>.Failure("No fields provided to update.", "Bad Request");

                    updateFields.Add("UpdatedAt = GETDATE()");

                    string fullsql = SQLMenuCagQuery.PatchBase + string.Join(",", updateFields) + SQLMenuCagQuery.PatchFooter;

                    int result = await conn.ExecuteAsync(fullsql, para);

                    if(result > 0)
                    {
                        return Result<MenuCagResponse>.Success(null, "Update Is Success");
                    } else
                    {
                        return Result<MenuCagResponse>.Failure( "Update Is Fail" ,"An Error occured");
                    }
                }

            }
            catch (Exception ex)
            {

                return Result<MenuCagResponse>.Failure($"  {ex.Message} ", "An error occurred");
            }
        }
    }
    }


