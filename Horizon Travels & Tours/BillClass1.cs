using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace horizon_travels_and_tours
{
    internal class BillClass1
    {
        DBconnect connect = new DBconnect();
        public bool insertforbill(string cuid, string paid, string hoid, string country, string total, DateTime date, string signature)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO forbill(BCustomer_ID, BPackage_ID, BHotel_ID, Country, Total_Price, Date, Siganature) VALUES (@eci,@epi,@ehi,@bc,@bt,@bd,@bs)", connect.getconnection);

            //@eci,@epi,@ehi,@bc,@bt,@bd,@bs
            command.Parameters.Add("@eci", MySqlDbType.VarChar).Value = cuid;
            command.Parameters.Add("@epi", MySqlDbType.VarChar).Value = paid;
            command.Parameters.Add("@ehi", MySqlDbType.VarChar).Value = hoid;
            command.Parameters.Add("@bc", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@bt",MySqlDbType.VarChar).Value = total;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = date;
            command.Parameters.Add("@bs", MySqlDbType.VarChar).Value = signature;

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
      
        
      
        public DataTable searchBill(string BillingId)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM forbill WHERE BCustomer_Id = @bid OR BPackage_Id = @bid OR BHotel_Id = @bid", connect.getconnection);
            command.Parameters.Add("@bid", MySqlDbType.VarChar).Value = BillingId;
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
        public bool printbill(int BillingId)
        {
            
            return true;
        }

        public DataTable getBillDetails(int BillingId)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `forbill` WHERE `Billing_ID`=@bid", connect.getconnection);
            // Convert BillingId to string before passing to parameter
            command.Parameters.AddWithValue("@bid", BillingId.ToString());
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}

