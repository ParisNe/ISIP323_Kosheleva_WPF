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
    /// Логика взаимодействия для Step4.xaml
    /// </summary>
    public partial class Step4 : Page
    {
        public Step4()
        {
            InitializeComponent();
            Loaded += Step4_Loaded;
            DownSlider.ValueChanged += Slider_ValueChanged;
            TermSlider.ValueChanged += Slider_ValueChanged;
            NextButton.Click += NextButton_Click;
        }

        private void Step4_Loaded(object sender, RoutedEventArgs e)
        {
            // Устанавливаем годовую ставку
            Base.r = 12; // 12% годовых

            CarPriceText.Text = $"{Base.C:N0} ₽";
            UpdateCalculations();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateCalculations();
        }

        private void UpdateCalculations()
        {
            // Процент первоначального взноса
            double downPercent = DownSlider.Value;
            DownPercentText.Text = $"{downPercent:F0}%";

            // Сумма первоначального взноса
            double downAmount = Base.C * (downPercent / 100);
            DownAmountText.Text = $"{downAmount:N0} ₽";

            // Сумма кредита
            double loanAmount = Base.C - downAmount;
            LoanAmountText.Text = $"{loanAmount:N0} ₽";

            // Срок кредита в месяцах
            int termMonths = (int)TermSlider.Value;
            TermText.Text = $"{termMonths} месяцев";

            // Расчет ежемесячного платежа (аннуитетный)
            double monthlyPayment = CalculateMonthlyPayment(loanAmount, Base.r, termMonths);
            MonthlyText.Text = $"{monthlyPayment:N0} ₽";

            // Общая переплата
            double totalPayment = monthlyPayment * termMonths;
            double overpayment = totalPayment - loanAmount;
            OverpaymentText.Text = $"{overpayment:N0} ₽";
        }

        private double CalculateMonthlyPayment(double loanAmount, double annualRate, int months)
        {
            // Формула аннуитетного платежа
            double monthlyRate = (annualRate / 100) / 12;
            double coefficient = (monthlyRate * Math.Pow(1 + monthlyRate, months)) /
                                 (Math.Pow(1 + monthlyRate, months) - 1);

            return loanAmount * coefficient;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (Base.C == 0)
            {
                MessageBox.Show("Стоимость автомобиля не определена!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NavigationService?.Navigate(new Step5());
        }
    }
}
