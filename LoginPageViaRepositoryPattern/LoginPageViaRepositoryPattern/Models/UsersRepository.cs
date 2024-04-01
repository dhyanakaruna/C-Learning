using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginPageViaRepositoryPattern.Models;
using Npgsql;

namespace LoginPageViaRepositoryPattern.Models
{
    public class UsersRepository : IUsers
    {
        private NpgsqlConnection connect = new NpgsqlConnection("Host=postgres;Database = test;Username =admin;Password=admin");
        private NpgsqlCommand command = new NpgsqlCommand();
        private NpgsqlDataReader dr;

        private string str;

        public UsersRepository(string str)
        {
            this.str = str;
        }

        public bool FindDuplicate(string email)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * From tblUsers where email='" + email + "'";
            dr = com.ExecuteReader();

            List<Users> u = new List<Users>();

            while (dr.Read())
            {
                var x = new Users
                {
                    fullname = dr.GetString(0),
                    email=dr.GetString(1),
                    password=dr.GetString(3)
                };

                u.Add(x);
            }

            con.Close();

            if (u.Count >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Register(Users u)
        {

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "Insert into tblUsers values ('" + u.fullname + "','" + u.email + "','" + u.password + "')";
                com.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch (Exception)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                return false;
            }
        }

        public bool Verify(string email, string password)
        {
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from tblUsers where email='" + email + "' and password='" + password + "'";
            dr = com.ExecuteReader();

            List<Users> u = new List<Users>();

            while(dr.Read())
            {
                var x = new Users()
                {
                    fullname = dr.GetString(0),
                    email = dr.GetString(1),
                    password = dr.GetString(2),
                    confirmpass = null
                };

                u.Add(x);
            }

            con.Close();

            if (u.Count==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
