namespace ChatClient
{
    partial class ChatForm
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
            this.cboMessageNum = new System.Windows.Forms.ComboBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboMessageNum
            // 
            this.cboMessageNum.FormattingEnabled = true;
            this.cboMessageNum.Items.AddRange(new object[] {
            "All",
            "5",
            "10",
            "20",
            "50"});
            this.cboMessageNum.Location = new System.Drawing.Point(326, 5);
            this.cboMessageNum.Name = "cboMessageNum";
            this.cboMessageNum.Size = new System.Drawing.Size(121, 20);
            this.cboMessageNum.TabIndex = 1;
            this.cboMessageNum.Text = "All";
            this.cboMessageNum.SelectedIndexChanged += new System.EventHandler(this.cboMessageNum_SelectedIndexChanged);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(6, 384);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(340, 103);
            this.messageTextBox.TabIndex = 3;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(352, 384);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(95, 103);
            this.sendBtn.TabIndex = 4;
            this.sendBtn.Text = "전송";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 31);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(441, 347);
            this.txtMessage.TabIndex = 5;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.cboMessageNum);
            this.Name = "ChatForm";
            this.Size = new System.Drawing.Size(450, 500);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboMessageNum;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox txtMessage;
    }
}
