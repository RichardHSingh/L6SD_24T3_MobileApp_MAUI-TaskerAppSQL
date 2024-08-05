using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;

namespace TaskNoter.Data
{
    public class DBService
    {
        private const string DB_Name = "TaskNoter_DB.db3";

        private readonly SQLiteAsyncConnection _database;


        public DBService()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_Name));
            _database.CreateTableAsync<DBTaskItems>().Wait();
        }


        public Task<List<DBTaskItems>> GetTaskAsync()
        {
            return _database.Table<DBTaskItems>().ToListAsync();
        }


        public Task<int> SaveTaskAsync(DBTaskItems task)
        {
            if (task.Id != 0)
            {
                return _database.UpdateAsync(task);
            }
            else
            {
                return _database.InsertAsync(task);
            }

        }
        public Task<int> DeleteTaskAsync(DBTaskItems task)
        {
            return _database.DeleteAsync(task);
        }
    }
}
