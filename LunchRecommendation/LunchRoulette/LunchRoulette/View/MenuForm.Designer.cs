﻿namespace LunchRoulette.View
{
    partial class MenuForm
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
            this.picRoulette = new System.Windows.Forms.PictureBox();
            this.picRestList = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picRoulette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRestList)).BeginInit();
            this.SuspendLayout();
            // 
            // picRoulette
            // 
            this.picRoulette.Image = global::LunchRoulette.Properties.Resources.roulette;
            this.picRoulette.Location = new System.Drawing.Point(330, 240);
            this.picRoulette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picRoulette.Name = "picRoulette";
            this.picRoulette.Size = new System.Drawing.Size(150, 150);
            this.picRoulette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRoulette.TabIndex = 3;
            this.picRoulette.TabStop = false;
            this.picRoulette.Click += new System.EventHandler(this.picRoulette_Click);
            // 
            // picRestList
            // 
            this.picRestList.Image = global::LunchRoulette.Properties.Resources.restaurant;
            this.picRestList.Location = new System.Drawing.Point(120, 240);
            this.picRestList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picRestList.Name = "picRestList";
            this.picRestList.Size = new System.Drawing.Size(150, 150);
            this.picRestList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRestList.TabIndex = 2;
            this.picRestList.TabStop = false;
            this.picRestList.Click += new System.EventHandler(this.picRestList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "식당목록";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "식당추천";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔고딕", 50F);
            this.label1.Location = new System.Drawing.Point(0, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 141);
            this.label1.TabIndex = 7;
            this.label1.Text = "오늘 뭐 먹지?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picRoulette);
            this.Controls.Add(this.picRestList);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuForm";
            this.Size = new System.Drawing.Size(600, 700);
            ((System.ComponentModel.ISupportInitialize)(this.picRoulette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRestList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picRestList;
        private System.Windows.Forms.PictureBox picRoulette;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
