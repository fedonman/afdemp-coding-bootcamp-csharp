using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace adonet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // REMEMBER TO CHANGE CONNECTION STRING FOR YOUR SERVER/DATABASE
                using (SqlConnection conn = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Customers";
                        cmd.Connection = conn;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("SELECT * FROM Customers");
                            Console.WriteLine("Results");
                            while (reader.Read())
                            {
                                string contactName = (string)reader["ContactName"];
                                string city = (string)reader["City"];

                                Console.Write(String.Format("{0, -20}, {1, -10}\n", contactName, city));
                            }
                            Console.WriteLine();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "Ten Most Expensive Products";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = conn;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Procedure: Ten Most Expensive Products");
                            Console.WriteLine("Results");
                            while (reader.Read())
                            {
                                string name = (string)reader["TenMostExpensiveProducts"];
                                //Console.WriteLine(name);
                            }
                            Console.WriteLine();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SalesByCategory";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        string category = "Seafood";
                        cmd.Parameters.Add(new SqlParameter("CategoryName", category));
                        cmd.Connection = conn;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Procedure: Ten Most Expensive Products, Category: " + category);
                            Console.WriteLine("Results");
                            while (reader.Read())
                            {
                                try
                                {
                                    string name = (string)reader[0];
                                    decimal price = (decimal)reader[2];
                                    Console.Write(String.Format("{0, -20}, {1,-10}\n", name, price));
                                }
                                catch (InvalidCastException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch (IndexOutOfRangeException e1)
                                {
                                    Console.WriteLine(e1);
                                }
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    Console.WriteLine("Error: " + ex.Errors[i].ToString());
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
