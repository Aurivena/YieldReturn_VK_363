using System.Collections.ObjectModel;

namespace YieldReturn_VK_363.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<int> Numbers { get; set; } = new ObservableCollection<int>();
}