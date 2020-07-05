using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NostalgicPlay.Objects
{
    public class NJoystickConfig
    {
        public NJoystickConfig()
        {
            Up = -1;
            Down = -1;
            Left = -1;
            Right = -1;
            ConfirmButton = -1;
            EscButton = -1;
            CloseButton1 = -1;
            CloseButton2 = -1;
        }

        public string DeviceInstaceName { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int ConfirmButton { get; set; }
        public int EscButton { get; set; }
        public int CloseButton1 { get; set; }
        public int CloseButton2 { get; set; }

        public void Load()
        {
            if (System.IO.File.Exists("joystickconfig.json"))
            {
                try
                {
                    string json = System.IO.File.ReadAllText("joystickconfig.json");
                    NJoystickConfig config = JsonConvert.DeserializeObject<NJoystickConfig>(json);

                    this.Up = config.Up;
                    this.Down = config.Down;
                    this.Left = config.Left;
                    this.Right = config.Right;
                    this.ConfirmButton = config.ConfirmButton;
                    this.EscButton = config.EscButton;
                    this.CloseButton1 = config.CloseButton1;
                    this.CloseButton2 = config.CloseButton2;
                    this.DeviceInstaceName = config.DeviceInstaceName;
                }
                catch (Exception ex)
                {
                    throw new Exception($"{nameof(Load)}: It was impossible read founded config: {ex.Message}");
                }                
            }
        }

        public void SaveConfig()
        {
            try
            {
                var str = JsonConvert.SerializeObject(this);
                System.IO.File.WriteAllText("joystickconfig.json", str);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(SaveConfig)}: It was impossible write config: {ex.Message}");
            }
            
        }

        public bool IsMapped()
        {
            return !(ConfirmButton == -1 || EscButton == -1 || CloseButton1 == -1 || CloseButton2 == -1 || Up == -1 || Left == -1 || Down == -1 || Right == -1);
        }
    }
}
