using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;

namespace horizon_travels_and_tours
{
    class CustomerClass
    {
        DBconnect connect = new DBconnect();

        public bool insertCustomer(string fname, string lname, string address, DateTime birthday, string gender, string phone, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO customer( CustomerFirstName, CustomerLastName, Address, Birthday, Gender, Phone, Email, Photo) VALUES(@fn, @ln, @add, @bd, @ge, @ph, @em, @im)", connect.getconnection);

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@add", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = birthday;
            command.Parameters.Add("@ge", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@im", MySqlDbType.Blob).Value = img;

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
        public DataTable getCustomerList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM customer", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public string exeCount (string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getconnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }
        public string totalCustomers()
        {
            return exeCount("SELECT COUNT(*) FROM customer;");
        }
        public DataTable searchCustomer (string searchdata)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM customer WHERE CONCAT( CustomerFirstName,CustomerLastName,Address) LIKE '%"+ searchdata+"%'", connect.getconnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateCustomer(int id,string fname, string lname, string address, DateTime birthday, string gender, string phone, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("UPDATE customer SET CustomerFirstName=@fn,CustomerLastName=@ln,Address=@add,Birthday=@bd,Gender=@ge ,Phone=@ph,Email=@em ,Photo=@im  WHERE CustomerId=@id", connect.getconnection);
            //@fn,@ln,@add,@bd,@ge,@ph,@em,@im
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@add", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = birthday;
            command.Parameters.Add("@ge", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@im", MySqlDbType.Blob).Value = img;

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

        public bool deleteteCustomer(int id, string fname, string lname, string address, DateTime birthday, string gender, string phone, string email, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `customer` WHERE `CustomerId`= @id;", connect.getconnection);
            //@fn,@ln,@add,@bd,@ge,@ph,@em,@im
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@add", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = birthday;
            command.Parameters.Add("@ge", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@im", MySqlDbType.Blob).Value = img;

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