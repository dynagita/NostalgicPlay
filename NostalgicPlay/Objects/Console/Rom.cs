using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects
{
    public class Rom
    {        
        public Rom(string romPath)
        {
            _romFullPath = romPath;
            _ownImage = false;
            SetRomName(romPath);
        }

        public Rom(string romPath, string ImagePath)
        {
            _romFullPath = romPath;
            _imagePath = ImagePath;
            _ownImage = true;
            SetRomName(romPath);
        }

        private string _romFullPath;
        private string _imagePath;
        private string _romName;
        private bool _ownImage;

        private void SetRomName(string fullPath)
        {
            var splitted = fullPath.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            _romName = splitted[splitted.Length - 2];
        }



        public bool HasOwnImage()
        {
            return _ownImage;
        }

        public string GetRomPath()
        {
            return _romFullPath;
        }

        public string GetImagePath()
        {
            string result = Utils.DefaultImagePath;
            if (_ownImage)
            {
                result = _imagePath;
            }

            return result;
        }

        public void SetImagePath(string imagePath)
        {
            _ownImage = true;
            _imagePath = imagePath;
        }

        public string GetRomName()
        {
            return _romName;
        }

        public override string ToString()
        {
            return GetRomName();
        }
    }
}
