using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using YieldReturn_VK_363.Models;
using YieldReturn_VK_363.ViewModels;

namespace YieldReturn_VK_363.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel list;
    public MainWindow()
    {
        InitializeComponent();
        list = new MainWindowViewModel();
        NumbersList.ItemsSource = list.Numbers;
    }

    private async void Button_GenerateNumbers(object? sender, RoutedEventArgs e)
    {
        if (int.TryParse(StartValue.Text, out int startValue) &&
            int.TryParse(EndValue.Text, out int endValue) &&
            startValue <= endValue)
        {
            list.Numbers.Clear();
            ProgressBar.Value = 0;

            var numberGenerator = new NumberGenerator();
            var numbers = numberGenerator.GenerateNumbers(startValue, endValue).ToList();
            foreach (var (number, idx) in numbers.Select((num, idx) => (num, idx)))
            {
                list.Numbers.Add(number);
                ProgressBar.Value = ((idx + 1) / (double)numbers.Count);

                await Task.Delay(363);
            }
        }
    }
}