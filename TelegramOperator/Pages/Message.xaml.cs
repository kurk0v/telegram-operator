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

namespace TelegramOperator.Pages
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Page
    {
        private WTelegram.Client _client;
        Telegram telegram = new Telegram();
        public Message()
        {
            InitializeComponent();
        }
        static string Config(string what)
        {
            List<string> member = Postgres.ReadingDataString("31");

            switch (what)
            {
                case "api_id": return member[2];
                case "api_hash": return member[1];
                case "phone_number": return member[3];
                case "session_pathname": return $"{member[2]}session";
                default: return null;
            }
        }

        private async void SMS_Click(object sender, RoutedEventArgs e)
        {
            _client = new WTelegram.Client(what => Config(what));
            var myself = await _client.LoginUserIfNeeded();

            if (_client != null)
            {
                await telegram.SendMessage(_client, "kurkovvokruk", "1");
            }
        }
    }
}
