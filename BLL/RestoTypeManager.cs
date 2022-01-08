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
    public class RestoTypeManager : IRestoTypeManager
    {
        private IRestoTypeDB restoTypeDB { get; }

        public RestoTypeManager(IRestoTypeDB RestoTypeDB)
        {
            restoTypeDB = RestoTypeDB;
        }



        //---------------------------------------------------
        // GET ONE METHOD
        //---------------------------------------------------
        public RestoType GetRestoType(int idType)
        {
            return restoTypeDB.GetRestoType(idType);
        }

    }
}
