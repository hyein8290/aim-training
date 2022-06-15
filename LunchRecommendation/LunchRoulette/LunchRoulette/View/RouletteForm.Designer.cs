namespace LunchRoulette.View
{
    partial class RouletteForm
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cblPrefer = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cblExcept = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExceptRest = new System.Windows.Forms.TextBox();
            this.btnExceptRest = new System.Windows.Forms.Button();
            this.tlpExceptRest = new System.Windows.Forms.TableLayoutPanel();
            this.btnRoulette = new System.Windows.Forms.Button();
            this.pnlRoulette = new System.Windows.Forms.Panel();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblRestName = new System.Windows.Forms.Label();
            this.picQuestion = new System.Windows.Forms.PictureBox();
            this.btnReroulette = new System.Windows.Forms.Button();
            this.btnPick = new System.Windows.Forms.Button();
            this.pnlRoulette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).BeginInit();
            this.SuspendLayout();
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
            this.cblPrefer.Location = new System.Drawing.Point(227, 170);
            this.cblPrefer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cblPrefer.MultiColumn = true;
            this.cblPrefer.Name = "cblPrefer";
            this.cblPrefer.Size = new System.Drawing.Size(321, 20);
            this.cblPrefer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(101, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "선호음식";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(101, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 5;
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
            this.cblExcept.Location = new System.Drawing.Point(227, 205);
            this.cblExcept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cblExcept.MultiColumn = true;
            this.cblExcept.Name = "cblExcept";
            this.cblExcept.Size = new System.Drawing.Size(321, 20);
            this.cblExcept.TabIndex = 4;
            this.cblExcept.SelectedIndexChanged += new System.EventHandler(this.cblExcept_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(101, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "제외식당";
            // 
            // txtExceptRest
            // 
            this.txtExceptRest.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtExceptRest.Location = new System.Drawing.Point(227, 234);
            this.txtExceptRest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExceptRest.Name = "txtExceptRest";
            this.txtExceptRest.Size = new System.Drawing.Size(199, 25);
            this.txtExceptRest.TabIndex = 7;
            // 
            // btnExceptRest
            // 
            this.btnExceptRest.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExceptRest.Location = new System.Drawing.Point(431, 233);
            this.btnExceptRest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExceptRest.Name = "btnExceptRest";
            this.btnExceptRest.Size = new System.Drawing.Size(70, 24);
            this.btnExceptRest.TabIndex = 8;
            this.btnExceptRest.Text = "추가";
            this.btnExceptRest.UseVisualStyleBackColor = true;
            this.btnExceptRest.Click += new System.EventHandler(this.btnExceptRest_Click);
            // 
            // tlpExceptRest
            // 
            this.tlpExceptRest.ColumnCount = 2;
            this.tlpExceptRest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExceptRest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpExceptRest.Location = new System.Drawing.Point(227, 260);
            this.tlpExceptRest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlpExceptRest.Name = "tlpExceptRest";
            this.tlpExceptRest.RowCount = 3;
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpExceptRest.Size = new System.Drawing.Size(270, 75);
            this.tlpExceptRest.TabIndex = 0;
            // 
            // btnRoulette
            // 
            this.btnRoulette.Location = new System.Drawing.Point(272, 492);
            this.btnRoulette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(66, 25);
            this.btnRoulette.TabIndex = 12;
            this.btnRoulette.Text = "추천";
            this.btnRoulette.UseVisualStyleBackColor = true;
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // pnlRoulette
            // 
            this.pnlRoulette.BackColor = System.Drawing.Color.Gray;
            this.pnlRoulette.Controls.Add(this.lblSignature);
            this.pnlRoulette.Controls.Add(this.lblRestName);
            this.pnlRoulette.Controls.Add(this.picQuestion);
            this.pnlRoulette.Location = new System.Drawing.Point(103, 340);
            this.pnlRoulette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRoulette.Name = "pnlRoulette";
            this.pnlRoulette.Size = new System.Drawing.Size(393, 138);
            this.pnlRoulette.TabIndex = 14;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSignature.Location = new System.Drawing.Point(147, 73);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(104, 28);
            this.lblSignature.TabIndex = 2;
            this.lblSignature.Text = "시그니처";
            this.lblSignature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignature.Visible = false;
            // 
            // lblRestName
            // 
            this.lblRestName.AutoSize = true;
            this.lblRestName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRestName.Location = new System.Drawing.Point(135, 37);
            this.lblRestName.Name = "lblRestName";
            this.lblRestName.Size = new System.Drawing.Size(135, 36);
            this.lblRestName.TabIndex = 1;
            this.lblRestName.Text = "식당이름";
            this.lblRestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRestName.Visible = false;
            // 
            // picQuestion
            // 
            this.picQuestion.Image = global::LunchRoulette.Properties.Resources.question_sign;
            this.picQuestion.Location = new System.Drawing.Point(155, 26);
            this.picQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(88, 80);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestion.TabIndex = 0;
            this.picQuestion.TabStop = false;
            // 
            // btnReroulette
            // 
            this.btnReroulette.Location = new System.Drawing.Point(226, 492);
            this.btnReroulette.Name = "btnReroulette";
            this.btnReroulette.Size = new System.Drawing.Size(75, 23);
            this.btnReroulette.TabIndex = 15;
            this.btnReroulette.Text = "재추천";
            this.btnReroulette.UseVisualStyleBackColor = true;
            this.btnReroulette.Visible = false;
            this.btnReroulette.Click += new System.EventHandler(this.btnReroulette_Click);
            // 
            // btnPick
            // 
            this.btnPick.Location = new System.Drawing.Point(307, 492);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(75, 23);
            this.btnPick.TabIndex = 16;
            this.btnPick.Text = "선택";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Visible = false;
            this.btnPick.Click += new System.EventHandler(this.btnPick_Click);
            // 
            // RouletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlRoulette);
            this.Controls.Add(this.btnRoulette);
            this.Controls.Add(this.tlpExceptRest);
            this.Controls.Add(this.btnExceptRest);
            this.Controls.Add(this.txtExceptRest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cblExcept);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cblPrefer);
            this.Controls.Add(this.btnReroulette);
            this.Controls.Add(this.btnPick);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RouletteForm";
            this.Size = new System.Drawing.Size(600, 700);
            this.Load += new System.EventHandler(this.RouletteForm_Load);
            this.pnlRoulette.ResumeLayout(false);
            this.pnlRoulette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cblPrefer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cblExcept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExceptRest;
        private System.Windows.Forms.Button btnExceptRest;
        private System.Windows.Forms.TableLayoutPanel tlpExceptRest;
        private System.Windows.Forms.Button btnRoulette;
        private System.Windows.Forms.Panel pnlRoulette;
        private System.Windows.Forms.PictureBox picQuestion;
        private System.Windows.Forms.Label lblRestName;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Button btnReroulette;
        private System.Windows.Forms.Button btnPick;
    }
}
