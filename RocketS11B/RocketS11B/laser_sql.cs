using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RocketS11B
{
    class laser_sql
    {
        public static string dbServerName = System.Environment.MachineName;

        public static SqlConnection cnn;
        public static string connectString;

        public static SqlConnection S11_cnn;
        public static string S11_connectString;

        public static void ProductsInit(IDataRecord datareader)
        {
            S11_connectString = "Data source=" + dbServerName + "\\SQLEXPRESS;Initial Catalog=S112_BDD;User Id=sa;Password=s@;MultipleActiveResultSets=True";
            using (var connection = new SqlConnection(S11_connectString))
            {
                connection.Open();
                string strCommand = "SELECT * FROM Products WHERE name=@ref";
                using (var cmdProducts = new SqlCommand(strCommand, connection))
                {
                    cmdProducts.Parameters.AddWithValue("@ref", datareader["name"]);
                    var r = cmdProducts.ExecuteReader();
                    if (!r.Read())
                    {
                        string query = "INSERT INTO Products(id,designation,name,idLaser,idVision,modifId,poleCount,sensitivity,rating," +
                                                            "S112_Enable,S112_Field401,S112_Field402,S112_Field403,S112_Field404,S112_Field405,S112_Field406,S112_Field407,S112_Field408,S112_Field409," +
                                                            "S112_Field411,S112_Field412,S112_Field413,S112_Field415,S112_Field416,S112_Field417,LaserProNo,LaserFileName) " +
                                       "VALUES(@id,@designation,@name,@idLaser,@idVision,@modifId,@poleCount,@sensitivity,@rating," +
                                                            "@S112_Enable,@S112_Field401,@S112_Field402,@S112_Field403,@S112_Field404,@S112_Field405,@S112_Field406,@S112_Field407,@S112_Field408,@S112_Field409," +
                                                            "@S112_Field411,@S112_Field412,@S112_Field413,@S112_Field415,@S112_Field416,@S112_Field417,@LaserProNo,@LaserFileName)";
                        using (var cmdAddProductToS112 = new SqlCommand(query, connection))
                        {
                            cmdAddProductToS112.Parameters.AddWithValue("@id", datareader["id"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@designation", datareader["designation"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@name", datareader["name"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@idLaser", datareader["idLaser"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@idVision", datareader["idVision"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@modifId", datareader["modifId"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@poleCount", datareader["poleCount"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@sensitivity", datareader["sensitivity"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@rating", datareader["rating"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Enable", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field401", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field402", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field403", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field404", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field405", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field406", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field407", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field408", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field409", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field411", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field412", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field413", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field415", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field416", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field417", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@LaserProNo", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@LaserFileName", "");

                            var rowsAffected = cmdAddProductToS112.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static SqlDataReader S11_Products(string ir)
        {
            S11_connectString = "Data source=" + dbServerName + "\\SQLEXPRESS;Initial Catalog=S112_BDD;User Id=sa;Password=s@;MultipleActiveResultSets=True";
            using (var connection = new SqlConnection(S11_connectString))
            {
                connection.Open();
                string strCommand = "SELECT * FROM Products WHERE name=@ref";
                using (var cmdProducts = new SqlCommand(strCommand, connection))
                {
                    cmdProducts.Parameters.AddWithValue("@ref", ir);
                    return cmdProducts.ExecuteReader();
                }
            }
        }

        public static void LaserMarkingInit(IDataRecord datareader)
        {
            S11_connectString = "Data source=" + dbServerName + "\\SQLEXPRESS;Initial Catalog=S112_BDD;User Id=sa;Password=s@;MultipleActiveResultSets=True";
            using (var connection = new SqlConnection(S11_connectString))
            {
                connection.Open();
                string strCommand = "SELECT * FROM LaserMarking WHERE id=@id";
                using (var cmdProducts = new SqlCommand(strCommand, connection))
                {
                    cmdProducts.Parameters.AddWithValue("@id", datareader["idLaser"]);
                    var r = cmdProducts.ExecuteReader();
                    if (!r.Read())
                    {
                        string query = "INSERT INTO Products(id,name,designation," +
                                                            "S112_Enable,S112_Field401,S112_Field402,S112_Field403,S112_Field404,S112_Field405,S112_Field406,S112_Field407,S112_Field408,S112_Field409," +
                                                            "S112_Field411,S112_Field412,S112_Field413,S112_Field415,S112_Field416,S112_Field417,S112_LaserProNo,S112_LaserFileName) " +
                                       "VALUES(@id,@name,@designation," +
                                                            "@S112_Enable,@S112_Field401,@S112_Field402,@S112_Field403,@S112_Field404,@S112_Field405,@S112_Field406,@S112_Field407,@S112_Field408,@S112_Field409," +
                                                            "@S112_Field411,@S112_Field412,@S112_Field413,@S112_Field415,@S112_Field416,@S112_Field417,@S112_LaserProNo,@S112_LaserFileName)";
                        using (var cmdAddProductToS112 = new SqlCommand(query, connection))
                        {
                            cmdAddProductToS112.Parameters.AddWithValue("@id", datareader["id"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@name", datareader["name"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@designation", datareader["designation"]);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Enable", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field401", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field402", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field403", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field404", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field405", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field406", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field407", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field408", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field409", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field411", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field412", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field413", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field415", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field416", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_Field417", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_LaserProNo", 0);
                            cmdAddProductToS112.Parameters.AddWithValue("@S112_LaserFileName", "");

                            var rowsAffected = cmdAddProductToS112.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


    }
}
