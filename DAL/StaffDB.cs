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
                    string query = "Insert into STAFF(IDCITY,FIRSTNAME,LASTNAME,ADRESS,PHONENUMBER,USERNAME,PASSWORD,image_url,confirmed,email) values(@IDCITY,@FIRSTNAME,@LASTNAME,@ADRESS,@PHONENUMBER,@USERNAME,@PASSWORD,@image_url,@confirmed,@email); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", staff.IDCITY);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", staff.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", staff.LASTNAME);

                    if(staff.ADRESS==null)
                    {
                        cmd.Parameters.AddWithValue("@ADRESS", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ADRESS", staff.ADRESS);

                    }
                    if (staff.PHONENUMBER == null)
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", staff.PHONENUMBER);

                    }
                    cmd.Parameters.AddWithValue("@USERNAME", staff.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", staff.PASSWORD);

                    if (staff.image_url == null)
                    {
                        cmd.Parameters.AddWithValue("@image_url", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_url", staff.image_url);

                    }

                    cmd.Parameters.AddWithValue("@confirmed", staff.confirmed);

                    if (staff.email == null)
                    {
                        cmd.Parameters.AddWithValue("@email", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", staff.email);

                    }


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
                        while (dr.Read())
                        {
                            staff = new Staff();
                            staff.ID_STAFF = (int)dr["ID_STAFF"];
                            staff.IDCITY = (int)dr["IDCITY"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            if (dr["ADRESS"] != DBNull.Value)
                            {
                                staff.ADRESS = (string)dr["ADRESS"];

                            }
                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                staff.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];
                            if(dr["image_url"]!=DBNull.Value)
                            {
                                staff.image_url = (string)dr["image_url"];

                            }
                            staff.confirmed = (bool)dr["confirmed"];
                            if(dr["email"] != DBNull.Value)
                            {
                                staff.email = (string)dr["email"];

                            }

                        }
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

        public Staff UpdateStaff(int idStaff, Staff newStaff)
        {

            Staff staff = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE STAFF SET IDCITY = @IDCITY , FIRSTNAME= @FIRSTNAME , LASTNAME = @LASTNAME , ADRESS = @ADRESS , PHONENUMBER =@PHONENUMBER, USERNAME=@USERNAME, PASSWORD = @PASSWORD, image_url = @image_url , confirmed = @confirmed,email=@email WHERE ID_STAFF = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", newStaff.IDCITY);
                    cmd.Parameters.AddWithValue("@FIRSTNAME", newStaff.FIRSTNAME);
                    cmd.Parameters.AddWithValue("@LASTNAME", newStaff.LASTNAME);

                    if (newStaff.ADRESS == null)
                    {
                        cmd.Parameters.AddWithValue("@ADRESS", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ADRESS", newStaff.ADRESS);

                    }
                    if (newStaff.PHONENUMBER == null)
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PHONENUMBER", newStaff.PHONENUMBER);

                    }
                    cmd.Parameters.AddWithValue("@USERNAME", newStaff.USERNAME);
                    cmd.Parameters.AddWithValue("@PASSWORD", newStaff.PASSWORD);

                    if (newStaff.image_url == null)
                    {
                        cmd.Parameters.AddWithValue("@image_url", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@image_url", newStaff.image_url);

                    }

                    cmd.Parameters.AddWithValue("@confirmed", newStaff.confirmed);

                    if (newStaff.email == null)
                    {
                        cmd.Parameters.AddWithValue("@email", DBNull.Value);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@email", newStaff.email);

                    }


                    cmd.Parameters.AddWithValue("@id", idStaff);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            staff = new Staff();
                            staff.ID_STAFF = (int)dr["ID_STAFF"];
                            staff.IDCITY = (int)dr["IDCITY"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            if (dr["ADRESS"] != DBNull.Value)
                            {
                                staff.ADRESS = (string)dr["ADRESS"];

                            }
                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                staff.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];
                            if (dr["image_url"] != DBNull.Value)
                            {
                                staff.image_url = (string)dr["image_url"];

                            }
                            staff.confirmed = (bool)dr["confirmed"];
                            if (dr["email"] != DBNull.Value)
                            {
                                staff.email = (string)dr["email"];

                            }
                        }


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

                        while (dr.Read())
                        {
                            staff = new Staff();
                            staff.ID_STAFF = (int)dr["ID_STAFF"];
                            staff.IDCITY = (int)dr["IDCITY"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            if (dr["ADRESS"] != DBNull.Value)
                            {
                                staff.ADRESS = (string)dr["ADRESS"];

                            }
                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                staff.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];
                            if (dr["image_url"] != DBNull.Value)
                            {
                                staff.image_url = (string)dr["image_url"];

                            }
                            staff.confirmed = (bool)dr["confirmed"];
                            if (dr["email"] != DBNull.Value)
                            {
                                staff.email = (string)dr["email"];

                            }
                        }

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
                            staff.IDCITY = (int)dr["IDCITY"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            if (dr["ADRESS"] != DBNull.Value)
                            {
                                staff.ADRESS = (string)dr["ADRESS"];

                            }
                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                staff.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];
                            if (dr["image_url"] != DBNull.Value)
                            {
                                staff.image_url = (string)dr["image_url"];

                            }
                            staff.confirmed = (bool)dr["confirmed"];
                            if (dr["email"] != DBNull.Value)
                            {
                                staff.email = (string)dr["email"];

                            }

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

        public List<Staff> GetStaffs(int idCity)
        {
            List<Staff> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from STAFF WHERE IDCITY = @IDCITY";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IDCITY", idCity);
                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Staff>();

                            Staff staff = new Staff();

                            staff.ID_STAFF = (int)dr["ID_STAFF"];
                            staff.IDCITY = (int)dr["IDCITY"];
                            staff.FIRSTNAME = (string)dr["FIRSTNAME"];
                            staff.LASTNAME = (string)dr["LASTNAME"];
                            if (dr["ADRESS"] != DBNull.Value)
                            {
                                staff.ADRESS = (string)dr["ADRESS"];

                            }
                            if (dr["PHONENUMBER"] != DBNull.Value)
                            {
                                staff.PHONENUMBER = (string)dr["PHONENUMBER"];

                            }
                            staff.PASSWORD = (string)dr["PASSWORD"];
                            staff.USERNAME = (string)dr["USERNAME"];
                            if (dr["image_url"] != DBNull.Value)
                            {
                                staff.image_url = (string)dr["image_url"];

                            }
                            staff.confirmed = (bool)dr["confirmed"];
                            if (dr["email"] != DBNull.Value)
                            {
                                staff.email = (string)dr["email"];

                            }

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
