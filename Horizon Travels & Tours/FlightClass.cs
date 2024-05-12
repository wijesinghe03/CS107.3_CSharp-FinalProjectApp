using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;



namespace horizon_travels_and_tours
{
    internal class FlightClass
    {
        DBconnect connect = new DBconnect();

        
            public bool insetFlight(string triptype, string from, string to, string airline, string phone, DateTime departure, DateTime ret)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `flight`(`Triptype`, `From`, `To`, `AirLine`, `Phone`, `Departure`, `Return`) VALUES (@ft,@ff,@fto,@fa,@fp,@fd,@fr);", connect.getconnection);

                command.Parameters.Add("@ft", MySqlDbType.VarChar).Value = triptype;
                command.Parameters.Add("@ff", MySqlDbType.VarChar).Value = from;
                command.Parameters.Add("@fto", MySqlDbType.VarChar).Value = to;
                command.Parameters.Add("@fa", MySqlDbType.VarChar).Value = airline;
                command.Parameters.Add("@fp", MySqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@fd", MySqlDbType.DateTime).Value = departure;
                command.Parameters.Add("@fr", MySqlDbType.DateTime).Value = ret;

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

        

        /* public DataTable getFlightList()
         {
             MySqlCommand command = new MySqlCommand("SELECT * FROM `flight`", connect.getconnection);
             MySqlDataAdapter adapter = new MySqlDataAdapter(command);
             DataTable table = new DataTable();
             adapter.Fill(table);
             return table;
         }

         */
        public bool bookFlight(int fid)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE `flight` SET `Booked` = 1 WHERE `FlightId` = @fid", connect.getconnection);
                command.Parameters.Add("@fid", MySqlDbType.Int32).Value = fid;
                connect.openConnect();

                int rowsAffected = command.ExecuteNonQuery();
                connect.closeConnect();

                return rowsAffected == 1;
            }
            catch (Exception ex)
            {


                Console.WriteLine("Error booking flight: " + ex.Message);
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
        public DataTable getFlightList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `flight`", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
        

