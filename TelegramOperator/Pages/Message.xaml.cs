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
using Microsoft.Win32;
using System.IO;

namespace TelegramOperator.Pages
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Page
    {

        Telegram telegram = new Telegram();
        private string path = "";
        public Message()
        {
            InitializeComponent();
            
        }



        private async void SMS_Click(object sender, RoutedEventArgs e)
        {
            bool photo_check = (bool)photocheck.IsChecked;
            await telegram.SendMessage(null, username.Text, message.Text, (int)Slider.Value, photo_check, path);
        }


        private void PathPictures()
        {
            OpenFileDialog ofdPicture = new OpenFileDialog();
            ofdPicture.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;";
            ofdPicture.FilterIndex = 1;

            if (ofdPicture.ShowDialog() == true)
            {
                path = ofdPicture.FileName;
                imgPicture.Source = new BitmapImage(new Uri(path));

            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            PathPictures();
        }
    }
}
