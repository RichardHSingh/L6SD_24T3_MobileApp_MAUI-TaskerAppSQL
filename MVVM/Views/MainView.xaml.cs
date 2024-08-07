using TaskNoter.MVVM.ViewModels;
using TaskNoter.Data;
using System.Collections.ObjectModel;
using TaskNoter.MVVM.Models;



namespace TaskNoter.MVVM.Views;

public partial class MainView : ContentPage
{
    private readonly DBService _dbService;
    private readonly ObservableCollection<MyTask> _tasks;
    private readonly ObservableCollection<Category> _categories;

    private MainViewModel mainViewModel;

	public MainView(DBService dbService, ObservableCollection<MyTask> tasks, ObservableCollection<Category> categories)
    {
		InitializeComponent();

        mainViewModel = new MainViewModel(dbService);
        BindingContext = mainViewModel;
        _tasks = tasks;
        _categories = categories;
    }

    private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView(mainViewModel.DBService, mainViewModel.Tasks, mainViewModel.Categories);
                   
        Navigation.PushModalAsync(taskView);
    }


}