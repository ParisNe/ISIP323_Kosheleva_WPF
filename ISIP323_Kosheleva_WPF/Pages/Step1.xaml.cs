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

        private void SaveModelSelection(string modelName, double price)
        {
            Base.Model = modelName;
            // Можно сохранить базовую цену в статическом поле если нужно
            // Base.BasePrice = price;

            // Обновляем сумму в основном окне
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                // Устанавливаем прогресс на 25%
                mainWindow.SetProgress(25);

                // Обновляем сумму (можно сделать расчет на основе цены)
                mainWindow.SetSum((int)(price / 10000)); // Просто пример расчета
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListBox).SelectedItem is ListBoxItem choice)
            {
                string selectedEngine = choice.Content.ToString();
                tb.Content = "Вы выбрали: " + selectedEngine;
                Base.EngineType = selectedEngine;

                // Показываем кнопку тока когда выбрали двигатель
                ButtonNext.Visibility = Visibility.Visible;
            }
        }

        private void ModelButton1_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image1.Source;
            GridBottom.Visibility = Visibility.Visible;
            SaveModelSelection("Принцесса 5.000.000р", 5000000);
        }

        private void ModelButton2_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image2.Source;
            GridBottom.Visibility = Visibility.Visible;
            SaveModelSelection("Бэха 1.450.999р", 1450999);
        }

        private void ModelButton3_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image3.Source;
            GridBottom.Visibility = Visibility.Visible;
            SaveModelSelection("Скороход 2.280.000р", 2280000);
        }

        private void ModelButton4_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image4.Source;
            GridBottom.Visibility = Visibility.Visible;
            SaveModelSelection("Москвич обычный 1.488.000р", 1488000);
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Base.EngineType))
            {
                MessageBox.Show("Выберите тип двигателя!", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(Base.Model))
            {
                MessageBox.Show("Выберите модель автомобиля!", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NavigationService?.Navigate(new Step2());
        }
    }
}
