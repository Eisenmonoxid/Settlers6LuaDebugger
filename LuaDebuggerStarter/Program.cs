﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace LuaDebuggerStarter
{
    static class Program
    {
        // Initial Commit
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1][0] == '!' && args[1] == "!s6key")
                ToggleS6DevM();
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLDStarter());
            }
        }

        public static void ToggleS6DevM()
        {
            if (IsS6DevM())
                RemoveS6DevKey();
            else
                SetS6DevKey();
        }

        public static bool IsS6DevM()
        {
            var s6RegKey = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Ubisoft\The Settlers 6\Development", "DevelopmentMachine", null);

            if (s6RegKey == null || 
                s6RegKey.GetType() != typeof(Int32) || 
                (Int32)s6RegKey == 0 || 
                (Int32)s6RegKey != Program.CalculateDevHash(System.Environment.MachineName))
                return false;
            else
                return true;
        }

        public static int CalculateDevHash(string str)
        {
            str = str.ToLower();
            uint sum = 0;

            foreach (char c in str)
            {
                sum = (16 * sum) + c;
                uint upperNibble = sum & 0xF0000000;
                if (upperNibble > 0)
                    sum ^= upperNibble ^ (upperNibble >> 24);
            }
            uint tmp = 1812433253 * (sum >> 16) - 1989869568 * sum;
            return (Int32)(1142332463 * tmp);

        }

        public static void SetS6DevKey()
        {
            int key = CalculateDevHash(System.Environment.MachineName);
            /*
                        RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                        string instd = "";
                        foreach (string s in installed_versions.GetSubKeyNames())
                            instd += s + ", ";
                        MessageBox.Show("Running CLR: " + Environment.Version.ToString()+
                            "\n.NET Installs: " + instd +
                            "\nKey: 0x" + key.ToString("x"), "twA Debug");*/

            try
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Ubisoft\The Settlers 6\Development", "DevelopmentMachine", key, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void RemoveS6DevKey()
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Ubisoft\The Settlers 6\Development", true))
                {
                    if (key != null)
                    {
                        key.DeleteValue("DevelopmentMachine");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled ThreadException:\n" + e.Exception.ToString());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unhandled Exception:\n" + (e.ExceptionObject as Exception).ToString());
        }
    }

    public static class Extensions
    {
        public static void CopyTo(this Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024];
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
    }
}