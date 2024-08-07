using System.Collections.ObjectModel;
using TaskNoter.Data;
using TaskNoter.MVVM.Models;


namespace TaskNoter.MVVM.Views;

public partial class LandingPage : ContentPage
{
    private readonly DBService _dbService;
    private readonly ObservableCollection<MyTask> _tasks;
    private readonly ObservableCollection<Category> _categories;


    public LandingPage(DBService dbService, ObservableCollection<MyTask> tasks, ObservableCollection<Category> categories)
    {
		InitializeComponent();
        _dbService = dbService;
        _tasks = tasks;
        _categories = categories;

    }

     private void newTaskBTN_Clicked(object sender, EventArgs e)
     {
        Navigation.PushModalAsync(new NewTaskView(_dbService, _tasks, _categories));
     }

    private void currentTaskBtn_Clicked(object sender, EventArgs e)
    {
        if (_tasks.Any() && _categories.Any())
        {
            Navigation.PushModalAsync(new MainView(_dbService, _tasks, _categories));
        }
        else
        {
            DisplayAlert("Error!", "No TASKS or CATEGORIES given.", "AFFIRMATIVE");
        }
        
    }
}
