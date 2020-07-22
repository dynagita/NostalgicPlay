using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects.Console
{
    public class NMameConsole : NConsole
    {
        private string _processName;

        protected override string Executable
        {
            get
            {
                return "mame64.exe";
            }
        }

        protected override Enums.NConsoleEnum ConsoleEnum
        {
            get
            {
                return Enums.NConsoleEnum.Mame;
            }
        }

        protected override string GetExutableArguments(Rom rom)
        {
            return $"{rom.GetRomName()} -joystick";
        }

        public override void Play(Rom rom)
        {
            try
            {
                if (!_playing)
                {

                    string exe = Executable;
                    var split = exe.Split(new string[] { "\\", "." }, StringSplitOptions.RemoveEmptyEntries);
                    _processName = split[split.Length - 2];
                    string content = $"cd {ConsolePath}\n{exe} {GetExutableArguments(rom)}";
                    System.IO.File.WriteAllText("mame.bat", content);
                    Process p = new Process();
                    p.StartInfo.FileName = "mame.bat";
                    _playing = true;
                    p.Start();
                    System.Threading.Thread.Sleep(10000);
                    System.IO.File.Delete("mame.bat");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(Play)}: It was not possible to start N64 Rom: {ex.GetExceptionMessageRecursive()}");
            }
        }

        public override void Stop()
        {
            try
            {
                if (_playing)
                {
                    Process p = Process.GetProcessesByName(_processName).FirstOrDefault();
                    if (p == null)
                    {
                        throw new Exception($"It was impossible find {_processName}.");
                    }
                    p.Kill();
                    _playing = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(Stop)}: {ex.GetExceptionMessageRecursive()}");
            }
        }
    }
}
