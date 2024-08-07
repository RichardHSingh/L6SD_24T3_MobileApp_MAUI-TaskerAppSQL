using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TaskNoter.MVVM.Models;
using TaskNoter.Data;


namespace TaskNoter.MVVM.ViewModels
{
    
    public class NewTaskViewModel
    {
        private readonly DBService _dbService;

        public string Task {  get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; } 
        public ObservableCollection<Category> Categories { get; set; }

        public NewTaskViewModel(DBService dbService, ObservableCollection<MyTask> tasks, ObservableCollection<Category> categories)
        {
            _dbService = dbService;
            Tasks = tasks;
            Categories = categories;            
        }

        public async Task AddTask(MyTask task)
        {
            await _dbService.CreateTask(task);
            Tasks.Add(task);
        }

        public async Task AddCategory(Category category)
        {
            await _dbService.CreateCategory(category);
            Categories.Add(category);
        }
    }
}
