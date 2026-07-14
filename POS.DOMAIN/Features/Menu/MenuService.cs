using Dapper;
using POS.DATABASE;
using POS.DOMAIN.Features.Menu.Models;
using POS.DOMAIN.Features.Menu.SQLquery;
using POS.SHARED;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DOMAIN.Features.Menu
{
    public class MenuService :IMenu
    {
        private readonly DbconnectionFactory _db;

        public MenuService(DbconnectionFactory db) { 
        
            _db = db;
        }

        public async Task<Result<IEnumerable<MenuResponse>>> GetAllMenu()
        {
            try { 
             
                using(IDbConnection conn = _db.CreateConnection())
                {

                    var result = await conn.QueryAsync<MenuResponse>(SQLMenuQuery.GetAllMenu);

                    return Result<IEnumerable<MenuResponse>>.Success(result, "Data is Here");

                }
              
            }
            catch (Exception ex)
            {

                return Result<IEnumerable<MenuResponse>>.Failure("An Error Found", $"{ex.Message}");
            }
        }


        public async Task<Result<MenuResponse>> CreateMenu(MenuRequest request)
        {
            try
            {

                using (IDbConnection conn = _db.CreateConnection())
                {


                    var sr = await conn.QueryFirstOrDefaultAsync<MenuResponse>(SQLMenuQuery.GetByName, request);

                    if(sr is not null)
                    {
                        if( sr.IsDelete == 1 || sr.Status == 0 )
                        {

                            await conn.ExecuteAsync(SQLMenuQuery.Restore, new
                            {
                                sr.id
                            });

                            return Result<MenuResponse>.Success(sr, "Your Menu is Restore Successfully");
                        }

                        return Result<MenuResponse>.Failure("Your Menu is Aleady Exit ", "Duplitade Menu");

                    }

                    await conn.ExecuteAsync(SQLMenuQuery.CreateMenu, request);

                    return Result<MenuResponse>.Success(null, "New Menu Is Create Success");
                

                }

            }
            catch (Exception ex)
            {

                return Result<MenuResponse>.Failure("An Error Found", $"{ex.Message}");

                
            }
        }
    }
}
