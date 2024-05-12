using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace horizon_travels_and_tours
{
    internal class TravelClass
    {
        DBconnect connect = new DBconnect();

        public bool insetTravel(string tcid, string thid, string tpid, string tfid, string vn)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `travel`( `TCustomer_Id`, `THotel_Id`, `TPackage_Id`, `TFlight_Id`, `Visa_Number`) VALUES (@tc,@th,@tp,@tf,@vn);", connect.getconnection);

            command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tcid;
            command.Parameters.Add("@th", MySqlDbType.VarChar).Value = thid;
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tpid;
            command.Parameters.Add("@tf", MySqlDbType.VarChar).Value = tfid;
            command.Parameters.Add("@vn", MySqlDbType.VarChar).Value = vn;
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
        public DataTable getTravelList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `travel`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchTravel(string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM  `travel` WHERE CONCAT( TCustomer_Id) LIKE '%" + searchdata + "%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateTravel(int tid, string tcid, string thid, string tpid, string tfid, string vn)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `travel` SET TCustomer_Id=@tc,THotel_Id=@th,TPackage_Id=@tp,TFlight_Id=@tf,`Visa_Number`=@vn WHERE TravelID=@tid;", connect.getconnection);
            command.Parameters.Add("@tid", MySqlDbType.Int32).Value = tid; // Corrected to Int32
            command.Parameters.Add("@tc", MySqlDbType.VarChar).Value = tcid;
            command.Parameters.Add("@th", MySqlDbType.VarChar).Value = thid;
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tpid;
            command.Parameters.Add("@tf", MySqlDbType.VarChar).Value = tfid;
            command.Parameters.Add("@vn", MySqlDbType.VarChar).Value = vn;
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

        public bool deleteTravel(int tid, string tcid, string thid, string tpid, string tfid, string vn)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `travel` WHERE `TravelID`=@tid;", connect.getconnection);
            command.Parameters.Add("@tid", MySqlDbType.Int32).Value = tid; // Corrected to Int32
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
        public bool printtravel(int TravelId)
        {

            return true;
        }
        public DataTable getTravelDetails(int TravelId)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `travel` WHERE `TravelID`=@tid", connect.getconnection);
            // Convert BillingId to string before passing to parameter
            command.Parameters.AddWithValue("@tid", TravelId.ToString());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }


    }
}
