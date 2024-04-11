using System.Collections.ObjectModel;
using Verion.Presentation.View;

namespace MusicStoreApp.ViewModels.Veiculo;

public class ModeloApresentacaoConfiguracaoVeiculoGuia : ViewModelBase
{
    public ModeloApresentacaoConfiguracaoVeiculoGuia()
    {

        NomeBotoesSeletor = new ObservableCollection<InfoBotoes>
        {
            new("Configurações", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
            new("Veículo", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
            new("GPS", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
            new("Trabalho", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
            new("Dados", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
            new("Meu Aplicativo", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
            new("Voltar", SvgIcons.ImageSvg, new SynchronizedCommand(() => { }, SynchronizationBehavior.Discard, true)),
        };
    }
    
    public ObservableCollection<InfoBotoes> NomeBotoesSeletor { get; }
}