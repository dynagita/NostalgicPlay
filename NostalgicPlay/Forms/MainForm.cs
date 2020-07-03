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

        public NostalgicPlay()
        {
            InitializeComponent();
            LoadConsoles();
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
                ShowError(ex.Message);
            }

        }

        private void SetSelectedGamePanel()
        {
            var consoleSelected = Consoles.FirstOrDefault(x => x.Selected);
            if (consoleSelected == null)
            {
                ShowError($"{nameof(SetSelectedGamePanel)}: Does not exists a console selected.");
                return;
            }
            __selectedGamePanel.Image = consoleSelected.Image;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MoveSelectedForward()
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

        private void MoveSelectedBackward()
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

        private void ShowGameConsole()
        {
            try
            {
                var selectedConsole = Consoles.FirstOrDefault(x => x.Selected);

                if (selectedConsole == null)
                {
                    ShowError($"{nameof(SetSelectedGamePanel)}: Does not exists a console selected.");
                    return;
                }

                _console = NConsoleFactory.CreateConsole(selectedConsole.NConsole);

                //var roms = _console.ListRoms();

                //foreach (var item in roms)
                //{
                //    _romList.Items.Add(item.ToString());
                //}

                _gamesPanel.Visible = true;
            }
            catch (Exception ex)
            {

                ShowError($"{nameof(ShowGameConsole)}: Couldn't list roms: {ex.Message}");
            }            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _console = null;
            _romList.Items.Clear();
            _gameImage.Image = null;
            _gamesPanel.Visible = false;
        }
    }
}
