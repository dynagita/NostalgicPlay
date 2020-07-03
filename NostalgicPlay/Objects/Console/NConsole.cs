using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NostalgicPlay.Objects.Enums;

namespace NostalgicPlay.Objects
{
    public abstract class NConsole : INConsole
    {

        private bool IsImagePath(string path)
        {
            return Utils.IsImagePath(path);
        }

        protected abstract NConsoleEnum ConsoleEnum { get; }

        public List<Rom> Roms { get; private set; } = new List<Rom>();
        
        protected virtual string ConsolePath
        {
            get
            {
                return Utils.GetConsolePath(ConsoleEnum);
            }
        }

        protected virtual string RomsPath
        {
            get
            {
                return Utils.GetRomPath(ConsoleEnum);
            }
        }


        protected abstract string ConsoleExecutable { get; }


        protected abstract string GetExutableArguments(Rom rom);

        protected virtual void LoadRoms()
        {
            try
            {
                var files = System.IO.Directory.GetFiles(RomsPath);

                string lastImageFile = string.Empty;

                foreach (var file in files)
                {
                    if (IsImagePath(file))
                    {
                        lastImageFile = file;
                        Rom rImageAux = new Rom(file);
                        var rom = Roms.FirstOrDefault(x => x.GetRomName().Equals(rImageAux.GetRomName()));
                        if (rom != null)
                        {
                            rom.SetImagePath(file);
                        }
                    }
                    else
                    {
                        Rom r = new Rom(file);
                        if (lastImageFile.Contains(r.GetRomName()))
                        {
                            r.SetImagePath(lastImageFile);
                        }

                        Roms.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"{nameof(LoadRoms)}: {ex.Message}");
            }
        }

        public string GetExecutableFullPath()
        {
            string path = $"{ConsolePath}{ConsoleExecutable}";
            return path;
        }

        public void Play(Rom rom)
        {
            
            Process consoleRun = new Process();
            consoleRun.StartInfo.FileName = GetExecutableFullPath();
            consoleRun.StartInfo.Arguments = GetExutableArguments(rom);
            consoleRun.Start();

        }

        public List<Rom> ListRoms()
        {
            if (!Roms.Any())
            {
                LoadRoms();
            }

            return Roms;
        }
    }
}
