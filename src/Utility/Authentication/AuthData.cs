using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Authentication
{
    public class AuthData
    {
        public  string Issuer { get; set; } = string.Empty;

        public  string SignKey { get; set; } = string.Empty;
    }
}
