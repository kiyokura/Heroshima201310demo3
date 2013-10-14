using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlServerCe;

using Dapper;

namespace Heroshima201310demo3
{
    class Program
    {
        static string constr = "Data Source=App_Data\\Database1.sdf";

        static void Main(string[] args)
        {

            // パターン１
            //using (var cn = new SqlCeConnection(constr))
            //{
            //    cn.Open();

            //    var sql = "select ID, Name , Age , Email From Employee;";
            //    var result = cn.Query(sql);

            //    foreach (var d in result)
            //    {
            //        Console.WriteLine("ID:{0} , Name:{1} , Age:{2} , Email:{3}",
            //                            d.ID,
            //                            d.Name,
            //                            d.Age,
            //                            d.Email);
            //    }
            //}


            // パターン2
            //using (var cn = new SqlCeConnection(constr))
            //{
            //    cn.Open();
            //    var sql = "select ID, Name , Age , Email From Employee;";
            //    var result = cn.Query<EmployeeEntity>(sql);

            //    foreach (var d in result)
            //    {
            //        Console.WriteLine("ID:{0} , Name:{1} , Age:{2} , Email:{3}",
            //                            d.ID,
            //                            d.Name,
            //                            d.Age,
            //                            d.Email);
            //    }
            //}

            // パターン3
            using (var cn = new SqlCeConnection(constr))
            {
                cn.Open();
                var sql = "select ID, Name , Age , Email From Employee where Age > @Age;";
                var result = cn.Query<EmployeeEntity>(sql, new { Age = 25 });

                foreach (var d in result)
                {
                    Console.WriteLine("ID:{0} , Name:{1} , Age:{2} , Email:{3}",
                                        d.ID,
                                        d.Name,
                                        d.Age,
                                        d.Email);
                }
            }

            Console.Read();
        }
    }
}
