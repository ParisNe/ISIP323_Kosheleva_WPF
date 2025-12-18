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

            NameBox.TextChanged += ValidateFields;
            PhoneBox.TextChanged += ValidateFields;
            EmailBox.TextChanged += ValidateFields;

            SubmitButton.Click += SubmitButton_Click;
        }

        private void Step5_Loaded(object sender, RoutedEventArgs e)
        {
            // Заполняем сводку
            SumModel.Text = Base.Model ?? "Не выбрано";
            SumPrice.Text = $"{Base.C:N0} ₽";

            // Рассчитываем ежемесячный платеж (используем дефолтные значения из Step4)
            double downPercent = 30; // 30% по умолчанию
            double downAmount = Base.C * (downPercent / 100);
            double loanAmount = Base.C - downAmount;
            double monthlyPayment = CalculateMonthlyPayment(loanAmount, 12, 36); // 12%, 36 месяцев
            SumPayment.Text = $"{monthlyPayment:N0} ₽";
        }

        private double CalculateMonthlyPayment(double loanAmount, double annualRate, int months)
        {
            double monthlyRate = (annualRate / 100) / 12;
            double coefficient = (monthlyRate * Math.Pow(1 + monthlyRate, months)) /
                                 (Math.Pow(1 + monthlyRate, months) - 1);
            return loanAmount * coefficient;
        }

        private void ValidateFields(object sender, TextChangedEventArgs e)
        {
            bool isValid = true;

            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(NameBox.Text) || NameBox.Text.Length < 3)
            {
                NameBox.BorderBrush = System.Windows.Media.Brushes.Red;
                isValid = false;
            }
            else
            {
                NameBox.BorderBrush = System.Windows.Media.Brushes.Gray;
            }

            // Проверка телефона
            if (!IsValidPhone(PhoneBox.Text))
            {
                PhoneBox.BorderBrush = System.Windows.Media.Brushes.Red;
                isValid = false;
            }
            else
            {
                PhoneBox.BorderBrush = System.Windows.Media.Brushes.Gray;
            }

            // Проверка email
            if (!IsValidEmail(EmailBox.Text))
            {
                EmailBox.BorderBrush = System.Windows.Media.Brushes.Red;
                isValid = false;
            }
            else
            {
                EmailBox.BorderBrush = System.Windows.Media.Brushes.Gray;
            }

            SubmitButton.IsEnabled = isValid;
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Простая проверка российского телефона
            string pattern = @"^(\+7|8)?[\s\-]?\(?[0-9]{3}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$";
            return Regex.IsMatch(phone, pattern);
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем данные
            Base.Name = NameBox.Text.Trim();
            Base.Telephone = PhoneBox.Text.Trim();
            Base.Emale = EmailBox.Text.Trim();

            // Показываем сообщение об успехе
            MessageBox.Show($"Заявка успешно отправлена!\n\n" +
                          $"ФИО: {Base.Name}\n" +
                          $"Телефон: {Base.Telephone}\n" +
                          $"Email: {Base.Emale}\n" +
                          $"Итоговая стоимость: {Base.C:N0} ₽",
                          "Заявка принята",
                          MessageBoxButton.OK,
                          MessageBoxImage.Information);

            // Можно закрыть приложение или вернуться на начало
            Application.Current.Shutdown();
        }
    }
}
