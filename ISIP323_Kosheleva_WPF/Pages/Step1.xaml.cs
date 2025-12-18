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
    /// Логика взаимодействия для Step1.xaml
    /// </summary>
        public partial class Step1 : Page
        {
            public Step1()
            {
                InitializeComponent();
            }

            private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if ((sender as ListBox).SelectedItem is ListBoxItem choice)
                {
                    string selectedEngine = choice.Content.ToString();
                    tb.Content = "Вы выбрали: " + selectedEngine;
                    Base.EngineType = selectedEngine;

                    if (selectedEngine.Contains("norm")) Base.EnginePrice = 50000;
                    else if (selectedEngine.Contains("rare")) Base.EnginePrice = 65000;
                    else if (selectedEngine.Contains("epic")) Base.EnginePrice = 100000;
                    else if (selectedEngine.Contains("mimimi")) Base.EnginePrice = 333000;
                    else if (selectedEngine.Contains("legendary")) Base.EnginePrice = 250000;

                    ButtonNext.Visibility = Visibility.Visible;
                }
            }

            private void ButtonNext_Click(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrEmpty(Base.Model) && !string.IsNullOrEmpty(Base.EngineType))
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow.GoToNextStep("Step2");
                }
                else
                {
                    MessageBox.Show("Выберите модель и тип двигателя!");
                }
            }

            private void ModelButton1_Checked(object sender, RoutedEventArgs e)
            {
                Base.Model = "Принцесса";
                Base.ModelBasePrice = 5000000;
                GridBottom.Visibility = Visibility.Visible;
            }

            private void ModelButton2_Checked(object sender, RoutedEventArgs e)
            {
                Base.Model = "Бэха";
                Base.ModelBasePrice = 1450999;
                GridBottom.Visibility = Visibility.Visible;
            }

            private void ModelButton3_Checked(object sender, RoutedEventArgs e)
            {
                Base.Model = "Скороход";
                Base.ModelBasePrice = 2280000;
                GridBottom.Visibility = Visibility.Visible;
            }

            private void ModelButton4_Checked(object sender, RoutedEventArgs e)
            {
                Base.Model = "Москвич обычный";
                Base.ModelBasePrice = 1488000;
                GridBottom.Visibility = Visibility.Visible;
            }
        }

    }

