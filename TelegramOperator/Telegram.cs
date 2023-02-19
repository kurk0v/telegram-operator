using System;
using System.Threading.Tasks;
using WTelegram;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using TL;
using System.Collections.Generic;

namespace TelegramOperator
{
	public class Telegram
    {
        public string id { get; set; }
		public string member { get; set; }
		public string api_hash { get; set; }
		public string api_id { get; set; }
		public string phone { get; set; }		
		public string username { get; set; }
        public BitmapSource photo { get; set; }
        
        public async Task<string> DoLogin(string loginInfo, Client _client)
        {
            string what = await _client.Login(loginInfo);
            string logs;
            if (what != null)
            {
                return logs = ($"A {what} is required..");
            }
            return logs = ($"We are now connected as {_client.User}");
        }


        public async Task<string> ImageProfile(Client _client)
        {
            var filename = $"{_client.User.photo.photo_id}.jpg";
            var fileStream = File.Create(filename);

            var photo = await _client.DownloadProfilePhotoAsync(_client.User, fileStream, true);
           
            fileStream.Close();

            string photo_base64 = Convert.ToBase64String(File.ReadAllBytes(filename));
            return photo_base64;
            
        }

        static string Config(string what, string id)
        {
            List<string> member = Postgres.ReadingDataString(id);

            switch (what)
            {
                case "api_id": return member[2];
                case "api_hash": return member[1];
                case "phone_number": return member[3];
                case "session_pathname": return $"{member[2]}session";
                default: return null;
            }
        }

        public async Task SendMessage(Client _client, string username, string message, int delay)
        {
            for (int i = 31; i <= 33; i++)
            {
                await Task.Delay(delay);
                _client = new WTelegram.Client(what => Config(what, i.ToString()));
                var myself = await _client.LoginUserIfNeeded();

                if (_client != null)
                {
                    var resolved = await _client.Contacts_ResolveUsername(username);
                    await _client.SendMessageAsync(resolved, message);
                    _client.Dispose();

                }

            }

        }
        
    }
}
