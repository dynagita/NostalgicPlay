using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NostalgicPlay.Objects.Enums;

namespace NostalgicPlay.Objects.Console
{
    public abstract class NConsoleFactory
    {
        public static INConsole CreateConsole(NConsoleEnum console)
        {
            switch (console)
            {                
                case NConsoleEnum.MegaDrive:
                    return new NMegaDriveConsole();
                case NConsoleEnum.SuperNintendo:
                    return new NSuperNintendoConsole();
                case NConsoleEnum.Nintendo64:
                    return new NNintendo64Console();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
