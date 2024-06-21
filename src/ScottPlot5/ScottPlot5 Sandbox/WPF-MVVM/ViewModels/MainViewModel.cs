using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottPlot;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPF_MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public enum IntensityChoices
        {
            MonaLisa, SinWave
        }

        public MainViewModel()
        {
            IntensityMap = SampleData.MonaLisa();
            Choices = Enum.GetNames(typeof(IntensityChoices));
            SelectedChoice = IntensityChoices.MonaLisa.ToString();

            PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void MainViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedChoice))
            {
                ChangeIntensityMap(Enum.Parse<IntensityChoices>(SelectedChoice!));  
            }
        }

        [RelayCommand]
        void ChangeIntensityMap(IntensityChoices value)
        {
            if (value == IntensityChoices.MonaLisa)
            {
                IntensityMap = SampleData.MonaLisa();
            }
            else
            {
                IntensityMap = Generate.Sin2D(65, 100);
            }
        }

        [ObservableProperty]
        double[,]? intensityMap;

        [ObservableProperty]
        string[] choices;

        [ObservableProperty]
        string? selectedChoice;

        [ObservableProperty]
        bool flipVertically;

        [ObservableProperty]
        bool flipHorizontally;
    }
}
