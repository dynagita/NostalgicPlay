using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects
{
    public class NMegaDriveConsole : NConsole, INConsole
    {
        protected override Enums.NConsoleEnum ConsoleEnum
        {
            get
            {
                return Enums.NConsoleEnum.MegaDrive;
            }
        }
        
        protected override string GetExutableArguments(Rom rom)
        {
            return $"\"{rom.GetRomPath()}\" -gens -fullscreen";
        }
    }
}
