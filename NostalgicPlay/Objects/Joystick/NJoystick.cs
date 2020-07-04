using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectInput;
using System.Windows.Forms;
using static NostalgicPlay.Objects.Enums;

namespace NostalgicPlay.Objects
{
    public class NJoystick
    {
        private DirectInput _directInput;
        private Joystick _joystick;
        private bool _connected;
        private bool _playingGame;
        private Timer _joystickTimer;
        private NostalgicPlay _form;

        public NJoystick(NostalgicPlay form)
        {
            _form = form;

            _directInput = new DirectInput();
            var connectedsDevice = _directInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly);
            foreach (var device in connectedsDevice)
            {
                try
                {
                    _joystick = new Joystick(_directInput, device.InstanceGuid);
                    _connected = true;
                    break;
                }
                catch (DirectInputException ex)
                {

                    Utils.ShowError($"It was impossible stablish connect with stick: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Utils.ShowError($"It was impossible stablish connect with stick: {ex.Message}");
                }
            }
            if (_connected)
            {
                _joystick.Acquire();
            }
        }

        private void StickHandle()
        {
            JoystickState state = _joystick.GetCurrentState();

            bool[] buttons = state.GetButtons();

            if (_playingGame)
            {
                if (buttons[(int)JoystickButton.Start] && buttons[(int)JoystickButton.Select])
                {
                    _form.StopSelectedGame();
                    _playingGame = false;
                }
                return;
            }

            if (buttons[(int)JoystickButton.Circle])
            {
                _form.ShowGameConsole();
            }
            else if (buttons[(int)JoystickButton.X])
            {
                _form.CloseGameConsole();
            }            
            else if (buttons[(int)JoystickButton.Start])
            {
                _form.PlaySelectedGame();
                _playingGame = true;
            }
           
            int yValue = state.Y;
            int xValue = state.X;

            if (yValue < (int)JoystickButton.DefaultYAxis)
            {
                _form.MoveGameListUp();
            }
            if (yValue > (int)JoystickButton.DefaultYAxis)
            {
                _form.MoveGameListDown();
            }
            if (xValue < (int)JoystickButton.DefaultXAxix)
            {
                _form.MoveBackward(); 
            }
            if (xValue > (int)JoystickButton.DefaultXAxix)
            {
                _form.MoveForward();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            StickHandle();
        }

        public void Start()
        {
            if (_joystickTimer == null)
            {
                _joystickTimer = new Timer();
                _joystickTimer.Tick += TimerTick;
            }
            _joystickTimer.Enabled = true;
        }

        public bool IsRunning()
        {
            return _joystickTimer.Enabled;
        }

        public bool IsGaming()
        {
            return _playingGame;
        }
        
    }
}
