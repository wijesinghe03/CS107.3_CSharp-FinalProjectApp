using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace horizon_travels_and_tours
{
    internal class packageClass
    {
        DBconnect connect = new DBconnect();

        public bool insertPackage(string pName, string pdescription, string country, int price, int days, byte[] pimage)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `package` (`Package_Name`, `Description`, `Country`, `Package_Price`, `Days`, `Image`, `Booked`) VALUES (@pn, @pd, @pc, @pp, @pda, @pi, 0)", connect.getconnection);
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = pName;
            command.Parameters.Add("@pd", MySqlDbType.VarChar).Value = pdescription;
            command.Parameters.Add("@pc", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@pp", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@pda", MySqlDbType.Int32).Value = days;
            command.Parameters.Add("@pi", MySqlDbType.Blob).Value = pimage;
            connect.openConnect();

            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public DataTable getPackageList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `package`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }
        public string totalpackages()
        {
            return exeCount("SELECT COUNT(*) FROM package;");
        }
        public bool bookpackage(int pid)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE `package` SET `Booked` = 1 WHERE `PackageId` = @pid", connect.getconnection);
                command.Parameters.Add("@pid", MySqlDbType.Int32).Value = pid;
                connect.openConnect();

                int rowsAffected = command.ExecuteNonQuery();
                connect.closeConnect();

                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
               

                Console.WriteLine("Error booking package: " + ex.Message);
                return false;
            }
        }

        public DataTable searchPackageList(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `package` WHERE CONCAT(`Package_Name`,`Country`) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updatePackage(int pid, string pName, string pdescription, string country, int price, int days, byte[] pimage)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `package` SET `Package_Name`=@pn, `Description`=@pd, `Country`=@pc, `Package_Price`=@pp, `Days`=@pda, `Image`=@pi WHERE `PackageId`= @pid", connect.getconnection);

            command.Parameters.Add("@pid", MySqlDbType.Int32).Value = pid;
            command.Parameters.Add("@pn", MySqlDbType.VarChar).Value = pName;
            command.Parameters.Add("@pd", MySqlDbType.VarChar).Value = pdescription;
            command.Parameters.Add("@pc", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@pp", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@pda", MySqlDbType.Int32).Value = days;
            command.Parameters.Add("@pi", MySqlDbType.Blob).Value = pimage;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deletePackage(int pid)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `package` WHERE `PackageId` = @pid", connect.getconnection);

            command.Parameters.Add("@pid", MySqlDbType.Int32).Value = pid;

            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
    }
}
