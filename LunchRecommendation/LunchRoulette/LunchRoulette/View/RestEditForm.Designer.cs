namespace LunchRoulette.View
{
    partial class RestEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoCategory2 = new System.Windows.Forms.RadioButton();
            this.rdoCategory1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRestName = new System.Windows.Forms.TextBox();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCategory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRestName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSignature, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(50, 194);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 200);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "카테고리";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCategory
            // 
            this.pnlCategory.Controls.Add(this.radioButton3);
            this.pnlCategory.Controls.Add(this.radioButton2);
            this.pnlCategory.Controls.Add(this.radioButton1);
            this.pnlCategory.Controls.Add(this.rdoCategory2);
            this.pnlCategory.Controls.Add(this.rdoCategory1);
            this.pnlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategory.Location = new System.Drawing.Point(153, 3);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(344, 44);
            this.pnlCategory.TabIndex = 1;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton3.Location = new System.Drawing.Point(188, 0);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 44);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "기타";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton2.Location = new System.Drawing.Point(141, 0);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 44);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "양식";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.radioButton1.Location = new System.Drawing.Point(94, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 44);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "일식";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoCategory2
            // 
            this.rdoCategory2.AutoSize = true;
            this.rdoCategory2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCategory2.Location = new System.Drawing.Point(47, 0);
            this.rdoCategory2.Name = "rdoCategory2";
            this.rdoCategory2.Size = new System.Drawing.Size(47, 44);
            this.rdoCategory2.TabIndex = 1;
            this.rdoCategory2.TabStop = true;
            this.rdoCategory2.Text = "중식";
            this.rdoCategory2.UseVisualStyleBackColor = true;
            // 
            // rdoCategory1
            // 
            this.rdoCategory1.AutoSize = true;
            this.rdoCategory1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rdoCategory1.Location = new System.Drawing.Point(0, 0);
            this.rdoCategory1.Name = "rdoCategory1";
            this.rdoCategory1.Size = new System.Drawing.Size(47, 44);
            this.rdoCategory1.TabIndex = 0;
            this.rdoCategory1.TabStop = true;
            this.rdoCategory1.Text = "한식";
            this.rdoCategory1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 50);
            this.label2.TabIndex = 2;
            this.label2.Text = "식당이름";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "시그니처 메뉴";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRestName
            // 
            this.txtRestName.Location = new System.Drawing.Point(153, 103);
            this.txtRestName.Name = "txtRestName";
            this.txtRestName.Size = new System.Drawing.Size(300, 21);
            this.txtRestName.TabIndex = 3;
            // 
            // txtSignature
            // 
            this.txtSignature.Location = new System.Drawing.Point(153, 53);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(300, 21);
            this.txtSignature.TabIndex = 5;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 44);
            this.panel1.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(262, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(181, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RestEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RestEditForm";
            this.Size = new System.Drawing.Size(600, 700);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlCategory.ResumeLayout(false);
            this.pnlCategory.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoCategory2;
        private System.Windows.Forms.RadioButton rdoCategory1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRestName;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}
