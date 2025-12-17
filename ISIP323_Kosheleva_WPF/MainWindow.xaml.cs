using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ISIP323_Kosheleva_WPF
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, int> pageProgressValues;

        public MainWindow()
        {
            InitializeComponent();
            InitializeProgressValues();
            UpdateProgress();
        }

        private void InitializeProgressValues()
        {
            pageProgressValues = new Dictionary<string, int>
            {
                { "Step1.xaml", 25 },
                { "Step2.xaml", 50 },
                { "Step3.xaml", 75 },
                { "Step4.xaml", 100 }
            };
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // Управление видимостью кнопки Назад
            BackButton.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;

            // Обновление прогресса
            UpdateProgress();

            // Обновление суммы (пример)
            UpdateSum();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void UpdateProgress()
        {
            if (MainFrame.Content == null) return;

            string currentUri = MainFrame.Source?.ToString() ?? "";
            int progress = 0;

            // Ищем прогресс для текущей страницы
            foreach (var page in pageProgressValues)
            {
                if (currentUri.Contains(page.Key))
                {
                    progress = page.Value;
                    break;
                }
            }

            // Устанавливаем значение прогресс-бара
            ProgressBar.Value = progress;
            ProgressText.Text = $"Прогресс: {progress}%";
        }

        private void UpdateSum()
        {
            // Простая логика для примера - можно заменить на свою
            int baseValue = (int)ProgressBar.Value * 10;
            Sum.Text = baseValue.ToString();
        }

        // Публичные методы для управления из других классов
        public void SetProgress(int value)
        {
            if (value >= 0 && value <= 100)
            {
                ProgressBar.Value = value;
                ProgressText.Text = $"Прогресс: {value}%";
                UpdateSum();
            }
        }

        public void SetSum(int value)
        {
            Sum.Text = value.ToString();
        }
    }
}