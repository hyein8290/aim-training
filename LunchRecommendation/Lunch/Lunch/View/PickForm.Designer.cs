namespace Lunch.View
{
    partial class PickForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlPickInfo = new System.Windows.Forms.Panel();
            this.lblThanks = new System.Windows.Forms.Label();
            this.lblRestName = new System.Windows.Forms.Label();
            this.btnRoulette = new System.Windows.Forms.Button();
            this.btnRestList = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlPickInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 50);
            this.panel1.TabIndex = 2;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::Lunch.Properties.Resources.home;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ForeColor = System.Drawing.Color.Transparent;
            this.btnHome.Location = new System.Drawing.Point(484, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(50, 50);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.BackgroundImage = global::Lunch.Properties.Resources.signout;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogout.Location = new System.Drawing.Point(534, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(50, 50);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlPickInfo
            // 
            this.pnlPickInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlPickInfo.Controls.Add(this.lblThanks);
            this.pnlPickInfo.Controls.Add(this.lblRestName);
            this.pnlPickInfo.Location = new System.Drawing.Point(96, 261);
            this.pnlPickInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPickInfo.Name = "pnlPickInfo";
            this.pnlPickInfo.Size = new System.Drawing.Size(393, 138);
            this.pnlPickInfo.TabIndex = 16;
            // 
            // lblThanks
            // 
            this.lblThanks.AutoSize = true;
            this.lblThanks.Font = new System.Drawing.Font("나눔고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblThanks.Location = new System.Drawing.Point(149, 81);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(100, 21);
            this.lblThanks.TabIndex = 2;
            this.lblThanks.Text = "감사합니다";
            this.lblThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRestName
            // 
            this.lblRestName.AutoSize = true;
            this.lblRestName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 20F, System.Drawing.FontStyle.Bold);
            this.lblRestName.Location = new System.Drawing.Point(20, 37);
            this.lblRestName.Name = "lblRestName";
            this.lblRestName.Size = new System.Drawing.Size(114, 31);
            this.lblRestName.TabIndex = 1;
            this.lblRestName.Text = "식당이름";
            this.lblRestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRoulette
            // 
            this.btnRoulette.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRoulette.FlatAppearance.BorderSize = 0;
            this.btnRoulette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoulette.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnRoulette.ForeColor = System.Drawing.Color.White;
            this.btnRoulette.Location = new System.Drawing.Point(296, 404);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(120, 30);
            this.btnRoulette.TabIndex = 19;
            this.btnRoulette.Text = "더 추천 받기";
            this.btnRoulette.UseVisualStyleBackColor = false;
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // btnRestList
            // 
            this.btnRestList.BackColor = System.Drawing.Color.LightGray;
            this.btnRestList.FlatAppearance.BorderSize = 0;
            this.btnRestList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestList.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnRestList.ForeColor = System.Drawing.Color.DimGray;
            this.btnRestList.Location = new System.Drawing.Point(170, 404);
            this.btnRestList.Name = "btnRestList";
            this.btnRestList.Size = new System.Drawing.Size(120, 30);
            this.btnRestList.TabIndex = 18;
            this.btnRestList.Text = "식당목록보기";
            this.btnRestList.UseVisualStyleBackColor = false;
            this.btnRestList.Click += new System.EventHandler(this.btnRestList_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 50F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(89, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(423, 77);
            this.label4.TabIndex = 30;
            this.label4.Text = "오늘 뭐 먹지?";
            // 
            // PickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRoulette);
            this.Controls.Add(this.btnRestList);
            this.Controls.Add(this.pnlPickInfo);
            this.Controls.Add(this.panel1);
            this.Name = "PickForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "오늘 뭐 먹지?";
            this.Load += new System.EventHandler(this.PickForm_Load);
            this.panel1.ResumeLayout(false);
            this.pnlPickInfo.ResumeLayout(false);
            this.pnlPickInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlPickInfo;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Label lblRestName;
        private System.Windows.Forms.Button btnRoulette;
        private System.Windows.Forms.Button btnRestList;
        private System.Windows.Forms.Label label4;
    }
}