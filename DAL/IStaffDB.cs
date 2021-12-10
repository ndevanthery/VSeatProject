using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStaffDB
    {

        //add

        public Staff AddStaff(Staff staff);



        //get Staff

        public Staff GetStaff(int idStaff);


        //update Staff

        public Staff UpdateStaff(int idStaff, Staff newStaff);

        //delete Staff

        public Staff DeleteStaff(int idStaff);


        //get Lists

        public List<Staff> GetStaffs();

        public List<Staff> GetStaffs(int idCity);



    }
}
