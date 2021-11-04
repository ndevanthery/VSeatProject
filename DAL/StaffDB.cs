using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StaffDB : IStaffDB
    {

        //---------------------------------------------------
        // CONFIGURATION
        //---------------------------------------------------

        private IConfiguration Configuration { get; }

        public StaffDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------

        public Staff AddStaff(Staff staff)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into STAFF(ID_RESTAURANT,FIRSTNAME,LASTNAME,ADRESS,PHONENUMBER,USERNAME,PASSWORD) values(@ID_RESTAURANT,@FIRSTNAME,@LASTNAME,@ADRESS,@PHONENUMBER,@USERNAME,@PASSWORD); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", staff.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", staff.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", staff.LASTNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", staff.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", staff.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@USERNAME", staff.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", staff.PASSWORD);

                    cn.Open();

                    staff.ID_STAFF = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return staff;
        }

        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------

        public Staff GetStaff(int idStaff)
        {
            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from STAFF WHERE ID_STAFF = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idStaff);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        staff = new Staff();
                        staff.ID_STAFF = (int)dr["ID_STAFF"];
                        staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                        staff.LASTNAME = (string)dr["LASTNAME"];
                        staff.ADRESS = (string)dr["ADRESS"];
                        staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                        staff.PASSWORD = (string)dr["PASSWORD"];
                        staff.USERNAME = (string)dr["USERNAME"];

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return staff;
        }

        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------

        public Staff UpdateStaff(int idStaff, Restaurant newStaff)
        {

            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE RESTAURANT SET ID_RESTAURANT = @ID_RESTAURANT , FIRSTNAME= @FIRSTNAME , LASTNAME = @LASTNAME , ADRESS = @ADRESS , PHONENUMBER =@PHONENUMBER, USERNAME=@USERNAME, PASSWORD = @PASSWORD WHERE ID_STAFF = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", staff.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", staff.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", staff.LASTNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", staff.ADRESS);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", staff.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@USERNAME", staff.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", staff.PASSWORD);

                    cmd.Parameters.AddWithValue("@id", idStaff);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        staff = new Staff();
                        staff.ID_STAFF = (int)dr["ID_STAFF"];
                        staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                        staff.LASTNAME = (string)dr["LASTNAME"];
                        staff.ADRESS = (string)dr["ADRESS"];
                        staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                        staff.PASSWORD = (string)dr["PASSWORD"];
                        staff.USERNAME = (string)dr["USERNAME"];



                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return staff;
        }


        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------
        public Staff DeleteStaff(int idStaff)
        {
            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM STAFF WHERE ID_STAFF = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idStaff);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        staff = new Staff();
                        staff.ID_STAFF = (int)dr["ID_STAFF"];
                        staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                        staff.LASTNAME = (string)dr["LASTNAME"];
                        staff.ADRESS = (string)dr["ADRESS"];
                        staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                        staff.PASSWORD = (string)dr["PASSWORD"];
                        staff.USERNAME = (string)dr["USERNAME"];

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return staff;
        }


        //---------------------------------------------------
        // GET LISTS METHOD
        //---------------------------------------------------






        public List<Staff> GetStaffs()
        {
            List<Staff> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from STAFF";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Staff>();

                            Staff staff = new Staff();

                            staff.ID_STAFF = (int)dr["ID_STAFF"];
                            staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            staff.ADRESS = (string)dr["ADRESS"];
                            staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];

                            results.Add(staff);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;
        }

        public List<Staff> GetStaffs(int idRestaurant)
        {
            List<Staff> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from STAFF WHERE ID_RESTAURANT = @idRestaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idRestaurant", idRestaurant);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Staff>();

                            Staff staff = new Staff();

                            staff.ID_STAFF = (int)dr["ID_STAFF"];
                            staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            staff.ADRESS = (string)dr["ADRESS"];
                            staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];

                            results.Add(staff);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return results;        
        }
    }
}
