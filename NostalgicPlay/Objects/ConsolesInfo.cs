using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects
{
    public class ConsolesInfo
    {
        public Enums.NConsoleEnum NConsole { get; set; }

        public Image Image { get; set; }

        public bool Selected { get; set; }
    }
}
