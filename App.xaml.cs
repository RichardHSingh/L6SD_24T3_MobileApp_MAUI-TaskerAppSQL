using TaskNoter.MVVM.Views;
using TaskNoter.Data;
using TaskNoter.MVVM.Models;
using System.Collections.ObjectModel;

namespace TaskNoter
{
    public partial class App : Application
    {
        private readonly DBService _dbService;
        private readonly ObservableCollection<MyTask> _tasks;
        private readonly ObservableCollection<Category> _categories;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // ============================== 
            // ====== TESTING PURPOSES ====== 
            // ============================== 
            // MainPage = new MainView();
            // MainPage = new LandingPage();
            // MainPage = new NewTaskView();
            _dbService = serviceProvider.GetRequiredService<DBService>();
            _tasks = new ObservableCollection<MyTask>();
            _categories = new ObservableCollection<Category>();

            MainPage = new NavigationPage(new LandingPage(_dbService, _tasks, _categories));
        }
    }
}
