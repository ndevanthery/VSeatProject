using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public interface IRestoTypeManager
    {
        public RestoType AddRestoType(RestoType restoType);
        public RestoType GetRestoType(int idType);
        public RestoType UpdateRestoType(int idType, RestoType newRestoType);
        public RestoType DeleteRestoType(int idType);
        public List<RestoType> GetRestoTypes();


    }
}
