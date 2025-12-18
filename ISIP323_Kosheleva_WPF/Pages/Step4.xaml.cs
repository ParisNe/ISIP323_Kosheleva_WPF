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
            NextButton.Click += NextButton_Click;
        }

        private void Step4_Loaded(object sender, RoutedEventArgs e)
        {
            CarPriceText.Text = Base.TotalPrice.ToString("N0") + " ₽";

            DownSlider.Value = Base.LoanPercent;
            TermSlider.Value = Base.LoanTermMonths;

            DownSlider.ValueChanged += Slider_ValueChanged;
            TermSlider.ValueChanged += Slider_ValueChanged;

            CalculateLoan();
        }

        private void Slider_ValueChanged(object sender, RoutedEventArgs e)
        {
            Base.LoanPercent = DownSlider.Value;
            Base.LoanTermMonths = (int)TermSlider.Value;

            DownPercentText.Text = Base.LoanPercent.ToString("0") + "%";
            TermText.Text = Base.LoanTermMonths.ToString() + " месяцев";

            CalculateLoan();
        }

        private void CalculateLoan()
        {
            Base.CalculateLoan();

            double downPayment = Base.TotalPrice * Base.LoanPercent / 100;
            double loanAmount = Base.TotalPrice - downPayment;
            double totalPayment = Base.MonthlyPayment * Base.LoanTermMonths;
            double overpayment = totalPayment - loanAmount;

            DownAmountText.Text = downPayment.ToString("N0") + " ₽";
            LoanAmountText.Text = loanAmount.ToString("N0") + " ₽";
            MonthlyText.Text = Base.MonthlyPayment.ToString("N0") + " ₽";
            OverpaymentText.Text = overpayment.ToString("N0") + " ₽";
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.GoToNextStep("Step5");
        }

    }
}
