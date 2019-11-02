using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAV_Trojaner
{
    public class Credential
    {
        private string _url;
        private string _username;
        private string _password;

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value != "" ? value : "localhost";
            }
        }

        public string Username
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value != "" ? value : "default";
            }
        }

        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }

        public Credential()
        {
            this._url = "localhost";
            this._username = "default";
            this._password = "";
        }

        public Credential(string url, string username, string password) : this()
        {
            this.Url = url;
            this.Username = username;
            this.Password = password;
        }
    }
}
