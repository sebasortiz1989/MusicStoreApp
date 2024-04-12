using System.Collections.ObjectModel;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels.Veiculo;
using Verion.Apresentacao.Avalonia.Buttons;

namespace MusicStoreApp.Views.Veiculo;

public partial class TelaConfiguracaoPrincipal : ReactiveWindow<ModeloApresentacaoConfiguracaoVeiculoGuia>
{
    private Collection<CustomButton> buttonList;

    public TelaConfiguracaoPrincipal()
    {
        InitializeComponent();
        buttonList = new Collection<CustomButton> { BottaoVeiculo, BotaoGps, BotaoTrabalho, BotaoDados, BotaoMeuAplicativo };
        BottaoVeiculo.IsCheckedChanged += OnIsCheckedChangedVeiculoEvent;
        BotaoGps.IsCheckedChanged += OnIsCheckedChangedGpsEvent;
        BotaoTrabalho.IsCheckedChanged += OnIsCheckedChangedTrabalhoEvent;
        BotaoDados.IsCheckedChanged += OnIsCheckedChangedDadosEvent;
        BotaoMeuAplicativo.IsCheckedChanged += OnIsCheckedChangedMeuAplicativoEvent;
    }

    private void OnIsCheckedChangedVeiculoEvent(CustomButton customButton, bool arg2)
    {
        if (customButton is not { IsChecked: true }) return;

        foreach (var button in buttonList)
        {
            if (button.ButtonText != customButton.ButtonText)
                button.IsChecked = false;
        }
        
        // ContentControlConfiguracao.Content =
    }

    private void OnIsCheckedChangedGpsEvent(CustomButton customButton, bool arg2)
    {
        if (customButton is not { IsChecked: true }) return;

        foreach (var button in buttonList)
        {
            if (button.ButtonText != customButton.ButtonText)
                button.IsChecked = false;
        }

        // ContentControlConfiguracao.Content =
    }

    private void OnIsCheckedChangedTrabalhoEvent(CustomButton customButton, bool arg2)
    {
        if (customButton is not { IsChecked: true }) return;

        foreach (var button in buttonList)
        {
            if (button.ButtonText != customButton.ButtonText)
                button.IsChecked = false;
        }

        // ContentControlConfiguracao.Content =
    }

    private void OnIsCheckedChangedDadosEvent(CustomButton customButton, bool arg2)
    {
        if (customButton is not { IsChecked: true }) return;

        foreach (var button in buttonList)
        {
            if (button.ButtonText != customButton.ButtonText)
                button.IsChecked = false;
        }

        // ContentControlConfiguracao.Content =
    }

    private void OnIsCheckedChangedMeuAplicativoEvent(CustomButton customButton, bool arg2)
    {
        if (customButton is not { IsChecked: true }) return;

        foreach (var button in buttonList)
        {
            if (button.ButtonText != customButton.ButtonText)
                button.IsChecked = false;
        }

        // ContentControlConfiguracao.Content =
    }
}