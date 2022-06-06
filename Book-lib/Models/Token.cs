using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_lib.Models
{
    public class Token
    {
        public string token { get; set; }
        public string expiresAt { get; set; }

        public Token()
        {

        }

        public override string ToString()
        {
            return token.ToString();
        }
    }
}
