namespace LunchRoulette.View
{
    partial class RestListForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cblCategory = new System.Windows.Forms.CheckedListBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvRestList = new System.Windows.Forms.DataGridView();
            this.vWRESTLISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRestList = new LunchRoulette.DsRestList();
            this.vWRESTLISTTableAdapter = new LunchRoulette.DsRestListTableAdapters.VWRESTLISTTableAdapter();
            this.cNTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lASTDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uSERNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cATEGORYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIGNATUREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rESTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRest = new System.Windows.Forms.Button();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWRESTLISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRestList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 128);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "카테고리";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cblCategory);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(136, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 34);
            this.panel1.TabIndex = 1;
            // 
            // cblCategory
            // 
            this.cblCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cblCategory.CheckOnClick = true;
            this.cblCategory.ColumnWidth = 60;
            this.cblCategory.Font = new System.Drawing.Font("굴림", 11F);
            this.cblCategory.Items.AddRange(new object[] {
            "한식",
            "중식",
            "일식",
            "양식",
            "기타"});
            this.cblCategory.Location = new System.Drawing.Point(62, 9);
            this.cblCategory.MultiColumn = true;
            this.cblCategory.Name = "cblCategory";
            this.cblCategory.Size = new System.Drawing.Size(366, 19);
            this.cblCategory.TabIndex = 5;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(0, 9);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(56, 19);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "전체";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "사용자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUserName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(136, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 34);
            this.panel2.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(0, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(145, 25);
            this.txtUserName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "마지막 선정 기간";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpEnd);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtpStart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(136, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 34);
            this.panel3.TabIndex = 5;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(175, 0);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(145, 25);
            this.dtpEnd.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "~";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(0, 0);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(145, 25);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.Value = new System.DateTime(2021, 6, 13, 0, 0, 0, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(263, 255);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvRestList
            // 
            this.dgvRestList.AutoGenerateColumns = false;
            this.dgvRestList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRestList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rESTNAMEDataGridViewTextBoxColumn,
            this.sIGNATUREDataGridViewTextBoxColumn,
            this.cATEGORYDataGridViewTextBoxColumn,
            this.uSERNAMEDataGridViewTextBoxColumn,
            this.lASTDATEDataGridViewTextBoxColumn,
            this.cNTDataGridViewTextBoxColumn});
            this.dgvRestList.DataSource = this.vWRESTLISTBindingSource;
            this.dgvRestList.Location = new System.Drawing.Point(20, 314);
            this.dgvRestList.Name = "dgvRestList";
            this.dgvRestList.RowTemplate.Height = 27;
            this.dgvRestList.Size = new System.Drawing.Size(564, 374);
            this.dgvRestList.TabIndex = 2;
            this.dgvRestList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRestList_CellMouseClick);
            // 
            // vWRESTLISTBindingSource
            // 
            this.vWRESTLISTBindingSource.DataMember = "VWRESTLIST";
            this.vWRESTLISTBindingSource.DataSource = this.dsRestList;
            // 
            // dsRestList
            // 
            this.dsRestList.DataSetName = "DsRestList";
            this.dsRestList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vWRESTLISTTableAdapter
            // 
            this.vWRESTLISTTableAdapter.ClearBeforeFill = true;
            // 
            // cNTDataGridViewTextBoxColumn
            // 
            this.cNTDataGridViewTextBoxColumn.DataPropertyName = "CNT";
            this.cNTDataGridViewTextBoxColumn.HeaderText = "CNT";
            this.cNTDataGridViewTextBoxColumn.Name = "cNTDataGridViewTextBoxColumn";
            // 
            // lASTDATEDataGridViewTextBoxColumn
            // 
            this.lASTDATEDataGridViewTextBoxColumn.DataPropertyName = "LASTDATE";
            this.lASTDATEDataGridViewTextBoxColumn.HeaderText = "LASTDATE";
            this.lASTDATEDataGridViewTextBoxColumn.Name = "lASTDATEDataGridViewTextBoxColumn";
            // 
            // uSERNAMEDataGridViewTextBoxColumn
            // 
            this.uSERNAMEDataGridViewTextBoxColumn.DataPropertyName = "USERNAME";
            this.uSERNAMEDataGridViewTextBoxColumn.HeaderText = "USERNAME";
            this.uSERNAMEDataGridViewTextBoxColumn.Name = "uSERNAMEDataGridViewTextBoxColumn";
            // 
            // cATEGORYDataGridViewTextBoxColumn
            // 
            this.cATEGORYDataGridViewTextBoxColumn.DataPropertyName = "CATEGORY";
            this.cATEGORYDataGridViewTextBoxColumn.HeaderText = "CATEGORY";
            this.cATEGORYDataGridViewTextBoxColumn.Name = "cATEGORYDataGridViewTextBoxColumn";
            // 
            // sIGNATUREDataGridViewTextBoxColumn
            // 
            this.sIGNATUREDataGridViewTextBoxColumn.DataPropertyName = "SIGNATURE";
            this.sIGNATUREDataGridViewTextBoxColumn.HeaderText = "SIGNATURE";
            this.sIGNATUREDataGridViewTextBoxColumn.Name = "sIGNATUREDataGridViewTextBoxColumn";
            // 
            // rESTNAMEDataGridViewTextBoxColumn
            // 
            this.rESTNAMEDataGridViewTextBoxColumn.DataPropertyName = "RESTNAME";
            this.rESTNAMEDataGridViewTextBoxColumn.HeaderText = "RESTNAME";
            this.rESTNAMEDataGridViewTextBoxColumn.Name = "rESTNAMEDataGridViewTextBoxColumn";
            // 
            // btnAddRest
            // 
            this.btnAddRest.Location = new System.Drawing.Point(509, 285);
            this.btnAddRest.Name = "btnAddRest";
            this.btnAddRest.Size = new System.Drawing.Size(75, 23);
            this.btnAddRest.TabIndex = 3;
            this.btnAddRest.Text = "추가";
            this.btnAddRest.UseVisualStyleBackColor = true;
            this.btnAddRest.Click += new System.EventHandler(this.btnAddRest_Click);
            // 
            // picLogout
            // 
            this.picLogout.Location = new System.Drawing.Point(534, 12);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(50, 50);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogout.TabIndex = 4;
            this.picLogout.TabStop = false;
            // 
            // picHome
            // 
            this.picHome.Location = new System.Drawing.Point(478, 12);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(50, 50);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHome.TabIndex = 5;
            this.picHome.TabStop = false;
            // 
            // RestListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.picLogout);
            this.Controls.Add(this.btnAddRest);
            this.Controls.Add(this.dgvRestList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RestListForm";
            this.Size = new System.Drawing.Size(600, 700);
            this.Load += new System.EventHandler(this.RestListForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vWRESTLISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRestList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckedListBox cblCategory;
        private System.Windows.Forms.DataGridView dgvRestList;
        private System.Windows.Forms.BindingSource vWRESTLISTBindingSource;
        private DsRestList dsRestList;
        private DsRestListTableAdapters.VWRESTLISTTableAdapter vWRESTLISTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rESTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIGNATUREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cATEGORYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lASTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNTDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAddRest;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.PictureBox picHome;
    }
}
