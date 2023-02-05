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

namespace TelegramOperator.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>   
    public partial class MainWindow : Window
    {
        List<Page> page;
        public MainWindow()
        {
            InitializeComponent();

            this.page = new List<Page>();
            page.Add(new Pages.Home());
            page.Add(new Pages.Account());
            page.Add(new Pages.Message());
            page.Add(new Pages.Group());
            page.Add(new Pages.Settings());

            MainFrame.Content = page[0];
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page[0];

        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page[1];
        }

        private void Message_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page[2];
        }

        private void Group_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page[3];
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page[4];
        }


    }
}
