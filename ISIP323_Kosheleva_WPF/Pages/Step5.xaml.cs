using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Step5.xaml
    /// </summary>
    public partial class Step5 : Page
    {
        public Step5()
        {
            InitializeComponent();
            Loaded += Step5_Loaded;

            
            SubmitButton.Click += SubmitButton_Click;

            
            NameBox.TextChanged += ValidateForm;
            PhoneBox.TextChanged += ValidateForm;
            EmailBox.TextChanged += ValidateForm;
        }

        private void Step5_Loaded(object sender, RoutedEventArgs e)
        {
            
            SumModel.Text = Base.Model;
            SumPrice.Text = Base.TotalPrice.ToString("N0") + " ₽";
            SumPayment.Text = Base.MonthlyPayment.ToString("N0") + " ₽";
        }

        private void ValidateForm(object sender, TextChangedEventArgs e)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(NameBox.Text) | NameBox.Text.Length < 3)
                isValid = false;
            else isValid = true;

            if (string.IsNullOrWhiteSpace(PhoneBox.Text) | !Regex.IsMatch(PhoneBox.Text, @"^\d+$") | PhoneBox.Text.Length < 10)
                isValid = false;
            else isValid = true;

            if (string.IsNullOrWhiteSpace(EmailBox.Text) | !EmailBox.Text.Contains("@") | !EmailBox.Text.Contains("."))
                isValid = false;
            else isValid = true;

            SubmitButton.IsEnabled = isValid;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Заказ оформлен!\n\n" +
                          $"ФИО: {NameBox.Text}\n" +
                          $"Телефон: {PhoneBox.Text}\n" +
                          $"Email: {EmailBox.Text}\n" +
                          $"Модель: {Base.Model}\n" +
                          $"Стоимость: {Base.TotalPrice:N0} ₽\n" +
                          $"Ежемесячный платеж: {Base.MonthlyPayment:N0} ₽",
                          "Заказ оформлен");
                             
        }
    }
}
