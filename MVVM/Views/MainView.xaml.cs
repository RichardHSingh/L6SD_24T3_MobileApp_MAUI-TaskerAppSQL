using TaskNoter.MVVM.ViewModels;
using TaskNoter.Data;



namespace TaskNoter.MVVM.Views;

public partial class MainView : ContentPage
{
    private MainViewModel mainViewModel;

	public MainView(DBService dbservice)
	{
		InitializeComponent();
        mainViewModel = new MainViewModel(dbservice);
        BindingContext = mainViewModel;
	}

    private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView
        {
            BindingContext = new NewTaskViewModel(mainViewModel.DBService, mainViewModel.Tasks, mainViewModel.Categories)
        };
        Navigation.PushAsync(taskView);
    }


}