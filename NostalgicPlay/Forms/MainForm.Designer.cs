namespace NostalgicPlay
{
    partial class NostalgicPlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NostalgicPlay));
            this._mainPicPanel = new System.Windows.Forms.PictureBox();
            this.@__selectedGamePanel = new System.Windows.Forms.PictureBox();
            this._moveForward = new System.Windows.Forms.PictureBox();
            this._moveBackward = new System.Windows.Forms.PictureBox();
            this._gamesPanel = new System.Windows.Forms.Panel();
            this._gameLabel = new System.Windows.Forms.Label();
            this._gameImage = new System.Windows.Forms.PictureBox();
            this._romList = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._mainPicPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.@__selectedGamePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._moveForward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._moveBackward)).BeginInit();
            this._gamesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gameImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _mainPicPanel
            // 
            this._mainPicPanel.Image = ((System.Drawing.Image)(resources.GetObject("_mainPicPanel.Image")));
            this._mainPicPanel.Location = new System.Drawing.Point(0, 0);
            this._mainPicPanel.Name = "_mainPicPanel";
            this._mainPicPanel.Size = new System.Drawing.Size(801, 452);
            this._mainPicPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._mainPicPanel.TabIndex = 0;
            this._mainPicPanel.TabStop = false;
            // 
            // __selectedGamePanel
            // 
            this.@__selectedGamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__selectedGamePanel.Location = new System.Drawing.Point(270, 128);
            this.@__selectedGamePanel.Name = "__selectedGamePanel";
            this.@__selectedGamePanel.Size = new System.Drawing.Size(249, 186);
            this.@__selectedGamePanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.@__selectedGamePanel.TabIndex = 1;
            this.@__selectedGamePanel.TabStop = false;
            this.@__selectedGamePanel.Click += new System.EventHandler(this.@__selectedGamePanel_Click);
            // 
            // _moveForward
            // 
            this._moveForward.Image = ((System.Drawing.Image)(resources.GetObject("_moveForward.Image")));
            this._moveForward.Location = new System.Drawing.Point(738, 197);
            this._moveForward.Name = "_moveForward";
            this._moveForward.Size = new System.Drawing.Size(50, 50);
            this._moveForward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._moveForward.TabIndex = 2;
            this._moveForward.TabStop = false;
            this._moveForward.Click += new System.EventHandler(this._moveForward_Click);
            // 
            // _moveBackward
            // 
            this._moveBackward.Image = ((System.Drawing.Image)(resources.GetObject("_moveBackward.Image")));
            this._moveBackward.Location = new System.Drawing.Point(12, 197);
            this._moveBackward.Name = "_moveBackward";
            this._moveBackward.Size = new System.Drawing.Size(50, 50);
            this._moveBackward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._moveBackward.TabIndex = 3;
            this._moveBackward.TabStop = false;
            this._moveBackward.Click += new System.EventHandler(this._moveBackward_Click);
            // 
            // _gamesPanel
            // 
            this._gamesPanel.Controls.Add(this.pictureBox1);
            this._gamesPanel.Controls.Add(this._gameLabel);
            this._gamesPanel.Controls.Add(this._gameImage);
            this._gamesPanel.Controls.Add(this._romList);
            this._gamesPanel.Location = new System.Drawing.Point(0, 0);
            this._gamesPanel.Name = "_gamesPanel";
            this._gamesPanel.Size = new System.Drawing.Size(801, 452);
            this._gamesPanel.TabIndex = 4;
            this._gamesPanel.Visible = false;
            // 
            // _gameLabel
            // 
            this._gameLabel.AutoSize = true;
            this._gameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._gameLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._gameLabel.Location = new System.Drawing.Point(414, 413);
            this._gameLabel.Name = "_gameLabel";
            this._gameLabel.Size = new System.Drawing.Size(0, 25);
            this._gameLabel.TabIndex = 2;
            // 
            // _gameImage
            // 
            this._gameImage.Location = new System.Drawing.Point(410, 12);
            this._gameImage.Name = "_gameImage";
            this._gameImage.Size = new System.Drawing.Size(365, 384);
            this._gameImage.TabIndex = 1;
            this._gameImage.TabStop = false;
            // 
            // _romList
            // 
            this._romList.HideSelection = false;
            this._romList.Location = new System.Drawing.Point(12, 12);
            this._romList.Name = "_romList";
            this._romList.Size = new System.Drawing.Size(372, 426);
            this._romList.TabIndex = 0;
            this._romList.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(748, 399);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // NostalgicPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._gamesPanel);
            this.Controls.Add(this._moveBackward);
            this.Controls.Add(this._moveForward);
            this.Controls.Add(this.@__selectedGamePanel);
            this.Controls.Add(this._mainPicPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NostalgicPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NostalgicPlay";
            ((System.ComponentModel.ISupportInitialize)(this._mainPicPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.@__selectedGamePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._moveForward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._moveBackward)).EndInit();
            this._gamesPanel.ResumeLayout(false);
            this._gamesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gameImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _mainPicPanel;
        private System.Windows.Forms.PictureBox __selectedGamePanel;
        private System.Windows.Forms.PictureBox _moveForward;
        private System.Windows.Forms.PictureBox _moveBackward;
        private System.Windows.Forms.Panel _gamesPanel;
        private System.Windows.Forms.Label _gameLabel;
        private System.Windows.Forms.PictureBox _gameImage;
        private System.Windows.Forms.ListView _romList;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

