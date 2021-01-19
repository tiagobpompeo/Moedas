using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moedas.Sqlite
{
    public class LocalDataService
    {
        public static LocalDataService Current { get; private set; } = new LocalDataService();

        public SQLiteConnection Connection { get; private set; }

        private LocalDataService() 
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "datamoedas.db");
            Connection = new SQLiteConnection(path);
            Connection.CreateTable<CoinSqliteModel>();        
        }

        public TableQuery<T> Query<T>() where T : new() =>
           Connection.Table<T>();

        public T GetSingle<T>() where T : new()
            => Connection.Table<T>().SingleOrDefault();

        public void SetSingle<T>(T item) where T : new()
        {
            Connection.DeleteAll<T>();
            Connection.Insert(item);
        }

        public void InsertInList<T>(T item) where T : new()
        {
            Connection.Insert(item);
        }

        public void Clean()
        {
                var tables = Connection.TableMappings
                .Where(m => m.MappedType.FullName.ToLower().Contains("lista"));
            foreach (var table in tables)
            {
                Connection.DeleteAll(table);
            }
        }

        public void Update(object item)
        {
            Connection.InsertOrReplace(item);
        }

        public void Delete(object item) =>
            Connection.Delete(item);

        public void Delete<T>() =>
            Connection.DeleteAll<T>();


    }

}

