using System;
using System.Threading.Tasks;
using WTelegram;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

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



    }
}
