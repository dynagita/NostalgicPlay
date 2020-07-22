using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using static NostalgicPlay.Objects.Enums;

namespace NostalgicPlay.Objects
{
    public static class Utils
    {
        public static string DefaultImagePath = ConfigurationManager.AppSettings["DefaultRomImage"].ToString();

        public static string GetConsolePath(NConsoleEnum console)
        {
            string configKey = $"{console.ToString()}";
            var result = ConfigurationManager.AppSettings[configKey].ToString();
            if (!result.EndsWith("\\"))
            {
                result += "\\";
            }
            return result;
        }

        public static string GetRomPath(NConsoleEnum console)
        {
            string romsPath = GetConsolePath(console);
            romsPath += "Roms";
            return romsPath;
        }

        public static bool IsImagePath(string path)
        {
            bool result = false;

            path = path.ToLower();

            if (path.EndsWith("jpg") || path.EndsWith("jpeg") ||
                path.EndsWith("png") || path.EndsWith("bmp") ||
                path.EndsWith("gif") || path.EndsWith("tiff"))
            {
                result = true;
            }

            return result;
        }

        public static NConsoleEnum ToNConsoleEnum(this string str)
        {
            str = str.ToLower();
            if (str.Contains("megadrive"))
            {
                return NConsoleEnum.MegaDrive;
            }
            else if (str.Contains("supernintendo"))
            {
                return NConsoleEnum.SuperNintendo;
            }
            else if (str.Contains("nintendo64"))
            {
                return NConsoleEnum.Nintendo64;
            }
            else if (str.Contains("mame"))
            {
                return NConsoleEnum.Mame;
            }
            else
            {
                return NConsoleEnum.Indefinido;
            }
        }

        public static void ShowError(string message)
        {
            System
                .Windows
                .Forms
                .MessageBox
                .Show(message, "Erro", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static string GetExceptionMessageRecursive(this Exception ex)
        {
            if (ex.InnerException == null)
            {
                return ex.Message;
            }

            return $"{ex.Message}\n\n{ex.InnerException.GetExceptionMessageRecursive()}";
        }
    }
}
