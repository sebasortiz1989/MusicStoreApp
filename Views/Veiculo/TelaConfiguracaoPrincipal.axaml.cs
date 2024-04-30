using System.Collections.ObjectModel;
using Avalonia.Input;
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
    }

    private void OnIsCheckedChangedVeiculoEvent(CustomButton customButton, bool arg2)
    {
        if (customButton is not { IsChecked: true }) return;

        foreach (var button in buttonList)
        {
            if (button.ButtonText != customButton.ButtonText)
                button.IsChecked = false;
        }
    }
    private void BottaoVeiculo_OnTapped(object? sender, TappedEventArgs e)
    {
        // ContentControlConfiguracao.Content = 
    }

    private void BotaoGps_OnTapped(object? sender, TappedEventArgs e)
    {
        // ContentControlConfiguracao.Content = 
    }

    private void BotaoTrabalho_OnTapped(object? sender, TappedEventArgs e)
    {
        // ContentControlConfiguracao.Content = 
    }

    private void BotaoDados_OnTapped(object? sender, TappedEventArgs e)
    {
        // ContentControlConfiguracao.Content = 
    }

    private void BotaoMeuAplicativo_OnTapped(object? sender, TappedEventArgs e)
    {
        // ContentControlConfiguracao.Content = 
    }
}