using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.DirectInput;
using System.Windows.Forms;
using static NostalgicPlay.Objects.Enums;
using NostalgicPlay.Forms;

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
        private NJoystickConfig _joystickConfig;
        private bool _povSystem;

        public NJoystick(NostalgicPlay form)
        {
            _form = form;
            _joystickConfig = new NJoystickConfig();
            _joystickConfig.Load();
        }

        private void StickHandle()
        {
            if (_joystickConfig.DeviceInstaceName.Equals(_joystick.Properties.InstanceName))
            {
                if (!_connected)
                {
                    throw new Exception($"Joystick is not connected. Please check your device.");
                }

                JoystickState state = _joystick.GetCurrentState();

                bool[] buttons = state.GetButtons();

                if (_playingGame)
                {
                    if (buttons[_joystickConfig.CloseButton1] && buttons[_joystickConfig.CloseButton2])
                    {
                        _form.StopSelectedGame();
                        _playingGame = false;
                    }
                    return;
                }

                if (buttons[_joystickConfig.ConfirmButton])
                {
                    _form.ConfirmAction();
                }
                else if (buttons[_joystickConfig.EscButton])
                {
                    _form.EscAction();
                }
                else if (buttons[_joystickConfig.CloseButton1] && buttons[_joystickConfig.CloseButton2])
                {
                    _form.MapJoystick(true);
                }
                if (_povSystem)
                {
                    int pov = state.GetPointOfViewControllers()[0];

                    if (pov == _joystickConfig.Up)
                    {
                        _form.MoveGameListUp();
                    }
                    if (pov == _joystickConfig.Down)
                    {
                        _form.MoveGameListDown();
                    }
                    if (pov == _joystickConfig.Left)
                    {
                        _form.MoveBackward();
                    }
                    if (pov == _joystickConfig.Right)
                    {
                        _form.MoveForward();
                    }
                }
                else
                {
                    if (state.Y < _joystickConfig.Up)
                    {
                        _form.MoveGameListUp();
                    }
                    if (state.Y > _joystickConfig.Down)
                    {
                        _form.MoveGameListDown();
                    }
                    if (state.X < _joystickConfig.Left)
                    {
                        _form.MoveBackward();
                    }
                    if (state.X > _joystickConfig.Right)
                    {
                        _form.MoveForward();
                    }
                }
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

            if (!_joystickTimer.Enabled)
            {
                _joystickTimer.Enabled = true;
            }
        }

        public void Connect()
        {
            if (!_connected)
            {
                _directInput = new DirectInput();
                if (_joystickConfig.IsMapped())
                {
                    var device = _directInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly).FirstOrDefault(x => x.InstanceName.Equals(_joystickConfig.DeviceInstaceName));
                    if (device == null)
                    {
                        MessageBox.Show("The mapped joystick was not found. Please, delete joystickconfig.json in the application folder and restart application.");
                        _form.Close();
                        return;
                    }
                    _joystick = new Joystick(_directInput, device.InstanceGuid);
                    _connected = true;
                }
                else
                {
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
                }
                if (_connected)
                {
                    _joystick.Acquire();
                    _povSystem = _joystick.Capabilities.AxesCount > 4;
                }
            }
        }

        public void MapStick(ConfigForm configForm)
        {
            JoystickState state = _joystick.GetCurrentState();

            if (string.IsNullOrEmpty(_joystickConfig.DeviceInstaceName))
            {
                _joystickConfig.DeviceInstaceName = _joystick.Properties.InstanceName;
            }

            if (_joystickConfig.Up == -1)
            {
                if (_povSystem)
                {
                    configForm.SetLabel("Please press Up.");
                    int directionValue = state.GetPointOfViewControllers()[0];
                    if (directionValue < 0)
                        return;

                    _joystickConfig.Up = directionValue;

                    return;
                }
                else
                {
                    _joystickConfig.Up = state.Y;
                    _joystickConfig.Down = state.Y;
                }
            }

            if (_joystickConfig.Down == -1)
            {
                configForm.SetLabel("Please press Down.");
                int pov = state.GetPointOfViewControllers()[0];
                if (pov < 0)
                    return;

                _joystickConfig.Down = pov;

                return;
            }

            if (_joystickConfig.Left == -1)
            {
                if (_povSystem)
                {
                    configForm.SetLabel("Please press Left.");
                    int pov = state.GetPointOfViewControllers()[0];
                    if (pov < 0)
                        return;

                    _joystickConfig.Left = pov;

                    return;
                }
                else
                {
                    _joystickConfig.Left = state.X;
                    _joystickConfig.Right = state.X;
                }
            }

            if (_joystickConfig.Right == -1)
            {
                configForm.SetLabel("Please press Right.");
                int pov = state.GetPointOfViewControllers()[0];
                if (pov < 0)
                    return;

                _joystickConfig.Right = pov;

                return;
            }

            if (_joystickConfig.ConfirmButton == -1)
            {
                configForm.SetLabel("Please press confirm button.");
                bool[] buttons = state.GetButtons();
                int index = -1;
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i])
                    {
                        index = i;
                    }
                }

                if (index == -1)
                {
                    return;
                }
                _joystickConfig.ConfirmButton = index;
                return;
            }

            if (_joystickConfig.EscButton == -1)
            {
                configForm.SetLabel("Please press exit button.");
                bool[] buttons = state.GetButtons();
                int index = -1;
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i])
                    {
                        index = i;
                    }
                }

                if (index == -1)
                {
                    return;
                }

                _joystickConfig.EscButton = index;
                return;
            }

            if (_joystickConfig.CloseButton1 == -1)
            {
                configForm.SetLabel("Please press first of combined buttons to close game.");
                bool[] buttons = state.GetButtons();
                int index = -1;
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i])
                    {
                        index = i;
                    }
                }

                if (index == -1)
                {
                    return;
                }

                _joystickConfig.CloseButton1 = index;
                return;
            }

            if (_joystickConfig.CloseButton2 == -1)
            {
                configForm.SetLabel("Please press second of combined buttons to close game.");
                bool[] buttons = state.GetButtons();
                int index = -1;
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i])
                    {
                        index = i;
                    }
                }

                if (index == -1)
                {
                    return;
                }

                _joystickConfig.CloseButton2 = index;

                return;
            }


        }

        public bool ControlledByEmulator()
        {
            return _playingGame;
        }

        public void InformIsGaming()
        {
            _playingGame = true;
        }

        public bool IsMapped()
        {
            return _joystickConfig.IsMapped();
        }

        public void SaveMap()
        {
            _joystickConfig.SaveConfig();
        }

        public void ResetMap()
        {
            _joystickConfig = new NJoystickConfig();
        }

        public void Stop()
        {
            _joystickTimer.Enabled = false;
        }
    }
}
