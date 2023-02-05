using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.IO;

namespace TelegramOperator.Pages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private WTelegram.Client _client;
        public Account()
        {
            InitializeComponent();
            membersDataGrid.ItemsSource = Postgres.ReadingData();           

        }


        Telegram telegram = new Telegram();

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            textbox_sms.IsEnabled = button_sms.IsEnabled = true;
            button_add.IsEnabled = false;

            listBox.Items.Add($"Connecting & login into Telegram servers...");

            _client = new WTelegram.Client(int.Parse(textbox_api.Text), textbox_hash.Text);
            await telegram.DoLogin(textbox_number.Text, _client);
        }

        

        private async void Sms_Click(object sender, RoutedEventArgs e)
        {
            string logs = await telegram.DoLogin(textbox_sms.Text, _client);
            listBox.Items.Add(logs);
            logs = await telegram.DoLogin(textbox_password.Text, _client);
            listBox.Items.Add(logs);


            string fullname = Convert.ToString(_client.User.last_name) + " " + Convert.ToString(_client.User.first_name);
            Postgres.RecordConection(4, textbox_hash.Text, Convert.ToInt32(textbox_api.Text), 
            textbox_number.Text, Convert.ToString(_client.User), fullname, await telegram.ImageProfile(_client));

            membersDataGrid.ItemsSource = Postgres.ReadingData();

            textbox_sms.IsEnabled = button_sms.IsEnabled = false;
            button_add.IsEnabled = true;
            textbox_password.Text = textbox_sms.Text = textbox_number.Text = textbox_hash.Text = textbox_api.Text = String.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            membersDataGrid.ItemsSource = Postgres.ReadingData();

        }


        private void SortingDataGrid(object sender, KeyEventArgs e)
        {
            var filtered = Postgres.ReadingData().Where(x => x.member.StartsWith(search.Text));
            membersDataGrid.ItemsSource = filtered;

        }


        
    }
}
