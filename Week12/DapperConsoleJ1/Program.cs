using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DapperConsoleJ1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123;");

            var result = db.Query("CustOrderHist", new { CustomerId = "ALFKI" }, commandType: CommandType.StoredProcedure);
            Console.WriteLine(result);
        }
    }
}
