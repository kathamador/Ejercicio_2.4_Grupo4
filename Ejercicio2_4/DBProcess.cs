using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_4
{
    public class DBProcess
    {
        readonly SQLiteAsyncConnection _connection;
        public DBProcess() { }
        public DBProcess(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            _connection.CreateTableAsync<signaturess>().Wait();
        }

        public Task<int> Agregar(signaturess signaturess)
        {
            if(signaturess.Id == 0)
            {
                return _connection.InsertAsync(signaturess);
            }
            else
            {
                return _connection.UpdateAsync(signaturess);
            }
        }

        public Task<List<signaturess>> GetAll()
        {
            return _connection.Table<signaturess>().ToListAsync();
        }
    }
}
