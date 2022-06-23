namespace LunchRoulette.View
{
    partial class MainForm
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
            this.pnlCommon = new System.Windows.Forms.Panel();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCommon
            // 
            this.pnlCommon.Controls.Add(this.picHome);
            this.pnlCommon.Controls.Add(this.picLogout);
            this.pnlCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommon.Location = new System.Drawing.Point(0, 0);
            this.pnlCommon.Name = "pnlCommon";
            this.pnlCommon.Size = new System.Drawing.Size(600, 50);
            this.pnlCommon.TabIndex = 0;
            // 
            // picHome
            // 
            this.picHome.Dock = System.Windows.Forms.DockStyle.Right;
            this.picHome.Image = global::LunchRoulette.Properties.Resources.home;
            this.picHome.Location = new System.Drawing.Point(500, 0);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(50, 50);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 1;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            this.picHome.MouseHover += new System.EventHandler(this.picHome_MouseHover);
            // 
            // picLogout
            // 
            this.picLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.picLogout.Image = global::LunchRoulette.Properties.Resources.signout;
            this.picLogout.Location = new System.Drawing.Point(550, 0);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(50, 50);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogout.TabIndex = 0;
            this.picLogout.TabStop = false;
            this.picLogout.Click += new System.EventHandler(this.picLogout_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 700);
            this.pnlMain.TabIndex = 1;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Maroon;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(600, 749);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlCommon);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "오늘 뭐 먹지?";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.pnlCommon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCommon;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}