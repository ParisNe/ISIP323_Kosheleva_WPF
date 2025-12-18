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
            UpdatePricePanel();
            UpdateConfigPanel();
            CalculateTotal();
        }

        private void UpdatePricePanel()
        {
            PricePanel.Children.Clear();

            // Добавляем базовые цены
            double basePrice = GetBaseModelPrice();
            AddPriceItem("Базовая модель", basePrice);

            // Добавляем цену цвета
            double colorPrice = GetColorPrice();
            if (colorPrice > 0)
            {
                AddPriceItem("Цвет", colorPrice);
            }

            // Добавляем дополнительные опции
            double optionsPrice = GetOptionsPrice();
            if (optionsPrice > 0)
            {
                AddPriceItem("Доп. опции", optionsPrice);
            }
        }

        private void UpdateConfigPanel()
        {
            ConfigPanel.Children.Clear();

            // Модель
            if (!string.IsNullOrEmpty(Base.Model))
            {
                AddConfigItem("Модель", Base.Model);
            }

            // Тип двигателя
            if (!string.IsNullOrEmpty(Base.EngineType))
            {
                AddConfigItem("Двигатель", Base.EngineType);
            }

            // Цвет
            if (!string.IsNullOrEmpty(Base.Color))
            {
                AddConfigItem("Цвет", Base.Color);
            }

            // Дополнительные опции
            if (Base.AddOptions != null && Base.AddOptions.Count > 0)
            {
                foreach (var option in Base.AddOptions)
                {
                    AddConfigItem("Опция", option);
                }
            }
        }

        private void CalculateTotal()
        {
            double total = GetBaseModelPrice() + GetColorPrice() + GetOptionsPrice();
            Base.C = total; // Сохраняем общую стоимость
            TotalText.Text = $"{total:N0} ₽";
        }

        private double GetBaseModelPrice()
        {
            if (!string.IsNullOrEmpty(Base.Model))
            {
                if (Base.Model.Contains("Принцесса")) return 5000000;
                if (Base.Model.Contains("Бэха")) return 1450999;
                if (Base.Model.Contains("Скороход")) return 2280000;
                if (Base.Model.Contains("Москвич")) return 1488000;
            }
            return 0;
        }

        private double GetColorPrice()
        {
            if (!string.IsNullOrEmpty(Base.Color))
            {
                if (Base.Color.Contains("Гламурно Розовый")) return 100000;
                if (Base.Color.Contains("Нежно голубой")) return 20000;
                if (Base.Color.Contains("Черный")) return 15000;
                if (Base.Color.Contains("Белый")) return 10000;
                if (Base.Color.Contains("Серебристый")) return 25000;
            }
            return 0;
        }

        private double GetOptionsPrice()
        {
            double total = 0;
            if (Base.AddOptions != null)
            {
                foreach (var option in Base.AddOptions)
                {
                    if (option.Contains("Кожаный салон")) total += 150000;
                    if (option.Contains("Панорамная крыша")) total += 200000;
                    if (option.Contains("Подогрев сидений")) total += 50000;
                    if (option.Contains("Чот (+75к)")) total += 75000;
                    if (option.Contains("Что-то еще")) total += 40000;
                    if (option.Contains("Камера заднего вида")) total += 30000;
                    if (option.Contains("Чот крутое")) total += 100000;
                }
            }
            return total;
        }

        private void AddPriceItem(string name, double price)
        {
            var grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

            var nameText = new TextBlock
            {
                Text = name,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(nameText, 0);

            var priceText = new TextBlock
            {
                Text = $"{price:N0} ₽",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            Grid.SetColumn(priceText, 1);

            grid.Children.Add(nameText);
            grid.Children.Add(priceText);

            PricePanel.Children.Add(grid);
        }

        private void AddConfigItem(string category, string value)
        {
            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 2, 0, 2) };

            var categoryText = new TextBlock
            {
                Text = $"{category}: ",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 5, 0)
            };

            var valueText = new TextBlock
            {
                Text = value
            };

            stackPanel.Children.Add(categoryText);
            stackPanel.Children.Add(valueText);

            ConfigPanel.Children.Add(stackPanel);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (Base.C == 0)
            {
                MessageBox.Show("Не удалось рассчитать стоимость автомобиля!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NavigationService?.Navigate(new Step4());
        }
    }
}
