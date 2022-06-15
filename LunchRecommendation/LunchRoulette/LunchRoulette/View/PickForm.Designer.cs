namespace LunchRoulette.View
{
    partial class PickForm
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
            this.pnlPickInfo = new System.Windows.Forms.Panel();
            this.lblThanks = new System.Windows.Forms.Label();
            this.lblRestName = new System.Windows.Forms.Label();
            this.btnRestList = new System.Windows.Forms.Button();
            this.btnRoulette = new System.Windows.Forms.Button();
            this.pnlPickInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPickInfo
            // 
            this.pnlPickInfo.BackColor = System.Drawing.Color.Gray;
            this.pnlPickInfo.Controls.Add(this.lblThanks);
            this.pnlPickInfo.Controls.Add(this.lblRestName);
            this.pnlPickInfo.Location = new System.Drawing.Point(104, 281);
            this.pnlPickInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPickInfo.Name = "pnlPickInfo";
            this.pnlPickInfo.Size = new System.Drawing.Size(393, 138);
            this.pnlPickInfo.TabIndex = 15;
            // 
            // lblThanks
            // 
            this.lblThanks.AutoSize = true;
            this.lblThanks.Font = new System.Drawing.Font("나눔고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblThanks.Location = new System.Drawing.Point(136, 73);
            this.lblThanks.Name = "lblThanks";
            this.lblThanks.Size = new System.Drawing.Size(127, 28);
            this.lblThanks.TabIndex = 2;
            this.lblThanks.Text = "감사합니다";
            this.lblThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRestName
            // 
            this.lblRestName.AutoSize = true;
            this.lblRestName.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRestName.Location = new System.Drawing.Point(20, 37);
            this.lblRestName.Name = "lblRestName";
            this.lblRestName.Size = new System.Drawing.Size(135, 36);
            this.lblRestName.TabIndex = 1;
            this.lblRestName.Text = "식당이름";
            this.lblRestName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRestList
            // 
            this.btnRestList.Location = new System.Drawing.Point(200, 424);
            this.btnRestList.Name = "btnRestList";
            this.btnRestList.Size = new System.Drawing.Size(100, 23);
            this.btnRestList.TabIndex = 16;
            this.btnRestList.Text = "식당목록보기";
            this.btnRestList.UseVisualStyleBackColor = true;
            this.btnRestList.Click += new System.EventHandler(this.btnRestList_Click);
            // 
            // btnRoulette
            // 
            this.btnRoulette.Location = new System.Drawing.Point(306, 424);
            this.btnRoulette.Name = "btnRoulette";
            this.btnRoulette.Size = new System.Drawing.Size(100, 23);
            this.btnRoulette.TabIndex = 17;
            this.btnRoulette.Text = "더 추천 받기";
            this.btnRoulette.UseVisualStyleBackColor = true;
            this.btnRoulette.Click += new System.EventHandler(this.btnRoulette_Click);
            // 
            // PickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRoulette);
            this.Controls.Add(this.btnRestList);
            this.Controls.Add(this.pnlPickInfo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PickForm";
            this.Size = new System.Drawing.Size(600, 700);
            this.pnlPickInfo.ResumeLayout(false);
            this.pnlPickInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPickInfo;
        private System.Windows.Forms.Label lblThanks;
        private System.Windows.Forms.Label lblRestName;
        private System.Windows.Forms.Button btnRestList;
        private System.Windows.Forms.Button btnRoulette;
    }
}
