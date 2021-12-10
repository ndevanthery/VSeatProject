using DAL;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{ 
    public class StaffManager : IStaffManager
    {
        private IStaffDB staffDB { get; }

        public StaffManager(IConfiguration conf)
        {
            staffDB = new StaffDB(conf);
        }


        public Staff loginStaff(string username, string password)
        {

            Staff loggedStaff = new Staff();

            var staffs = GetStaffs();

            foreach (var staff in staffs)
            {
                if (staff.USERNAME == username && staff.PASSWORD == password)
                {
                    Console.WriteLine("staff found and logged");
                    loggedStaff = staff;

                    return loggedStaff;
                }

            }


            Console.WriteLine("staff username or password incorrect");
            return null;

        }

        // add method
        public Staff AddStaff(Staff staff)
        {
            return staffDB.AddStaff(staff);

        }


        // get by one method
        public Staff GetStaff(int idStaff)
        {
            return staffDB.GetStaff(idStaff);
        }


        //update method
        public Staff UpdateStaff(int idStaff,Staff newStaff)
        {
            return staffDB.UpdateStaff(idStaff, newStaff);
        }

        // delete method

        public Staff DeleteStaff(int idStaff)
        {
            return staffDB.DeleteStaff(idStaff);
        }


        // get by lists methods

        public List<Staff> GetStaffs()
        {
            return staffDB.GetStaffs();
        }

        public List<Staff> GetStaffs(int idCity)
        {
            return staffDB.GetStaffs(idCity);
        }




    }
}
