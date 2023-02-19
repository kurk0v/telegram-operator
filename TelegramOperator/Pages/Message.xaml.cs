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
using System.Threading;

namespace TelegramOperator.Pages
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Page
    {

        Telegram telegram = new Telegram();
        public Message()
        {
            InitializeComponent();

        }
        

        private async void SMS_Click(object sender, RoutedEventArgs e)
        {
            bool photo_check = (bool)photocheck.IsChecked;
            await telegram.SendMessage(null, username.Text, message.Text, (int)Slider.Value, photo_check, @"D:1.jpg");
        }
    }
}
