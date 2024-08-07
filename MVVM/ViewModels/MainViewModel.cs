using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNoter.Data;
using TaskNoter.MVVM.Models;

namespace TaskNoter.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class MainViewModel
    {
        public DBService DBService { get; }
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }


        public MainViewModel(DBService dbService) 
        {
            DBService = dbService;
            
            Tasks = new ObservableCollection<MyTask>(); // Initialize the collection
            Categories = new ObservableCollection<Category>(); // Initialize the collection
            
            Tasks.CollectionChanged += Tasks_CollectionChanged;

            LoadDBData().ConfigureAwait(false);
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        public async Task LoadDBData()
        {

            var DBcategory = await DBService.GetCategory();
            foreach (var category in DBcategory)
            {
                Categories.Add(category);
            }

            var DBtasks = await DBService.GetTask();
            foreach (var task in DBtasks)
            {
                Tasks.Add(task);
            }

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;


                c.PendingTasks = notCompleted.Count();
                c.Percentage = tasks.Any() ? (float)completed.Count() / tasks.Count() : 0;
            }

            foreach (var t in Tasks)
            {
                var categoryColour =
                    (from c in Categories
                     where c.Id == t.CategoryId
                     select c.Color).FirstOrDefault();
                t.TaskColor = categoryColour ?? "defaultColor";
            }
        } 
    }
}
