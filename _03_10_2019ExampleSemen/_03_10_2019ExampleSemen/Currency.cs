using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_10_2019ExampleSemen
{
    [JsonObject]
    public class Currency
    {
        [JsonProperty("ccy")]
        public string ccy { get; set; }
        [JsonProperty("base_ccy")]
        public string base_ccy { get; set; }
        [JsonProperty("buy")]
        public double buy { get; set; }
        [JsonProperty("sale")]
        public double sale { get; set; }
    }
}
