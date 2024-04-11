using System.Windows.Input;

namespace MusicStoreApp.ViewModels.Veiculo;

public class InfoBotoes
{
    private readonly string nomeBotao;
    private readonly string svgString;
    private readonly ICommand comandoBotao;

    public InfoBotoes(string nomeBotao, string svgString, ICommand comandoBotao)
    {
        this.nomeBotao = nomeBotao;
        this.svgString = svgString;
        this.comandoBotao = comandoBotao;
    }

    public string NomeBotao => nomeBotao;
    public string SvgString => svgString;
    public ICommand ComandoBotao => comandoBotao;
}