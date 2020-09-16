using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace DapperConsole
{

    class Program
    {
        static void test1()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123;");
            var result = db.Query("select * from customers");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.CustomerID} {item.CompanyName}");
            }
        }

        static void test2()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123;");
            var result = db.Query("CustOrderHist", new { CustomerID = "ALFKI" }, commandType: CommandType.StoredProcedure );
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} {item.Total}");
            }
        }

        static void Main(string[] args)
        {
            test2();
        }
    }
}
