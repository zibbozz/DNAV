
namespace DNAV_Trojaner
{
    public class Credential
    {
        private string _url;
        private string _username;
        private string _password;

        /// <summary>
        /// Die URL der Website, für welche die Logindaten gelten.
        /// </summary>
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

        /// <summary>
        /// Der Benutzername des Benutzerkontos
        /// </summary>
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

        /// <summary>
        /// Das Passwort des Benutzerkontos
        /// </summary>
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

        /// <summary>
        /// Setzt die Eigenschaften auf Standardwerte
        /// </summary>
        public Credential()
        {
            this._url = "localhost";
            this._username = "default";
            this._password = "";
        }

        /// <summary>
        /// Setzt die Eigenschaften bei der Erstellung des Objekts
        /// </summary>
        /// <param name="url">Die URL der Website</param>
        /// <param name="username">Benutzername des Benutzers</param>
        /// <param name="password">Passwort des Benutzers</param>
        public Credential(string url, string username, string password) : this()
        {
            this.Url = url;
            this.Username = username;
            this.Password = password;
        }
    }
}
