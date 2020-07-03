using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects
{
    public interface INConsole
    {
        void Play(Rom rom);

        List<Rom> ListRoms();
    }
}
