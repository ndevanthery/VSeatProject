using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class CodePromoManager : ICodePromoManager
    {
        private ICodePromoDB CodePromoDB { get; }

        public CodePromoManager(ICodePromoDB codePromoDB)
        {
            CodePromoDB = codePromoDB;
        }

        public CodePromo GetCode(string codeString)
        {
            return CodePromoDB.GetCode(codeString);
        }
    }
}
