﻿using System;
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

        protected virtual string Executable
        {
            get
            {
                try
                {
                    var files = System.IO.Directory.GetFiles(ConsolePath);
                    if (files.Count(x => x.ToLower().EndsWith(".exe")) > 1)
                    {
                        throw new Exception();
                    }
                    var executableFull = files.FirstOrDefault(x => x.ToLower().EndsWith(".exe")).ToLower();
                    return executableFull;
                }
                catch
                {
                    string exceptionMessage = $"It was impossible find Executable for {ConsoleEnum.ToString()} into {ConsolePath}.";
                    exceptionMessage += " Exe is not present into folder or maybe exist more then one exe file.";
                    throw new Exception(exceptionMessage);
                }
            }
        }

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

        public void Play(Rom rom)
        {
            
            Process consoleProcess = new Process();
            consoleProcess.StartInfo.FileName = Executable;
            consoleProcess.StartInfo.Arguments = GetExutableArguments(rom);
            consoleProcess.Start();

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
