namespace TableRecordEditor
{
    partial class TableRecordEditorForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.connectDBList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectTableList = new System.Windows.Forms.ListBox();
            this.searchConditionGridView = new System.Windows.Forms.DataGridView();
            this.empolyeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateUserDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimistDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleDataSet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editTableRecordGridView = new System.Windows.Forms.DataGridView();
            this.empolyeeIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.searchConditionGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editTableRecordGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // connectDBList
            // 
            this.connectDBList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.connectDBList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.connectDBList.FormattingEnabled = true;
            this.connectDBList.ItemHeight = 12;
            this.connectDBList.Items.AddRange(new object[] {
            "DB_Company_ABC",
            "DB_Company_XYZ"});
            this.connectDBList.Location = new System.Drawing.Point(12, 24);
            this.connectDBList.Name = "connectDBList";
            this.connectDBList.ScrollAlwaysVisible = true;
            this.connectDBList.Size = new System.Drawing.Size(174, 86);
            this.connectDBList.TabIndex = 0;
            this.connectDBList.SelectedIndexChanged += new System.EventHandler(this.ConnectDBList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "接続先DB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "対象Table";
            // 
            // selectTableList
            // 
            this.selectTableList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.selectTableList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.selectTableList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectTableList.FormattingEnabled = true;
            this.selectTableList.ItemHeight = 12;
            this.selectTableList.Items.AddRange(new object[] {
            "Empoyee",
            "DepartMent"});
            this.selectTableList.Location = new System.Drawing.Point(12, 137);
            this.selectTableList.Name = "selectTableList";
            this.selectTableList.ScrollAlwaysVisible = true;
            this.selectTableList.Size = new System.Drawing.Size(174, 302);
            this.selectTableList.TabIndex = 0;
            this.selectTableList.SelectedIndexChanged += new System.EventHandler(this.SelectTableList_SelectedIndexChanged);
            this.selectTableList.SelectedValueChanged += new System.EventHandler(this.SelectTableList_SelectedValueChanged);
            // 
            // searchConditionGridView
            // 
            this.searchConditionGridView.AllowUserToAddRows = false;
            this.searchConditionGridView.AllowUserToDeleteRows = false;
            this.searchConditionGridView.AllowUserToResizeRows = false;
            this.searchConditionGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchConditionGridView.AutoGenerateColumns = false;
            this.searchConditionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchConditionGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empolyeeIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.sexDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.departmentIDDataGridViewTextBoxColumn,
            this.lastUpdateDataGridViewTextBoxColumn1,
            this.lastUpdateUserDataGridViewTextBoxColumn1,
            this.optimistDataGridViewTextBoxColumn1});
            this.searchConditionGridView.DataMember = "Empolyee";
            this.searchConditionGridView.DataSource = this.sampleDataSet;
            this.searchConditionGridView.Location = new System.Drawing.Point(6, 18);
            this.searchConditionGridView.Name = "searchConditionGridView";
            this.searchConditionGridView.RowTemplate.Height = 21;
            this.searchConditionGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.searchConditionGridView.Size = new System.Drawing.Size(620, 83);
            this.searchConditionGridView.TabIndex = 2;
            // 
            // empolyeeIDDataGridViewTextBoxColumn
            // 
            this.empolyeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmpolyeeID";
            this.empolyeeIDDataGridViewTextBoxColumn.HeaderText = "EmpolyeeID";
            this.empolyeeIDDataGridViewTextBoxColumn.Name = "empolyeeIDDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // sexDataGridViewTextBoxColumn
            // 
            this.sexDataGridViewTextBoxColumn.DataPropertyName = "Sex";
            this.sexDataGridViewTextBoxColumn.HeaderText = "Sex";
            this.sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // departmentIDDataGridViewTextBoxColumn
            // 
            this.departmentIDDataGridViewTextBoxColumn.DataPropertyName = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn.HeaderText = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn.Name = "departmentIDDataGridViewTextBoxColumn";
            // 
            // lastUpdateDataGridViewTextBoxColumn1
            // 
            this.lastUpdateDataGridViewTextBoxColumn1.DataPropertyName = "LastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn1.HeaderText = "LastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn1.Name = "lastUpdateDataGridViewTextBoxColumn1";
            // 
            // lastUpdateUserDataGridViewTextBoxColumn1
            // 
            this.lastUpdateUserDataGridViewTextBoxColumn1.DataPropertyName = "LastUpdateUser";
            this.lastUpdateUserDataGridViewTextBoxColumn1.HeaderText = "LastUpdateUser";
            this.lastUpdateUserDataGridViewTextBoxColumn1.Name = "lastUpdateUserDataGridViewTextBoxColumn1";
            // 
            // optimistDataGridViewTextBoxColumn1
            // 
            this.optimistDataGridViewTextBoxColumn1.DataPropertyName = "Optimist";
            this.optimistDataGridViewTextBoxColumn1.HeaderText = "Optimist";
            this.optimistDataGridViewTextBoxColumn1.Name = "optimistDataGridViewTextBoxColumn1";
            // 
            // sampleDataSet
            // 
            this.sampleDataSet.DataSetName = "sampleDataSet";
            this.sampleDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.dataTable1.TableName = "Empolyee";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "EmpolyeeID";
            this.dataColumn1.ColumnName = "EmpolyeeID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Name";
            this.dataColumn2.ColumnName = "Name";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Sex";
            this.dataColumn3.ColumnName = "Sex";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Age";
            this.dataColumn4.ColumnName = "Age";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "DepartmentID";
            this.dataColumn5.ColumnName = "DepartmentID";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "LastUpdate";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "LastUpdateUser";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Optimist";
            this.dataColumn8.DataType = typeof(System.TimeSpan);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.searchConditionGridView);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(192, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 108);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索条件";
            // 
            // editTableRecordGridView
            // 
            this.editTableRecordGridView.AllowUserToAddRows = false;
            this.editTableRecordGridView.AllowUserToDeleteRows = false;
            this.editTableRecordGridView.AllowUserToResizeRows = false;
            this.editTableRecordGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editTableRecordGridView.AutoGenerateColumns = false;
            this.editTableRecordGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editTableRecordGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empolyeeIDDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.sexDataGridViewTextBoxColumn1,
            this.ageDataGridViewTextBoxColumn1,
            this.departmentIDDataGridViewTextBoxColumn1,
            this.lastUpdateDataGridViewTextBoxColumn,
            this.lastUpdateUserDataGridViewTextBoxColumn,
            this.optimistDataGridViewTextBoxColumn});
            this.editTableRecordGridView.DataMember = "Empolyee";
            this.editTableRecordGridView.DataSource = this.sampleDataSet;
            this.editTableRecordGridView.Location = new System.Drawing.Point(198, 164);
            this.editTableRecordGridView.Name = "editTableRecordGridView";
            this.editTableRecordGridView.RowTemplate.Height = 21;
            this.editTableRecordGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.editTableRecordGridView.Size = new System.Drawing.Size(620, 234);
            this.editTableRecordGridView.TabIndex = 2;
            // 
            // empolyeeIDDataGridViewTextBoxColumn1
            // 
            this.empolyeeIDDataGridViewTextBoxColumn1.DataPropertyName = "EmpolyeeID";
            this.empolyeeIDDataGridViewTextBoxColumn1.HeaderText = "EmpolyeeID";
            this.empolyeeIDDataGridViewTextBoxColumn1.Name = "empolyeeIDDataGridViewTextBoxColumn1";
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // sexDataGridViewTextBoxColumn1
            // 
            this.sexDataGridViewTextBoxColumn1.DataPropertyName = "Sex";
            this.sexDataGridViewTextBoxColumn1.HeaderText = "Sex";
            this.sexDataGridViewTextBoxColumn1.Name = "sexDataGridViewTextBoxColumn1";
            // 
            // ageDataGridViewTextBoxColumn1
            // 
            this.ageDataGridViewTextBoxColumn1.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn1.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn1.Name = "ageDataGridViewTextBoxColumn1";
            // 
            // departmentIDDataGridViewTextBoxColumn1
            // 
            this.departmentIDDataGridViewTextBoxColumn1.DataPropertyName = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn1.HeaderText = "DepartmentID";
            this.departmentIDDataGridViewTextBoxColumn1.Name = "departmentIDDataGridViewTextBoxColumn1";
            // 
            // lastUpdateDataGridViewTextBoxColumn
            // 
            this.lastUpdateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn.HeaderText = "LastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn.Name = "lastUpdateDataGridViewTextBoxColumn";
            // 
            // lastUpdateUserDataGridViewTextBoxColumn
            // 
            this.lastUpdateUserDataGridViewTextBoxColumn.DataPropertyName = "LastUpdateUser";
            this.lastUpdateUserDataGridViewTextBoxColumn.HeaderText = "LastUpdateUser";
            this.lastUpdateUserDataGridViewTextBoxColumn.Name = "lastUpdateUserDataGridViewTextBoxColumn";
            // 
            // optimistDataGridViewTextBoxColumn
            // 
            this.optimistDataGridViewTextBoxColumn.DataPropertyName = "Optimist";
            this.optimistDataGridViewTextBoxColumn.HeaderText = "Optimist";
            this.optimistDataGridViewTextBoxColumn.Name = "optimistDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(721, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "DB更新";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(198, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "行追加";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(301, 404);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "行削除";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(721, 122);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "検索";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // TableRecordEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(836, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.editTableRecordGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectTableList);
            this.Controls.Add(this.connectDBList);
            this.Name = "TableRecordEditorForm";
            this.Text = "TableRecordEditor";
            this.Load += new System.EventHandler(this.TableRecordEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchConditionGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editTableRecordGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox connectDBList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox selectTableList;
        private System.Windows.Forms.DataGridView searchConditionGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView editTableRecordGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Data.DataSet sampleDataSet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn empolyeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateUserDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimistDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn empolyeeIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimistDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
    }
}

