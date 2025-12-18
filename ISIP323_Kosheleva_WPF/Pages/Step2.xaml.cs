using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ISIP323_Kosheleva_WPF.Pages
{
    public partial class Step2 : Page
    {
        private Dictionary<string, double> colorPrices = new Dictionary<string, double>
        {
            { "PinckColor", 100000 },   
            { "BlueColor", 20000 },    
            { "BlackColor", 15000 },    
            { "WhiteColor", 10000 },    
            { "SilverColor", 25000 }    
        };

        private Dictionary<string, double> optionPrices = new Dictionary<string, double>
        {
            { "Option1", 150000 },  
            { "Option2", 200000 },  
            { "Option3", 50000 },   
            { "Option4", 75000 },   
            { "Option5", 40000 },   
            { "Option6", 30000 },   
            { "Option7", 100000 }  
        };

        public Step2()
        {
            InitializeComponent();
            Loaded += Step2_Loaded;
            NextButton.Click += NextButton_Click;
        }

        private void Step2_Loaded(object sender, RoutedEventArgs e)
        {
            RestoreSelections();

            UpdateMainWindowProgress(50); 
        }

        private void RestoreSelections()
        {
            if (!string.IsNullOrEmpty(Base.Color))
            {
                switch (Base.Color)
                {
                    case "Гламурно Розовый (+100к)":
                        PinckColor.IsChecked = true;
                        break;
                    case "Нежно голубой (+20k)":
                        BlueColor.IsChecked = true;
                        break;
                    case "Черный (+15k)":
                        BlackColor.IsChecked = true;
                        break;
                    case "Белый (+10k)":
                        WhiteColor.IsChecked = true;
                        break;
                    case "Серебристый (+25k)":
                        SilverColor.IsChecked = true;
                        break;
                }
            }

            if (Base.AddOptions != null && Base.AddOptions.Count > 0)
            {
                foreach (var option in Base.AddOptions)
                {
                    switch (option)
                    {
                        case "Кожаный салон (+150к)":
                            Option1.IsChecked = true;
                            break;
                        case "Панорамная крыша (+200к)":
                            Option2.IsChecked = true;
                            break;
                        case "Подогрев сидений (+50к)":
                            Option3.IsChecked = true;
                            break;
                        case "Чот (+75к)":
                            Option4.IsChecked = true;
                            break;
                        case "Что-то еще (+40к)":
                            Option5.IsChecked = true;
                            break;
                        case "Камера заднего вида (+30к)":
                            Option6.IsChecked = true;
                            break;
                        case "Чот крутое (+100к)":
                            Option7.IsChecked = true;
                            break;
                    }
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsColorSelected())
            {
                MessageBox.Show("Пожалуйста, выберите цвет автомобиля!", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveSelectedColor();

            SaveSelectedOptions();

            NavigationService?.Navigate(new Step3());
        }

        private bool IsColorSelected()
        {
            return PinckColor.IsChecked == true ||
                   BlueColor.IsChecked == true ||
                   BlackColor.IsChecked == true ||
                   WhiteColor.IsChecked == true ||
                   SilverColor.IsChecked == true;
        }

        private void SaveSelectedColor()
        {
            var selectedColorRadio = FindSelectedColorRadio();
            if (selectedColorRadio != null)
            {
                var stackPanel = selectedColorRadio.Content as StackPanel;
                if (stackPanel?.Children[0] is TextBlock textBlock)
                {
                    Base.Color = textBlock.Text;
                }
            }
        }

        private RadioButton FindSelectedColorRadio()
        {
            if (PinckColor.IsChecked == true) return PinckColor;
            if (BlueColor.IsChecked == true) return BlueColor;
            if (BlackColor.IsChecked == true) return BlackColor;
            if (WhiteColor.IsChecked == true) return WhiteColor;
            if (SilverColor.IsChecked == true) return SilverColor;
            return null;
        }

        private void SaveSelectedOptions()
        {
            Base.AddOptions = new List<string>();

            if (Option1.IsChecked == true) Base.AddOptions.Add("Кожаный салон (+150к)");
            if (Option2.IsChecked == true) Base.AddOptions.Add("Панорамная крыша (+200к)");
            if (Option3.IsChecked == true) Base.AddOptions.Add("Подогрев сидений (+50к)");
            if (Option4.IsChecked == true) Base.AddOptions.Add("Чот (+75к)");
            if (Option5.IsChecked == true) Base.AddOptions.Add("Что-то еще (+40к)");
            if (Option6.IsChecked == true) Base.AddOptions.Add("Камера заднего вида (+30к)");
            if (Option7.IsChecked == true) Base.AddOptions.Add("Чот крутое (+100к)");
        }

        private void UpdateMainWindowProgress(int progress)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.SetProgress(progress);
        }

        public double CalculateOptionsPrice()
        {
            double total = 0;

            if (Option1.IsChecked == true) total += optionPrices["Option1"];
            if (Option2.IsChecked == true) total += optionPrices["Option2"];
            if (Option3.IsChecked == true) total += optionPrices["Option3"];
            if (Option4.IsChecked == true) total += optionPrices["Option4"];
            if (Option5.IsChecked == true) total += optionPrices["Option5"];
            if (Option6.IsChecked == true) total += optionPrices["Option6"];
            if (Option7.IsChecked == true) total += optionPrices["Option7"];

            return total;
        }

        public double CalculateColorPrice()
        {
            var selectedRadio = FindSelectedColorRadio();
            if (selectedRadio != null && colorPrices.ContainsKey(selectedRadio.Name))
            {
                return colorPrices[selectedRadio.Name];
            }
            return 0;
        }
    }
}