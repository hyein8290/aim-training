namespace Lunch.View
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
            this.btnCancelExcept = new System.Windows.Forms.Button();
            this.lblExceptRest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelExcept
            // 
            this.btnCancelExcept.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelExcept.FlatAppearance.BorderSize = 0;
            this.btnCancelExcept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelExcept.Font = new System.Drawing.Font("나눔고딕", 8F);
            this.btnCancelExcept.Location = new System.Drawing.Point(0, 0);
            this.btnCancelExcept.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelExcept.Name = "btnCancelExcept";
            this.btnCancelExcept.Size = new System.Drawing.Size(18, 23);
            this.btnCancelExcept.TabIndex = 3;
            this.btnCancelExcept.Text = "x";
            this.btnCancelExcept.UseVisualStyleBackColor = true;
            this.btnCancelExcept.Click += new System.EventHandler(this.btnCancelExcept_Click_1);
            // 
            // lblExceptRest
            // 
            this.lblExceptRest.AutoSize = true;
            this.lblExceptRest.Font = new System.Drawing.Font("나눔고딕", 11F);
            this.lblExceptRest.Location = new System.Drawing.Point(21, 3);
            this.lblExceptRest.Name = "lblExceptRest";
            this.lblExceptRest.Size = new System.Drawing.Size(50, 17);
            this.lblExceptRest.TabIndex = 4;
            this.lblExceptRest.Text = "label1";
            // 
            // ExceptRestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.lblExceptRest);
            this.Controls.Add(this.btnCancelExcept);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExceptRestControl";
            this.Size = new System.Drawing.Size(131, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelExcept;
        private System.Windows.Forms.Label lblExceptRest;
    }
}
