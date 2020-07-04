using NostalgicPlay.Objects;
using NostalgicPlay.Objects.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NostalgicPlay
{
    public partial class NostalgicPlay : Form
    {
        List<ConsolesInfo> Consoles { get; set; } = new List<ConsolesInfo>();

        INConsole _console = null;
        List<Rom> _roms = new List<Rom>();
        NJoystick _joystick;

        public NostalgicPlay()
        {
            _joystick = new NJoystick(this);
            InitializeComponent();
            LoadConsoles();
            _joystick.Start();
        }

        private void __selectedGamePanel_Click(object sender, EventArgs e)
        {
            ShowGameConsole();
        }

        private void LoadConsoles()
        {
            try
            {
                var files = System.IO.Directory.GetFiles("Resource");

                bool firstConsoleSelected = false;

                for (int i = 0; i < files.Length; i++)
                {
                    var image = files[i];
                    if (Utils.IsImagePath(image))
                    {
                        string[] split = image.Split(new string[] { "\\", "." }, StringSplitOptions.RemoveEmptyEntries);
                        string imageName = split[split.Length - 2];

                        var console = imageName.ToNConsoleEnum();
                        if (console != Enums.NConsoleEnum.Indefinido)
                        {
                            var consoleInfo = new ConsolesInfo();

                            Image img = new Bitmap(image);
                            consoleInfo.Image = img;
                            consoleInfo.Selected = !firstConsoleSelected;
                            consoleInfo.NConsole = console;

                            Consoles.Add(consoleInfo);
                            firstConsoleSelected = true;
                        }
                    }
                }
                SetSelectedGamePanel();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex.Message);
            }

        }

        private void SetSelectedGamePanel()
        {
            var consoleSelected = Consoles.FirstOrDefault(x => x.Selected);
            if (consoleSelected == null)
            {
                Utils.ShowError($"{nameof(SetSelectedGamePanel)}: Does not exists a console selected.");
                return;
            }
            __selectedGamePanel.Image = consoleSelected.Image;
        }

        private void JumpGamesForward()
        {
            int qttGames = _roms.Count;
            int selectedIndex = _romList.SelectedIndex;

            int howManyGamesToJump = qttGames / 15;

            selectedIndex += howManyGamesToJump;

            if (selectedIndex > _roms.Count -1)
            {
                selectedIndex = selectedIndex - (_roms.Count - 1);
                
            }

            _romList.SelectedIndex = selectedIndex;

        }

        private void JumpGamesBackward()
        {
            int qttGames = _roms.Count;
            int selectedIndex = _romList.SelectedIndex;

            int howManyGamesToJump = qttGames / 15;

            selectedIndex -= howManyGamesToJump;

            if (selectedIndex < 0)
            {
                selectedIndex = (_roms.Count - 1) + selectedIndex;

            }

            _romList.SelectedIndex = selectedIndex;

        }

        public void MoveForward()
        {
            if (_gamesPanel.Visible)
            {
                JumpGamesForward();
            }
            else
            {
                MoveSelectedForward();
            }
        }

        public void MoveBackward()
        {
            if (_gamesPanel.Visible)
            {
                JumpGamesBackward();
            }
            else
            {
                MoveSelectedBackward();
            }
        }

        public void MoveSelectedForward()
        {

            var selectedIndex = GetSelectedConsoleIndex();

            if (selectedIndex == Consoles.Count - 1)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex++;
            }

            for (int i = 0; i < Consoles.Count; i++)
            {
                Consoles[i].Selected = selectedIndex == i;
            }

            SetSelectedGamePanel();

        }

        public void MoveSelectedBackward()
        {
            var selectedIndex = GetSelectedConsoleIndex();

            if (selectedIndex == 0)
            {
                selectedIndex = Consoles.Count - 1;
            }
            else
            {
                selectedIndex--;
            }

            for (int i = 0; i < Consoles.Count; i++)
            {
                Consoles[i].Selected = selectedIndex == i;
            }

            SetSelectedGamePanel();
        }

        private int GetSelectedConsoleIndex()
        {
            return Consoles.IndexOf(Consoles.FirstOrDefault(x => x.Selected));
        }

        private void _moveForward_Click(object sender, EventArgs e)
        {
            MoveSelectedForward();
        }

        private void _moveBackward_Click(object sender, EventArgs e)
        {
            MoveSelectedBackward();
        }

        public void ShowGameConsole()
        {
            try
            {
                if (!_gamesPanel.Visible)
                {
                    var selectedConsole = Consoles.FirstOrDefault(x => x.Selected);

                    if (selectedConsole == null)
                    {
                        Utils.ShowError($"{nameof(SetSelectedGamePanel)}: Does not exists a console selected.");
                        return;
                    }

                    _console = NConsoleFactory.CreateConsole(selectedConsole.NConsole);

                    _roms = _console.ListRoms();

                    foreach (var item in _roms)
                    {
                        _romList.Items.Add(item.GetRomName());
                    }

                    _gamesPanel.Visible = true;
                    _romList.Focus();
                    _romList.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {

                Utils.ShowError($"{nameof(ShowGameConsole)}: Couldn't list roms: {ex.Message}");
            }
        }

        private void _closeGamePanel_Click(object sender, EventArgs e)
        {
            CloseGameConsole();
        }

        public void CloseGameConsole()
        {
            if (_gamesPanel.Visible)
            {
                _console = null;
                _romList.Items.Clear();
                _gameImage.Image = null;
                _gamesPanel.Visible = false;
            }
        }

        private void _romList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listBox = (ListBox)sender;
            var auxiliar = _roms.FirstOrDefault(x => x.GetRomName().Equals(listBox.SelectedItem.ToString()));
            if (auxiliar != null)
            {
                _gameImage.Image = new Bitmap(auxiliar.GetImagePath());
                _gameLabel.Text = listBox.SelectedItem.ToString();
            }

        }

        private void _romList_Click(object sender, EventArgs e)
        {
            PlaySelectedGame();
        }

        public void MoveGameListUp()
        {
            if (_gamesPanel.Visible)
            {
                var selectedIndex = _romList.SelectedIndex;
                if (selectedIndex == 0)
                {
                    selectedIndex = _romList.Items.Count - 1;
                }
                else
                {
                    selectedIndex--;
                }
                _romList.SelectedIndex = selectedIndex;
            }
        }

        public void MoveGameListDown()
        {
            if (_gamesPanel.Visible)
            {
                var selectedIndex = _romList.SelectedIndex;
                if (selectedIndex == (_romList.Items.Count - 1))
                {
                    selectedIndex = 0;
                }
                else
                {
                    selectedIndex++;
                }
                _romList.SelectedIndex = selectedIndex;
            }
        }

        public void PlaySelectedGame()
        {
            var rom = _romList.SelectedItem.ToString();
            var selectedRom = _roms.FirstOrDefault(x => x.GetRomName().Equals(rom));
            if (selectedRom == null)
            {
                Utils.ShowError($"Rom wasn't found.");
                return;
            }
            _console.Play(selectedRom);
        }

        public void StopSelectedGame()
        {
            _console.Stop();
        }
    }
}
