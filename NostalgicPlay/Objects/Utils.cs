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
            string configKey = $"{console.ToString()}Path";
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
            else
            {
                return NConsoleEnum.Indefinido;
            }
        }
    }
}
