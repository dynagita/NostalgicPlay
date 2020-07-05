using NostalgicPlay.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NostalgicPlay.Forms
{
    public partial class ConfigForm : Form
    {
        private NJoystick _joystick;
        private Timer timer;
        public ConfigForm(NJoystick joystick)
        {
            InitializeComponent();
            _joystick = joystick;
            timer = new Timer();
            timer.Tick += Timer_Tick;
        }

        public void SetLabel(string text)
        {
            _configLabel.Text = text;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_joystick.IsMapped())
            {
                _joystick.Connect();
                _joystick.MapStick(this);
            }
            else
            {
                _joystick.SaveMap();
                timer.Enabled = false;
                this.Close();
            }
        }

        public void StartConfiguration()
        {
            timer.Enabled = true;
        }
    }
}
