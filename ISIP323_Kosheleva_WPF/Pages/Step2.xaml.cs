using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ISIP323_Kosheleva_WPF.Pages
{
    public partial class Step2 : Page
    {
        public Step2()
        {
            InitializeComponent();
            Loaded += Step2_Loaded;
            NextButton.Click += NextButton_Click;
        }

        private void Step2_Loaded(object sender, RoutedEventArgs e)
        {
            Base.AddOptions.Clear();
            Base.OptionsPrice = 0;
            Base.Color = "";
            Base.ColorPrice = 0;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (PinckColor.IsChecked == false && BlueColor.IsChecked == false &&
                BlackColor.IsChecked == false && WhiteColor.IsChecked == false &&
                SilverColor.IsChecked == false)
            {
                MessageBox.Show("Выберите цвет автомобиля!");
                return;
            }

            if (PinckColor.IsChecked == true) { Base.Color = "Розовый"; Base.ColorPrice = 100000; }
            else if (BlueColor.IsChecked == true) { Base.Color = "Голубой"; Base.ColorPrice = 20000; }
            else if (BlackColor.IsChecked == true) { Base.Color = "Черный"; Base.ColorPrice = 15000; }
            else if (WhiteColor.IsChecked == true) { Base.Color = "Белый"; Base.ColorPrice = 10000; }
            else if (SilverColor.IsChecked == true) { Base.Color = "Серебристый"; Base.ColorPrice = 25000; }

            Base.AddOptions.Clear();
            Base.OptionsPrice = 0;

            Dictionary<CheckBox, double> optionPrices = new Dictionary<CheckBox, double>
            {
                { Option1, 150000 },
                { Option2, 200000 },
                { Option3, 50000 },
                { Option4, 75000 },
                { Option5, 40000 },
                { Option6, 30000 },
                { Option7, 100000 }
            };

            foreach (var option in optionPrices)
            {
                if (option.Key.IsChecked == true)
                {
                    Base.AddOptions.Add(option.Key.Content.ToString().Split('(')[0].Trim());
                    Base.OptionsPrice += option.Value;
                }
            }

            
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GoToNextStep("Step3");
        }
    }
}