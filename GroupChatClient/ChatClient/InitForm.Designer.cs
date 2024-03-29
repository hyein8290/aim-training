﻿namespace ChatClient
{
    partial class InitForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnectForm = new System.Windows.Forms.Button();
            this.setNameBtn = new System.Windows.Forms.Button();
            this.chatBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connectState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnConnectForm, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.setNameBtn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chatBtn, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConnectForm
            // 
            this.btnConnectForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConnectForm.Location = new System.Drawing.Point(150, 217);
            this.btnConnectForm.Name = "btnConnectForm";
            this.btnConnectForm.Size = new System.Drawing.Size(150, 30);
            this.btnConnectForm.TabIndex = 1;
            this.btnConnectForm.Text = "서버 연결";
            this.btnConnectForm.UseVisualStyleBackColor = true;
            this.btnConnectForm.Click += new System.EventHandler(this.btnConnectForm_Click);
            // 
            // setNameBtn
            // 
            this.setNameBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.setNameBtn.Location = new System.Drawing.Point(150, 316);
            this.setNameBtn.Name = "setNameBtn";
            this.setNameBtn.Size = new System.Drawing.Size(150, 30);
            this.setNameBtn.TabIndex = 2;
            this.setNameBtn.Text = "이름 설정";
            this.setNameBtn.UseVisualStyleBackColor = true;
            this.setNameBtn.Click += new System.EventHandler(this.setNameBtn_Click);
            // 
            // chatBtn
            // 
            this.chatBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chatBtn.Location = new System.Drawing.Point(150, 415);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(150, 30);
            this.chatBtn.TabIndex = 3;
            this.chatBtn.Text = "채팅";
            this.chatBtn.UseVisualStyleBackColor = true;
            this.chatBtn.Click += new System.EventHandler(this.chatBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.connectState);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 27);
            this.panel1.TabIndex = 4;
            // 
            // connectState
            // 
            this.connectState.BackColor = System.Drawing.SystemColors.Control;
            this.connectState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.connectState.Enabled = false;
            this.connectState.Location = new System.Drawing.Point(254, 8);
            this.connectState.Name = "connectState";
            this.connectState.ReadOnly = true;
            this.connectState.Size = new System.Drawing.Size(30, 14);
            this.connectState.TabIndex = 1;
            this.connectState.Text = "해제";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "서버 연결 상태:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(444, 144);
            this.panel3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 48F);
            this.label1.Location = new System.Drawing.Point(84, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chatting";
            // 
            // InitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InitForm";
            this.Size = new System.Drawing.Size(450, 500);
            this.Load += new System.EventHandler(this.InitForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnConnectForm;
        private System.Windows.Forms.Button setNameBtn;
        private System.Windows.Forms.Button chatBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox connectState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
    }
}
