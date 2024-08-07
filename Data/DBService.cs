using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TaskNoter.MVVM.Models;


namespace TaskNoter.Data
{
    public class DBService
    {
        private const string DB_Name = "TaskNoter_DB.db3";

        private readonly SQLiteAsyncConnection _database;


        public DBService()
        {
            _database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_Name));

            // Initialise tables Cat and Task
            InitializeDBTables();
        }

        private async Task InitializeDBTables()
        {
            await _database.CreateTableAsync<MyTask>();
            await _database.CreateTableAsync<Category>();
           
        }

        // ================================================================ 
        // ======================== CRUD FOR TASKS ========================
        // ================================================================
        public async Task<List<MyTask>> GetTask()
        {
            return await _database.Table<MyTask>().ToListAsync();
        }


        public async Task<DBTaskItems> GeTaskById(int id)
        {
            return await _database.Table<DBTaskItems>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateTask(DBTaskItems task)
        {
            await _database.InsertAsync(task);
        }

        public async Task UpdateTask(DBTaskItems task)
        {
            await _database.UpdateAsync(task);

        }

        public async Task DeleteTask(DBTaskItems task)
        {
            await _database.DeleteAsync(task);

        }

        // =================================================================== 
        // ======================== CRUD FOR CATEGORY ========================
        // ===================================================================

        public async Task<List<Category>> GetCategory()
        {
            return await _database.Table<Category>().ToListAsync();
        }


        public async Task<Category> GetCategoryById(int id)
        {
            return await _database.Table<Category>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateCategory(Category category)
        {
            await _database.InsertAsync(category);
        }

        public async Task UpdateCategory(Category category)
        {
            await _database.UpdateAsync(category);

        }

        public async Task DeleteCategory(Category category)
        {
            await _database.DeleteAsync(category);

        }
    }

}
