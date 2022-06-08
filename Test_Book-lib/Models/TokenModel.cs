using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_lib.Models
{
    public class TokenModel
    {
        public string token { get; set; }
        public string expiresAt { get; set; }

        public TokenModel()
        {

        }

        public override string ToString()
        {
            return token.ToString();
        }
    }
}
