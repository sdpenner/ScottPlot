using System.Windows;
using ScottPlot;
using ScottPlot.Plottables;

namespace Sandbox.WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //WpfPlot1.Plot.Add.Signal(Generate.Sin());
        //WpfPlot1.Plot.Add.Signal(Generate.Cos());

        //double[,] data = SampleData.MonaLisa();

        Image baboon = new Image("media\\baboon-gray.png");
        var hm1 = WpfPlot1.Plot.Add.Heatmap(baboon);
        hm1.Colormap = new ScottPlot.Colormaps.Turbo();

    }
}
