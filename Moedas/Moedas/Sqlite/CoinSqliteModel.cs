using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moedas.Sqlite
{
    [Table("lista")]
    public class CoinSqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string simbolo { get; set; }
        [MaxLength(250), Unique]
        public string nomeFormatado { get; set; }
        public string tipoMoeda { get; set; }
        
    }
  
}
