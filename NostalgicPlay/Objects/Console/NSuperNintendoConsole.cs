using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects
{
    public class NSuperNintendoConsole : NConsole, INConsole
    {
        protected override Enums.NConsoleEnum ConsoleEnum
        {
            get
            {
                return Enums.NConsoleEnum.SuperNintendo;
            }
        }

        protected override string ConsoleExecutable
        {
            get
            {
                return "sness.exe";
            }
        }

        protected override string GetExutableArguments(Rom rom)
        {
            return $"-fullscreen \"{rom.GetRomPath()}\"";
        }
    }
}
