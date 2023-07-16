using CommunityToolkit.Mvvm.Input;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<string> MyItems { get; set; }

    public ReactiveCommand<Unit, Task> BtnCommand { get; }

    public MainViewModel()
    {
        MyItems = new() { "开始" };

        BtnCommand = ReactiveCommand.Create(Btn);
    }


    private async Task Btn()
    {
        await Task.Run(() =>
         {
             for (int i = 10; i < 20; i++)
             {
                 MyItems.Add($"第{i}项");
             }
         });
    }
    [RelayCommand]
    private async Task Rl()
    {
        await Task.Run(() =>
        {
            for (int i = 20; i < 30; i++)
            {
                MyItems.Add($"第{i}项");
            }
        });
    }
}
