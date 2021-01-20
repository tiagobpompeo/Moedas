using System;
using System.Collections.Generic;
using System.Text;

namespace Moedas.Constants
{
    public static class ApiConstants
    {
        public const string BaseApiUrl = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/";
        public const string Api_key = "xxxxxxxxxxx";
        public const string Cotacao = "CotacaoDolarDia";
        public const string Moedas = "Moedas?$top=100&$format=json";

    }
}
