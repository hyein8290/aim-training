namespace Lunch.View
{
    partial class RouletteForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlRoulette = new System.Windows.Forms.Panel();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblRestName = new System.Windows.Forms.Label();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.btnRoulette = new System.Windows.Forms.Button();
            this.tlpExceptRest = new System.Windows.Forms.TableLayoutPanel();
            this.btnExceptRest = new System.Windows.Forms.Button();
            this.txtExceptRest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cblExcept = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cblPrefer = new System.Windows.Forms.CheckedListBox();
            this.btnReroulette = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlRoulette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
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
            this.panel1.TabIndex = 1;
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
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.pnlRoulette);
            this.pnlMain.Controls.Add(this.btnRoulette);
            this.pnlMain.Controls.Add(this.tlpExceptRest);
            this.pnlMain.Controls.Add(this.btnExceptRest);
            this.pnlMain.Controls.Add(this.txtExceptRest);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.cblExcept);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.cblPrefer);
            this.pnlMain.Controls.Add(this.btnReroulette);
            this.pnlMain.Controls.Add(this.btnPick);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pnlMain.Location = new System.Drawing.Point(0, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(584, 611);
            this.pnlMain.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 50F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(89, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(423, 77);
            this.label4.TabIndex = 29;
            this.label4.Text = "오늘 뭐 먹지?";
            // 
            // pnlRoulette
            // 
            this.pnlRoulette.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlRoulette.Controls.Add(this.lblSignature);
            this.pnlRoulette.Controls.Add(this.lblRestName);
            this.pnlRoulette.Controls.Add(this.picQuestion);
            this.pnlRoulette.Location = new System.Drawing.Point(89, 322);
            this.pnlRoulette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRoulette.Name = "pnlRoulette";
            this.pnlRoulette.Size = new System.Drawing.Size(393, 138);
            this.pnlRoulette.TabIndex = 26;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSignature.Location = new System.Drawing.Point(143, 80);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(0, 28);
            this.lblSignature.TabIndex = 4;
            this.lblSignature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignature.Visible = false;
            // 
            // lblRestName
            // 
            this.lblRestName.AutoSize = true;
            this.lblRestName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRestName.Location = new System.Drawing.Point(18, 44);
            this.lblRestName.Name = "lblRestName";
            this.lblRestName.Size = new System.Drawing.Size(363, 36);
            this.lblRestName.TabIndex = 3;
            this.lblRestName.Text = "존재하는 식당이 없습니다";
            this.lblRestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRestName.Visible = false;
            // 
            // picQuestion
            // 
            this.picQuestion.Image = global::Lunch.Properties.Resources.questionsign;
            this.picQuestion.Location = new System.Drawing.Point(155, 26);
            this.picQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(88, 80);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestion.TabIndex = 0;
            this.picQuestion.TabStop = false;
            // 
            // btnRoulette
            // 
            this.btnRoulette.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRoulette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoulette.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnRoulette.ForeColor = System.Drawing.Color.White;
            this.btnRoulette.Location = new System.Drawing.Point(228, 474);
            this.btnRoulette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(120, 30);
            this.btnRoulette.TabIndex = 25;
            this.btnRoulette.Text = "추천";
            this.btnRoulette.UseVisualStyleBackColor = false;
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // tlpExceptRest
            // 
            this.tlpExceptRest.ColumnCount = 2;
            this.tlpExceptRest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExceptRest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExceptRest.Location = new System.Drawing.Point(213, 242);
            this.tlpExceptRest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpExceptRest.Name = "tlpExceptRest";
            this.tlpExceptRest.RowCount = 3;
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpExceptRest.Size = new System.Drawing.Size(270, 75);
            this.tlpExceptRest.TabIndex = 17;
            // 
            // btnExceptRest
            // 
            this.btnExceptRest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExceptRest.Font = new System.Drawing.Font("나눔고딕", 10F);
            this.btnExceptRest.Location = new System.Drawing.Point(417, 215);
            this.btnExceptRest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExceptRest.Name = "btnExceptRest";
            this.btnExceptRest.Size = new System.Drawing.Size(70, 24);
            this.btnExceptRest.TabIndex = 24;
            this.btnExceptRest.Text = "추가";
            this.btnExceptRest.UseVisualStyleBackColor = true;
            this.btnExceptRest.Click += new System.EventHandler(this.btnExceptRest_Click);
            // 
            // txtExceptRest
            // 
            this.txtExceptRest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExceptRest.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtExceptRest.Location = new System.Drawing.Point(213, 216);
            this.txtExceptRest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExceptRest.Name = "txtExceptRest";
            this.txtExceptRest.Size = new System.Drawing.Size(199, 25);
            this.txtExceptRest.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(87, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "제외식당";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(87, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "제외음식";
            // 
            // cblExcept
            // 
            this.cblExcept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cblExcept.CheckOnClick = true;
            this.cblExcept.ColumnWidth = 60;
            this.cblExcept.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cblExcept.Items.AddRange(new object[] {
            "한식",
            "중식",
            "일식",
            "양식",
            "기타"});
            this.cblExcept.Location = new System.Drawing.Point(213, 187);
            this.cblExcept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cblExcept.MultiColumn = true;
            this.cblExcept.Name = "cblExcept";
            this.cblExcept.Size = new System.Drawing.Size(321, 20);
            this.cblExcept.TabIndex = 20;
            this.cblExcept.SelectedIndexChanged += new System.EventHandler(this.cblExcept_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(87, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "선호음식";
            // 
            // cblPrefer
            // 
            this.cblPrefer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cblPrefer.CheckOnClick = true;
            this.cblPrefer.ColumnWidth = 60;
            this.cblPrefer.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cblPrefer.Items.AddRange(new object[] {
            "한식",
            "중식",
            "일식",
            "양식",
            "기타"});
            this.cblPrefer.Location = new System.Drawing.Point(213, 152);
            this.cblPrefer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cblPrefer.MultiColumn = true;
            this.cblPrefer.Name = "cblPrefer";
            this.cblPrefer.Size = new System.Drawing.Size(321, 20);
            this.cblPrefer.TabIndex = 18;
            this.cblPrefer.SelectedIndexChanged += new System.EventHandler(this.cblPrefer_SelectedIndexChanged);
            // 
            // btnReroulette
            // 
            this.btnReroulette.BackColor = System.Drawing.Color.LightGray;
            this.btnReroulette.FlatAppearance.BorderSize = 0;
            this.btnReroulette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReroulette.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnReroulette.ForeColor = System.Drawing.Color.DimGray;
            this.btnReroulette.Location = new System.Drawing.Point(167, 474);
            this.btnReroulette.Name = "btnReroulette";
            this.btnReroulette.Size = new System.Drawing.Size(120, 30);
            this.btnReroulette.TabIndex = 27;
            this.btnReroulette.Text = "재추천";
            this.btnReroulette.UseVisualStyleBackColor = false;
            this.btnReroulette.Visible = false;
            this.btnReroulette.Click += new System.EventHandler(this.btnReroulette_Click);
            // 
            // btnPick
            // 
            this.btnPick.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPick.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.btnPick.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPick.Location = new System.Drawing.Point(293, 474);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(120, 30);
            this.btnPick.TabIndex = 28;
            this.btnPick.Text = "선택";
            this.btnPick.UseVisualStyleBackColor = false;
            this.btnPick.Visible = false;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // RouletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.panel1);
            this.Name = "RouletteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "오늘 뭐 먹지?";
            this.panel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlRoulette.ResumeLayout(false);
            this.pnlRoulette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRoulette;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.Button btnRoulette;
        private System.Windows.Forms.TableLayoutPanel tlpExceptRest;
        private System.Windows.Forms.Button btnExceptRest;
        private System.Windows.Forms.TextBox txtExceptRest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cblExcept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox cblPrefer;
        private System.Windows.Forms.Button btnReroulette;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblRestName;
    }
}