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
    public class StaffManager
    {
        private IStaffDB staffDB { get; }

        public StaffManager(IConfiguration conf)
        {
            staffDB = new StaffDB(conf);
        }


        // add method
        public Staff AddStaff(Staff staff)
        {
            return staffDB.AddStaff(staff);

        }


        // get by one method
        public Staff GetStaff(int idStaff)
        {
            return staffDB.getStaff(idStaff);
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

        public List<Staff> GetStaffs(int idRestaurant)
        {
            return staffDB.GetStaffs(idRestaurant);
        }




    }
}
