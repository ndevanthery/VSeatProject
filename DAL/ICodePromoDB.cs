using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICodePromoDB
    {

        public CodePromo AddCodePromo(CodePromo codePromo);
        public CodePromo GetCode(string codeString);

        public List<CodePromo> GetCodes(int idRestaurant);


    }
}
