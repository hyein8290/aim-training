namespace LunchRoulette.View
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
            ((System.ComponentModel.ISupportInitialize)(this.picRoulette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRestList)).BeginInit();
            this.SuspendLayout();
            // 
            // picRoulette
            // 
            this.picRoulette.Image = global::LunchRoulette.Properties.Resources.roulette;
            this.picRoulette.Location = new System.Drawing.Point(410, 275);
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
            this.picRestList.Location = new System.Drawing.Point(180, 275);
            this.picRestList.Name = "picRestList";
            this.picRestList.Size = new System.Drawing.Size(150, 150);
            this.picRestList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRestList.TabIndex = 2;
            this.picRestList.TabStop = false;
            this.picRestList.Click += new System.EventHandler(this.picRestList_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picRoulette);
            this.Controls.Add(this.picRestList);
            this.Name = "MenuForm";
            this.Size = new System.Drawing.Size(686, 875);
            ((System.ComponentModel.ISupportInitialize)(this.picRoulette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRestList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picRestList;
        private System.Windows.Forms.PictureBox picRoulette;
    }
}
