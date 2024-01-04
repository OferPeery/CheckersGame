namespace CheckersGame.UI
{
    partial class FormGameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.radioButton6x6 = new System.Windows.Forms.RadioButton();
            this.radioButton8x8 = new System.Windows.Forms.RadioButton();
            this.radioButton10x10 = new System.Windows.Forms.RadioButton();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.timerTitleAnimation = new System.Windows.Forms.Timer(this.components);
            this.timerTitleHold = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Levenim MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoardSize.ForeColor = System.Drawing.Color.Khaki;
            this.labelBoardSize.Location = new System.Drawing.Point(16, 68);
            this.labelBoardSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(119, 27);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // radioButton6x6
            // 
            this.radioButton6x6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton6x6.AutoSize = true;
            this.radioButton6x6.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton6x6.ForeColor = System.Drawing.Color.Wheat;
            this.radioButton6x6.Location = new System.Drawing.Point(39, 106);
            this.radioButton6x6.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton6x6.Name = "radioButton6x6";
            this.radioButton6x6.Size = new System.Drawing.Size(61, 27);
            this.radioButton6x6.TabIndex = 1;
            this.radioButton6x6.TabStop = true;
            this.radioButton6x6.Tag = "6";
            this.radioButton6x6.Text = "6x6";
            this.radioButton6x6.UseVisualStyleBackColor = true;
            this.radioButton6x6.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton8x8
            // 
            this.radioButton8x8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton8x8.AutoSize = true;
            this.radioButton8x8.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton8x8.ForeColor = System.Drawing.Color.Wheat;
            this.radioButton8x8.Location = new System.Drawing.Point(141, 106);
            this.radioButton8x8.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton8x8.Name = "radioButton8x8";
            this.radioButton8x8.Size = new System.Drawing.Size(61, 27);
            this.radioButton8x8.TabIndex = 2;
            this.radioButton8x8.TabStop = true;
            this.radioButton8x8.Tag = "8";
            this.radioButton8x8.Text = "8x8";
            this.radioButton8x8.UseVisualStyleBackColor = true;
            this.radioButton8x8.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioButton10x10
            // 
            this.radioButton10x10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.radioButton10x10.AutoSize = true;
            this.radioButton10x10.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton10x10.ForeColor = System.Drawing.Color.Wheat;
            this.radioButton10x10.Location = new System.Drawing.Point(261, 106);
            this.radioButton10x10.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton10x10.Name = "radioButton10x10";
            this.radioButton10x10.Size = new System.Drawing.Size(81, 27);
            this.radioButton10x10.TabIndex = 3;
            this.radioButton10x10.TabStop = true;
            this.radioButton10x10.Tag = "10";
            this.radioButton10x10.Text = "10x10";
            this.radioButton10x10.UseVisualStyleBackColor = true;
            this.radioButton10x10.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Levenim MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayers.ForeColor = System.Drawing.Color.Khaki;
            this.labelPlayers.Location = new System.Drawing.Point(16, 164);
            this.labelPlayers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(87, 27);
            this.labelPlayers.TabIndex = 4;
            this.labelPlayers.Text = "Players:";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayer1.Location = new System.Drawing.Point(171, 199);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPlayer1.MaxLength = 10;
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(132, 30);
            this.textBoxPlayer1.TabIndex = 5;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1.ForeColor = System.Drawing.Color.Wheat;
            this.labelPlayer1.Location = new System.Drawing.Point(33, 203);
            this.labelPlayer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(76, 23);
            this.labelPlayer1.TabIndex = 4;
            this.labelPlayer1.Text = "Player1:";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPlayer2.ForeColor = System.Drawing.Color.Wheat;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(37, 239);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(104, 27);
            this.checkBoxPlayer2.TabIndex = 6;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Font = new System.Drawing.Font("Levenim MT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayer2.Location = new System.Drawing.Point(171, 236);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPlayer2.MaxLength = 10;
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(132, 30);
            this.textBoxPlayer2.TabIndex = 7;
            this.textBoxPlayer2.Text = "Computer";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(215, 306);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(140, 28);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(68, 11);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(229, 47);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Checkers Game";
            // 
            // timerTitleAnimation
            // 
            this.timerTitleAnimation.Enabled = true;
            this.timerTitleAnimation.Tick += new System.EventHandler(this.timerTitleAnimation_Tick);
            // 
            // timerTitleHold
            // 
            this.timerTitleHold.Interval = 1000;
            this.timerTitleHold.Tick += new System.EventHandler(this.timerTitleHold_Tick);
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(371, 350);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.radioButton10x10);
            this.Controls.Add(this.radioButton8x8);
            this.Controls.Add(this.radioButton6x6);
            this.Controls.Add(this.labelBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formGameSettings_FormClosing);
            this.Load += new System.EventHandler(this.formGameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.RadioButton radioButton6x6;
        private System.Windows.Forms.RadioButton radioButton8x8;
        private System.Windows.Forms.RadioButton radioButton10x10;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Timer timerTitleAnimation;
        private System.Windows.Forms.Timer timerTitleHold;
    }
}