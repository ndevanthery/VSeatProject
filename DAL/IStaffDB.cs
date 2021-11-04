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

        //get Lists

        public List<Staff> GetStaffs();

        public List<Staff> GetStaffs(int idRestaurant);



        //get Staff

        public Staff GetStaff(string username);

        public Staff GetStaff(string name, string surname);

        public Staff getStaff(int idStaff);


    }
}
