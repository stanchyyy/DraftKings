using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test_Book_lib.Models
{
    internal class PageinfoModel
    {
        [JsonPropertyName("pageInfo")]
        public string PageInfo { get; set; }
    }
}
