using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moedas.Models
{
    public class CoinsModel
    {
       
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Value> value { get; set; }
        public class Value
        {
            public string simbolo { get; set; }
            public string nomeFormatado { get; set; }
            public string tipoMoeda { get; set; }
        }
    }
}
