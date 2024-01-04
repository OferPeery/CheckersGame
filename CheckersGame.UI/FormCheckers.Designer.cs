namespace CheckersGame.UI
{
    partial class FormCheckers
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckers));
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.timerConfetyAnimation = new System.Windows.Forms.Timer(this.components);
            this.panelPlayersAndScores = new System.Windows.Forms.Panel();
            this.labelCurrentPlayerTurn = new System.Windows.Forms.Label();
            this.labelSecondPlayerName = new System.Windows.Forms.Label();
            this.pictureBoxSecondPlayerChecker = new System.Windows.Forms.PictureBox();
            this.labelFirstPlayerName = new System.Windows.Forms.Label();
            this.pictureBoxFirstPlayerChecker = new System.Windows.Forms.PictureBox();
            this.labelCurrentTurnTitle = new System.Windows.Forms.Label();
            this.panelPlayersAndScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondPlayerChecker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirstPlayerChecker)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1599, 1529);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(221, 197);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(756, 1529);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(221, 197);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1313, 1510);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(221, 197);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1029, 1510);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(221, 197);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panelBoard
            // 
            this.panelBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelBoard.Location = new System.Drawing.Point(81, 181);
            this.panelBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(267, 123);
            this.panelBoard.TabIndex = 8;
            // 
            // timerConfetyAnimation
            // 
            this.timerConfetyAnimation.Interval = 10;
            this.timerConfetyAnimation.Tick += new System.EventHandler(this.timerConfettiAnimation_Tick);
            // 
            // panelPlayersAndScores
            // 
            this.panelPlayersAndScores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelPlayersAndScores.BackColor = System.Drawing.Color.Tan;
            this.panelPlayersAndScores.Controls.Add(this.labelCurrentPlayerTurn);
            this.panelPlayersAndScores.Controls.Add(this.labelSecondPlayerName);
            this.panelPlayersAndScores.Controls.Add(this.pictureBoxSecondPlayerChecker);
            this.panelPlayersAndScores.Controls.Add(this.labelFirstPlayerName);
            this.panelPlayersAndScores.Controls.Add(this.pictureBoxFirstPlayerChecker);
            this.panelPlayersAndScores.Controls.Add(this.labelCurrentTurnTitle);
            this.panelPlayersAndScores.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPlayersAndScores.Location = new System.Drawing.Point(0, 0);
            this.panelPlayersAndScores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelPlayersAndScores.Name = "panelPlayersAndScores";
            this.panelPlayersAndScores.Size = new System.Drawing.Size(687, 154);
            this.panelPlayersAndScores.TabIndex = 9;
            // 
            // labelCurrentPlayerTurn
            // 
            this.labelCurrentPlayerTurn.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCurrentPlayerTurn.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentPlayerTurn.ForeColor = System.Drawing.Color.SeaShell;
            this.labelCurrentPlayerTurn.Location = new System.Drawing.Point(0, 27);
            this.labelCurrentPlayerTurn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentPlayerTurn.Name = "labelCurrentPlayerTurn";
            this.labelCurrentPlayerTurn.Size = new System.Drawing.Size(687, 25);
            this.labelCurrentPlayerTurn.TabIndex = 16;
            this.labelCurrentPlayerTurn.Text = "[Player 1]:";
            this.labelCurrentPlayerTurn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSecondPlayerName
            // 
            this.labelSecondPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSecondPlayerName.ForeColor = System.Drawing.Color.SeaShell;
            this.labelSecondPlayerName.Location = new System.Drawing.Point(467, 128);
            this.labelSecondPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSecondPlayerName.Name = "labelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(96, 23);
            this.labelSecondPlayerName.TabIndex = 15;
            this.labelSecondPlayerName.Text = "[Player 2]:";
            this.labelSecondPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxSecondPlayerChecker
            // 
            this.pictureBoxSecondPlayerChecker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSecondPlayerChecker.BackgroundImage = global::CheckersGame.UI.Properties.Resources.BrownCheckerCompressed;
            this.pictureBoxSecondPlayerChecker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSecondPlayerChecker.Location = new System.Drawing.Point(487, 70);
            this.pictureBoxSecondPlayerChecker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxSecondPlayerChecker.Name = "pictureBoxSecondPlayerChecker";
            this.pictureBoxSecondPlayerChecker.Size = new System.Drawing.Size(63, 54);
            this.pictureBoxSecondPlayerChecker.TabIndex = 15;
            this.pictureBoxSecondPlayerChecker.TabStop = false;
            // 
            // labelFirstPlayerName
            // 
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstPlayerName.ForeColor = System.Drawing.Color.SeaShell;
            this.labelFirstPlayerName.Location = new System.Drawing.Point(123, 132);
            this.labelFirstPlayerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstPlayerName.Name = "labelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(96, 23);
            this.labelFirstPlayerName.TabIndex = 13;
            this.labelFirstPlayerName.Text = "[Player 1]:";
            this.labelFirstPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxFirstPlayerChecker
            // 
            this.pictureBoxFirstPlayerChecker.BackgroundImage = global::CheckersGame.UI.Properties.Resources.WhiteCheckerCompressed;
            this.pictureBoxFirstPlayerChecker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxFirstPlayerChecker.Location = new System.Drawing.Point(147, 70);
            this.pictureBoxFirstPlayerChecker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBoxFirstPlayerChecker.Name = "pictureBoxFirstPlayerChecker";
            this.pictureBoxFirstPlayerChecker.Size = new System.Drawing.Size(60, 58);
            this.pictureBoxFirstPlayerChecker.TabIndex = 12;
            this.pictureBoxFirstPlayerChecker.TabStop = false;
            // 
            // labelCurrentTurnTitle
            // 
            this.labelCurrentTurnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCurrentTurnTitle.Font = new System.Drawing.Font("Levenim MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTurnTitle.ForeColor = System.Drawing.Color.GhostWhite;
            this.labelCurrentTurnTitle.Location = new System.Drawing.Point(0, 0);
            this.labelCurrentTurnTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentTurnTitle.Name = "labelCurrentTurnTitle";
            this.labelCurrentTurnTitle.Size = new System.Drawing.Size(687, 27);
            this.labelCurrentTurnTitle.TabIndex = 11;
            this.labelCurrentTurnTitle.Text = "Current Turn:";
            this.labelCurrentTurnTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormCheckers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 374);
            this.Controls.Add(this.panelPlayersAndScores);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCheckers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers Game";
            this.Load += new System.EventHandler(this.formCheckers_Load);
            this.panelPlayersAndScores.ResumeLayout(false);
            this.panelPlayersAndScores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondPlayerChecker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirstPlayerChecker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Panel panelPlayersAndScores;
        private System.Windows.Forms.Label labelCurrentTurnTitle;
        private System.Windows.Forms.Label labelFirstPlayerName;
        private System.Windows.Forms.PictureBox pictureBoxFirstPlayerChecker;
        private System.Windows.Forms.PictureBox pictureBoxSecondPlayerChecker;
        private System.Windows.Forms.Label labelSecondPlayerName;
        private System.Windows.Forms.Label labelCurrentPlayerTurn;
        private System.Windows.Forms.Timer timerConfetyAnimation;
    }
}