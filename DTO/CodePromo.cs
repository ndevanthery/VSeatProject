using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CodePromo
    {
        public int ID_CODEPROMO { get; set; }
        public int ID_RESTAURANT { get; set; }
        public string CODEPROMO { get; set; }
        public int DISCOUNT { get; set; }
    }
}
