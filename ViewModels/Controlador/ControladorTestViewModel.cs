using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace MusicStoreApp.ViewModels.Controlador;

public class ControladorTestViewModel : ViewModelBase
{
    public ICommand CustomCommand { get; }

    public ControladorTestViewModel()
    {
        CustomCommand = ReactiveCommand.CreateFromTask(Execute);
    }

    private Task Execute()
    {
        var a = 1;
        return Task.CompletedTask;
    }
}