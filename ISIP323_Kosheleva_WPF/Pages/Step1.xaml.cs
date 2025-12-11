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
                ListBoxItem choice = ((sender as ListBox).SelectedItem as ListBoxItem);
                tb.Content = "Вы выбрали: " + choice.Content.ToString();
                Base.EngineType = choice.Content.ToString(); 

        }

        private void ModelButton1_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image1.Source;
            GridBottom.Visibility = Visibility.Visible;
        }

        private void ModelButton2_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image2.Source;
            GridBottom.Visibility = Visibility.Visible;
        }

        private void ModelButton3_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image3.Source;
            GridBottom.Visibility = Visibility.Visible;
        }

        private void ModelButton4_Checked(object sender, RoutedEventArgs e)
        {
            BossImage.Source = Image4.Source;
            GridBottom.Visibility = Visibility.Visible;
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
