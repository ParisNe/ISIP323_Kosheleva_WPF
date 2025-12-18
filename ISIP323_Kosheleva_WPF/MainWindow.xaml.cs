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
            BackButton.Visibility = MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;

            UpdateProgress();

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

            foreach (var page in pageProgressValues)
            {
                if (currentUri.Contains(page.Key))
                {
                    progress = page.Value;
                    break;
                }
            }

            ProgressBar.Value = progress;
            ProgressText.Text = $"Прогресс: {progress}%";
        }

        private void UpdateSum()
        {
            int baseValue = (int)ProgressBar.Value * 10;
            Sum.Text = baseValue.ToString();
        }

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