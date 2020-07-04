using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects
{
    public class Enums
    {
        public enum NConsoleEnum
        {
            Indefinido,
            MegaDrive,
            SuperNintendo
        }

        public enum JoystickButton
        { 
            Triangle = 0,
            Circle = 1,
            X = 2,
            Square = 3,
            LeftOne = 4,
            RightOne = 5,
            LeftTwo = 6,
            RightTwo = 7,
            Select = 8,
            Start = 9,
            LeftAnalogClick = 10,
            RightAnalogClick = 11,
            Mode = 12,
            DefaultYAxis = 32767,
            DefaultXAxix = 32767
        }
    }
}
