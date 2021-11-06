using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestoTypeManager
    {
        private IRestoTypeDB restoTypeDB { get; }

        public RestoTypeManager(IConfiguration conf)
        {
            restoTypeDB = new RestoTypeDB(conf);
        }


        //---------------------------------------------------
        // ADD METHOD
        //---------------------------------------------------
        public RestoType AddRestoType(RestoType restoType)
        {
            return restoTypeDB.AddRestoType(restoType);
        }


        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------
        public RestoType GetRestoType(int idType)
        {
            return restoTypeDB.GetRestoType(idType);
        }
        //---------------------------------------------------
        // UPDATE METHOD
        //---------------------------------------------------
        public RestoType UpdateRestoType(int idType, RestoType newRestoType)
        {
            return restoTypeDB.UpdateRestoType(idType, newRestoType);
        }
        //---------------------------------------------------
        // DELETE METHOD
        //---------------------------------------------------
        public RestoType DeleteRestoType(int idType)
        {
            return restoTypeDB.DeleteRestotype(idType);
        }
        //---------------------------------------------------
        // GET LIST METHODS
        //---------------------------------------------------
        

        public List<RestoType> GetRestoTypes()
        {
            return restoTypeDB.GetRestoTypes();
        }









    }
}
