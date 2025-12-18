using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISIP323_Kosheleva_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Step3.xaml
    /// </summary>
    public partial class Step3 : Page
    {
        public Step3()
        {
            InitializeComponent();
            Loaded += Step3_Loaded;
            NextButton.Click += NextButton_Click;
        }

        private void Step3_Loaded(object sender, RoutedEventArgs e)
        {
            Base.CalculateTotalPrice();

            PricePanel.Children.Clear();
            ConfigPanel.Children.Clear();

            AddPriceRow("Базовая цена модели:", Base.ModelBasePrice.ToString("N0") + " ₽");
            AddPriceRow("Двигатель:", Base.EnginePrice.ToString("N0") + " ₽");
            AddPriceRow("Цвет:", Base.ColorPrice.ToString("N0") + " ₽");
            AddPriceRow("Доп. опции:", Base.OptionsPrice.ToString("N0") + " ₽");

           
            var separator = new Separator() { Margin = new Thickness(0, 5, 0, 5) };
            PricePanel.Children.Add(separator);

            TotalText.Text = Base.TotalPrice.ToString("N0") + " ₽";

            AddConfigRow("Модель:", Base.Model);
            AddConfigRow("Двигатель:", Base.EngineType);
            AddConfigRow("Цвет:", Base.Color);

            if (Base.AddOptions.Count > 0)
            {
                AddConfigRow("Опции:", "");
                foreach (var option in Base.AddOptions)
                {
                    AddConfigRow("  •", option);
                }
            }
        }

        private void AddPriceRow(string label, string value)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 2, 0, 2) };
            stackPanel.Children.Add(new TextBlock { Text = label, Width = 150 });
            stackPanel.Children.Add(new TextBlock { Text = value, FontWeight = FontWeights.Bold });
            PricePanel.Children.Add(stackPanel);
        }

        private void AddConfigRow(string label, string value)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 2, 0, 2) };
            stackPanel.Children.Add(new TextBlock { Text = label, FontWeight = FontWeights.SemiBold, Width = 100 });
            stackPanel.Children.Add(new TextBlock { Text = value });
            ConfigPanel.Children.Add(stackPanel);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GoToNextStep("Step4");
        }


    }
}
