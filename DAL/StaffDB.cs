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
        private IConfiguration Configuration { get; }

        public StaffDB(IConfiguration conf)
        {
            Configuration = conf;
        }

        public Staff GetStaff(string username)
        {
            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from STAFF WHERE USERNAME = @Username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Username", username);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        staff = new Staff();
                        staff.ID_STAFF = (int)dr["ID_STAFF"];
                        staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        staff.NAME = (string)dr["NAME"];
                        staff.SURNAME = (string)dr["SURNAME"];
                        staff.ADRESS = (string)dr["ADRESS"];
                        staff.POSTALCODE = (string)dr["POSTALCODE"];
                        staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                        staff.PASSWORD = (string)dr["PASSWORD"];
                        staff.USERNAME = (string)dr["USERNAME"];


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }

        public Staff GetStaff(string name, string surname)
        {
            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from STAFF WHERE NAME = @Name AND SURNAME = @Surname";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Surname", surname);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        staff = new Staff();
                        staff.ID_STAFF = (int)dr["ID_STAFF"];
                        staff.ID_RESTAURANT = (int)dr["ID_RESTAURANT"];
                        staff.NAME = (string)dr["NAME"];
                        staff.SURNAME = (string)dr["SURNAME"];
                        staff.ADRESS = (string)dr["ADRESS"];
                        staff.POSTALCODE = (string)dr["POSTALCODE"];
                        staff.PHONENUMBER = (string)dr["PHONENUMBER"];
                        staff.PASSWORD = (string)dr["PASSWORD"];
                        staff.USERNAME = (string)dr["USERNAME"];


                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }

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
                            staff.NAME = (string)dr["NAME"];
                            staff.SURNAME = (string)dr["SURNAME"];
                            staff.ADRESS = (string)dr["ADRESS"];
                            staff.POSTALCODE = (string)dr["POSTALCODE"];
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
                throw e;
            }

            return results;
        }

        public Staff AddStaff(Staff staff)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into STAFF(ID_STAFF,ID_RESTAURANT,NAME,SURNAME,ADRESS,POSTALCODE,PHONENUMBER,PASSWORD,USERNAME) values(@ID_RESTAURANT,@NAME,@SURNAME,@ADRESS,@POSTALCODE,@PHONENUMBER,@PASSWORD,@USERNAME); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@ID_RESTAURANT", staff.ID_RESTAURANT);
                    cmd.Parameters.AddWithValue("@NAME", staff.NAME);
                    cmd.Parameters.AddWithValue("@SURNAME", staff.SURNAME);
                    cmd.Parameters.AddWithValue("@ADRESS", staff.ADRESS);
                    cmd.Parameters.AddWithValue("@POSTALCODE", staff.POSTALCODE);
                    cmd.Parameters.AddWithValue("@PHONENUMBER", staff.PHONENUMBER);
                    cmd.Parameters.AddWithValue("@PASSWORD", staff.PASSWORD);
                    cmd.Parameters.AddWithValue("@USERNAME", staff.USERNAME);

                    cn.Open();

                    staff.ID_STAFF = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }
    }
}
