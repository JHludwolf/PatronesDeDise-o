using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProyectoFinal
{
    internal class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        private QRCode scanner = new QRCode();

        public User(int UserID, string UserName){
            this.UserID = UserID;
            this.UserName = UserName;
        }

        public string GetUserQRCode()
        {
            Dictionary<string, string> UserInfo = new Dictionary<string, string>()
            {
                { "UserID", UserID.ToString() },
                { "UserName", UserName }
            };
            return scanner.CreateQR(JsonSerializer.Serialize(UserInfo));
        }

        public bool AuthenticateWithQR(string QRCode)
        {
            string jsonString = scanner.ReadQR(QRCode);
            Dictionary<string, string> UserInfo = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
            if (UserInfo["UserID"] == UserID.ToString()) return true;
            return false;
        }
    }
}
