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
            this.picQuestion = new System.Windows.Forms.PictureBox();
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
            this.cblPrefer.Location = new System.Drawing.Point(243, 169);
            this.cblPrefer.MultiColumn = true;
            this.cblPrefer.Name = "cblPrefer";
            this.cblPrefer.Size = new System.Drawing.Size(400, 20);
            this.cblPrefer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(99, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "선호음식";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(99, 213);
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
            this.cblExcept.Location = new System.Drawing.Point(243, 213);
            this.cblExcept.MultiColumn = true;
            this.cblExcept.Name = "cblExcept";
            this.cblExcept.Size = new System.Drawing.Size(400, 20);
            this.cblExcept.TabIndex = 4;
            this.cblExcept.SelectedIndexChanged += new System.EventHandler(this.cblExcept_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(99, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "제외식당";
            // 
            // txtExceptRest
            // 
            this.txtExceptRest.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtExceptRest.Location = new System.Drawing.Point(243, 249);
            this.txtExceptRest.Name = "txtExceptRest";
            this.txtExceptRest.Size = new System.Drawing.Size(227, 25);
            this.txtExceptRest.TabIndex = 7;
            // 
            // btnExceptRest
            // 
            this.btnExceptRest.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExceptRest.Location = new System.Drawing.Point(476, 248);
            this.btnExceptRest.Name = "btnExceptRest";
            this.btnExceptRest.Size = new System.Drawing.Size(80, 30);
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
            this.tlpExceptRest.Location = new System.Drawing.Point(243, 282);
            this.tlpExceptRest.Name = "tlpExceptRest";
            this.tlpExceptRest.RowCount = 3;
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpExceptRest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpExceptRest.Size = new System.Drawing.Size(308, 94);
            this.tlpExceptRest.TabIndex = 0;
            // 
            // btnRoulette
            // 
            this.btnRoulette.Location = new System.Drawing.Point(295, 571);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(75, 23);
            this.btnRoulette.TabIndex = 12;
            this.btnRoulette.Text = "추천";
            this.btnRoulette.UseVisualStyleBackColor = true;
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // pnlRoulette
            // 
            this.pnlRoulette.BackColor = System.Drawing.Color.Gray;
            this.pnlRoulette.Controls.Add(this.picQuestion);
            this.pnlRoulette.Location = new System.Drawing.Point(102, 382);
            this.pnlRoulette.Name = "pnlRoulette";
            this.pnlRoulette.Size = new System.Drawing.Size(449, 172);
            this.pnlRoulette.TabIndex = 14;
            // 
            // picQuestion
            // 
            this.picQuestion.Image = global::LunchRoulette.Properties.Resources.question_sign;
            this.picQuestion.Location = new System.Drawing.Point(177, 33);
            this.picQuestion.Name = "picQuestion";
            this.picQuestion.Size = new System.Drawing.Size(100, 100);
            this.picQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQuestion.TabIndex = 0;
            this.picQuestion.TabStop = false;
            // 
            // RouletteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
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
            this.Name = "RouletteForm";
            this.Size = new System.Drawing.Size(686, 875);
            this.Load += new System.EventHandler(this.RouletteForm_Load);
            this.pnlRoulette.ResumeLayout(false);
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
    }
}
