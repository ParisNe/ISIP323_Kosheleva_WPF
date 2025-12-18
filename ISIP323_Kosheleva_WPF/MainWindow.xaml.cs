using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ISIP323_Kosheleva_WPF
{
    public partial class MainWindow : Window
    {
        private int currentStep = 1;

        public MainWindow()
        {
            InitializeComponent();
            UpdateProgress();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
                currentStep--;
                UpdateProgress();
            }
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            BackButton.Visibility = currentStep > 1 ? Visibility.Visible : Visibility.Collapsed;
        }

        public void GoToNextStep(string pageName)
        {
            if (currentStep < 5)
            {
                currentStep++;
                MainFrame.Navigate(new Uri($"Pages/{pageName}.xaml", UriKind.Relative));
                UpdateProgress();
            }
        }

        public void GoToPreviousStep()
        {
            if (currentStep > 1)
            {
                currentStep--;
                MainFrame.Navigate(new Uri($"Pages/Step{currentStep}.xaml", UriKind.Relative));
                UpdateProgress();
            }
        }

        private void UpdateProgress()
        {
            ProgressBar.Value = (currentStep - 1) * 25;
            ProgressText.Text = $"Шаг {currentStep} из 5";
        }
    }
}