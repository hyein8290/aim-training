namespace LunchRoulette.View
{
    partial class ExceptRestControl
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
            this.lblExceptRest = new System.Windows.Forms.Label();
            this.btnCancelExcept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblExceptRest
            // 
            this.lblExceptRest.AutoSize = true;
            this.lblExceptRest.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExceptRest.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.lblExceptRest.Location = new System.Drawing.Point(18, 0);
            this.lblExceptRest.Name = "lblExceptRest";
            this.lblExceptRest.Size = new System.Drawing.Size(55, 19);
            this.lblExceptRest.TabIndex = 3;
            this.lblExceptRest.Text = "label1";
            // 
            // btnCancelExcept
            // 
            this.btnCancelExcept.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelExcept.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.btnCancelExcept.Location = new System.Drawing.Point(0, 0);
            this.btnCancelExcept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelExcept.Name = "btnCancelExcept";
            this.btnCancelExcept.Size = new System.Drawing.Size(18, 20);
            this.btnCancelExcept.TabIndex = 2;
            this.btnCancelExcept.Text = "x";
            this.btnCancelExcept.UseVisualStyleBackColor = true;
            this.btnCancelExcept.Click += new System.EventHandler(this.btnCancelExcept_Click);
            // 
            // ExceptRestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.lblExceptRest);
            this.Controls.Add(this.btnCancelExcept);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExceptRestControl";
            this.Size = new System.Drawing.Size(131, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExceptRest;
        private System.Windows.Forms.Button btnCancelExcept;
    }
}
