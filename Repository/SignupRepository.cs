using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;
using CrudSignup.Models;
using System.Reflection;
using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;

namespace CrudSignup.Repository
{
    public class SignupRepository
    {
        string conString = ConfigurationManager.ConnectionStrings["SignupRepository"].ToString();

        //Get all the User Details
        public List<Signup_page> GetUserById()
        { 

            List<Signup_page> signup_list = new List<Signup_page>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserById";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                da.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                    signup_list.Add(
                        new Signup_page
                        {
                            UserId = Convert.ToInt32(dr["UserId"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            EmailAddress = Convert.ToString(dr["EmailAddress"]),
                            Address = Convert.ToString(dr["Address"]),
                            State = Convert.ToString(dr["State"]),
                            City = Convert.ToString(dr["City"]),
                            UserName = Convert.ToString(dr["UserName"]),
                            Password = Convert.ToString(dr["Password"])

                        });
                return signup_list;
            }
        }

        // Create a New user

        public bool InsertUser(Signup_page sign)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("InsertUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirsName", sign.FirstName);
                command.Parameters.AddWithValue("@LastName", sign.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", sign.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", sign.Gender);
                command.Parameters.AddWithValue("@EmailAddress", sign.EmailAddress);
                command.Parameters.AddWithValue("@Address", sign.Address);
                command.Parameters.AddWithValue("@State", sign.State);
                command.Parameters.AddWithValue("@City", sign.City);
                command.Parameters.AddWithValue("@UserName", sign.UserName);
                command.Parameters.AddWithValue("@Password", sign.Password);

                connection.Open();
                id= command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Get a Selected User Details


        public List<Signup_page> GetaUserById(int id)
        {
            List<Signup_page> signup_list = new List<Signup_page>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Select_User";
                command.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                da.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                    signup_list.Add(
                        new Signup_page
                        {
                            UserId = Convert.ToInt32(dr["UserId"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            EmailAddress = Convert.ToString(dr["EmailAddress"]),
                            Address = Convert.ToString(dr["Address"]),
                            State = Convert.ToString(dr["State"]),
                            City = Convert.ToString(dr["City"]),
                            UserName = Convert.ToString(dr["UserName"]),
                            Password = Convert.ToString(dr["Password"])

                        });
                return signup_list;
            }
        }


        // Update the user Details


        public bool UpdateUser(Signup_page sign)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserId", sign.UserId);
                command.Parameters.AddWithValue("@FirstName", sign.FirstName);
                command.Parameters.AddWithValue("@LastName", sign.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", sign.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", sign.Gender);
                command.Parameters.AddWithValue("@EmailAddress", sign.EmailAddress);
                command.Parameters.AddWithValue("@Address", sign.Address);
                command.Parameters.AddWithValue("@State", sign.State);
                command.Parameters.AddWithValue("@City", sign.City);
                command.Parameters.AddWithValue("@UserName", sign.UserName);
                command.Parameters.AddWithValue("@Password", sign.Password);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Delete the user details

        public string DeleteUser(int id)
        {

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return connection.ConnectionString;
            }
        }


        // Sign

        public bool login(Signup_page signup)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("Authentication_Login", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", signup.UserName);
                command.Parameters.AddWithValue("@Password", signup.Password);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
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