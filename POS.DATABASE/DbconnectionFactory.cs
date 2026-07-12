using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DATABASE
{
    public class DbconnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbconnectionFactory(IConfiguration configuration) {

            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(conn);
        }
            
            
    }
}
