using ScottPlot;
using ScottPlot.WPF;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

namespace WPF_MVVM.Controls
{
    public class HeatMapControl : WpfPlot
    {
        protected Heatmap Heatmap { get; private set; }

        public HeatMapControl()
        {
            Heatmap = Plot.Add.Heatmap(SampleData.MonaLisa());
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            
            switch (e.Property.Name)
            {
                case nameof(IntensityArray):
                    Heatmap.Intensities = IntensityArray;
                    Refresh();
                    break;
                case nameof(FlipVertically):
                    Heatmap.FlipVertically = FlipVertically;
                    Refresh();
                    break;
                case nameof(FlipHorizontally):
                    Heatmap.FlipHorizontally = FlipHorizontally;
                    Refresh();
                    break;
                default:
                    break;
            }
        }

        public double[,] IntensityArray
        {
            get { return (double[,])GetValue(IntensityArrayProperty); }
            set { SetValue(IntensityArrayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IntensityArray.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntensityArrayProperty =
            DependencyProperty.Register(nameof(IntensityArray), typeof(double[,]), typeof(HeatMapControl));

        public bool FlipVertically
        {
            get { return (bool)GetValue(FlipVerticallyProperty); }
            set { SetValue(FlipVerticallyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlipVertically.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlipVerticallyProperty =
            DependencyProperty.Register(nameof(FlipVertically), typeof(bool), typeof(HeatMapControl));

        public bool FlipHorizontally
        {
            get { return (bool)GetValue(FlipHorizontallyProperty); }
            set { SetValue(FlipHorizontallyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FlipHorizontally.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FlipHorizontallyProperty =
            DependencyProperty.Register(nameof(FlipHorizontally), typeof(bool), typeof(HeatMapControl));

    }
}
