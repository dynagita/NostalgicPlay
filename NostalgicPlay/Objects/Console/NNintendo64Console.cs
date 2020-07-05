using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostalgicPlay.Objects.Console
{
    public class NNintendo64Console : NConsole, INConsole
    {
        protected override Enums.NConsoleEnum ConsoleEnum
        {
            get
            {
                return Enums.NConsoleEnum.Nintendo64;
            }
        }

        private string _processName;

        private void SetFullScreenMode()
        {
            try
            {
                string fullScreenTag = "Auto Full Screen=1";
                string path = ConsolePath + "Config\\Project64.cfg";
                string file = System.IO.File.ReadAllText(path);
                if (!file.Contains(fullScreenTag))
                {
                    int qtdeCharInicio = file.IndexOf("[default]") + "[default]".Length;
                    string p1 = file.Substring(0, qtdeCharInicio);
                    string p2 = file.Substring(qtdeCharInicio, (file.Length - qtdeCharInicio));

                    file = p1+ $"\r\n{fullScreenTag}" + p2;

                    System.IO.File.WriteAllText(path, file);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(SetFullScreenMode)}: {ex.GetExceptionMessageRecursive()}"); ;
            }
            
            
        }

        protected override string GetExutableArguments(Rom rom)
        {
            return $"\"{rom.GetRomPath()}\"";
        }

        public override void Play(Rom rom)
        {
            try
            {
                if (!_playing)
                {
                    SetFullScreenMode();
                    string exe = Executable;
                    var split = exe.Split(new string[] { "\\", "." }, StringSplitOptions.RemoveEmptyEntries);
                    _processName = split[split.Length - 2];
                    string content = $"{exe} \"{rom.GetRomPath()}\"";
                    System.IO.File.WriteAllText("n64.bat", content);
                    Process p = new Process();
                    p.StartInfo.FileName = "n64.bat";
                    _playing = true;
                    p.Start();
                    System.Threading.Thread.Sleep(2000);
                    System.IO.File.Delete("n64.bat");
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
