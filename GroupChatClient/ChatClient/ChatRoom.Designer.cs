namespace ChatClient
{
    partial class ChatRoom
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
            this.cboMessageNum = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboMessageNum
            // 
            this.cboMessageNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageNum.FormattingEnabled = true;
            this.cboMessageNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboMessageNum.Items.AddRange(new object[] {
            "All",
            "5",
            "10",
            "20",
            "50"});
            this.cboMessageNum.Location = new System.Drawing.Point(356, 9);
            this.cboMessageNum.Name = "cboMessageNum";
            this.cboMessageNum.Size = new System.Drawing.Size(121, 20);
            this.cboMessageNum.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(6, 38);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(471, 402);
            this.txtMessage.TabIndex = 6;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(6, 446);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(340, 103);
            this.messageTextBox.TabIndex = 7;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(356, 446);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(121, 103);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "전송";
            this.sendBtn.UseVisualStyleBackColor = true;
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cboMessageNum);
            this.Name = "ChatRoom";
            this.Text = "ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMessageNum;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button sendBtn;
    }
}