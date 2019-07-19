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
            this.列1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleDataSet = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editTableRecordGridView = new System.Windows.Forms.DataGridView();
            this.列1DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列2DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列3DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.列4DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commitDB = new System.Windows.Forms.Button();
            this.createRowButton = new System.Windows.Forms.Button();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.列1DataGridViewTextBoxColumn,
            this.列2DataGridViewTextBoxColumn,
            this.列3DataGridViewTextBoxColumn,
            this.列4DataGridViewTextBoxColumn});
            this.searchConditionGridView.DataMember = "SampleTable";
            this.searchConditionGridView.DataSource = this.sampleDataSet;
            this.searchConditionGridView.Location = new System.Drawing.Point(6, 18);
            this.searchConditionGridView.Name = "searchConditionGridView";
            this.searchConditionGridView.RowTemplate.Height = 21;
            this.searchConditionGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.searchConditionGridView.Size = new System.Drawing.Size(620, 83);
            this.searchConditionGridView.TabIndex = 2;
            // 
            // 列1DataGridViewTextBoxColumn
            // 
            this.列1DataGridViewTextBoxColumn.DataPropertyName = "列1";
            this.列1DataGridViewTextBoxColumn.HeaderText = "列1";
            this.列1DataGridViewTextBoxColumn.Name = "列1DataGridViewTextBoxColumn";
            // 
            // 列2DataGridViewTextBoxColumn
            // 
            this.列2DataGridViewTextBoxColumn.DataPropertyName = "列2";
            this.列2DataGridViewTextBoxColumn.HeaderText = "列2";
            this.列2DataGridViewTextBoxColumn.Name = "列2DataGridViewTextBoxColumn";
            // 
            // 列3DataGridViewTextBoxColumn
            // 
            this.列3DataGridViewTextBoxColumn.DataPropertyName = "列3";
            this.列3DataGridViewTextBoxColumn.HeaderText = "列3";
            this.列3DataGridViewTextBoxColumn.Name = "列3DataGridViewTextBoxColumn";
            // 
            // 列4DataGridViewTextBoxColumn
            // 
            this.列4DataGridViewTextBoxColumn.DataPropertyName = "列4";
            this.列4DataGridViewTextBoxColumn.HeaderText = "列4";
            this.列4DataGridViewTextBoxColumn.Name = "列4DataGridViewTextBoxColumn";
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
            this.dataColumn8,
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTable1.TableName = "SampleTable";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "列1";
            this.dataColumn8.DataType = typeof(System.TimeSpan);
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "列2";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "列3";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "列4";
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
            this.列1DataGridViewTextBoxColumn1,
            this.列2DataGridViewTextBoxColumn1,
            this.列3DataGridViewTextBoxColumn1,
            this.列4DataGridViewTextBoxColumn1});
            this.editTableRecordGridView.DataMember = "SampleTable";
            this.editTableRecordGridView.DataSource = this.sampleDataSet;
            this.editTableRecordGridView.Location = new System.Drawing.Point(198, 164);
            this.editTableRecordGridView.Name = "editTableRecordGridView";
            this.editTableRecordGridView.RowTemplate.Height = 21;
            this.editTableRecordGridView.Size = new System.Drawing.Size(620, 222);
            this.editTableRecordGridView.TabIndex = 2;
            this.editTableRecordGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.editTableRecordGridView_DataBindingComplete);
            this.editTableRecordGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editTableRecordGridView_KeyDown);
            this.editTableRecordGridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.editTableRecordGridView_KeyUp);
            // 
            // 列1DataGridViewTextBoxColumn1
            // 
            this.列1DataGridViewTextBoxColumn1.DataPropertyName = "列1";
            this.列1DataGridViewTextBoxColumn1.HeaderText = "列1";
            this.列1DataGridViewTextBoxColumn1.Name = "列1DataGridViewTextBoxColumn1";
            // 
            // 列2DataGridViewTextBoxColumn1
            // 
            this.列2DataGridViewTextBoxColumn1.DataPropertyName = "列2";
            this.列2DataGridViewTextBoxColumn1.HeaderText = "列2";
            this.列2DataGridViewTextBoxColumn1.Name = "列2DataGridViewTextBoxColumn1";
            // 
            // 列3DataGridViewTextBoxColumn1
            // 
            this.列3DataGridViewTextBoxColumn1.DataPropertyName = "列3";
            this.列3DataGridViewTextBoxColumn1.HeaderText = "列3";
            this.列3DataGridViewTextBoxColumn1.Name = "列3DataGridViewTextBoxColumn1";
            // 
            // 列4DataGridViewTextBoxColumn1
            // 
            this.列4DataGridViewTextBoxColumn1.DataPropertyName = "列4";
            this.列4DataGridViewTextBoxColumn1.HeaderText = "列4";
            this.列4DataGridViewTextBoxColumn1.Name = "列4DataGridViewTextBoxColumn1";
            // 
            // commitDB
            // 
            this.commitDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.commitDB.Location = new System.Drawing.Point(721, 405);
            this.commitDB.Name = "commitDB";
            this.commitDB.Size = new System.Drawing.Size(97, 34);
            this.commitDB.TabIndex = 4;
            this.commitDB.Text = "DB更新";
            this.commitDB.UseVisualStyleBackColor = true;
            this.commitDB.Click += new System.EventHandler(this.CommitDB_Click);
            // 
            // createRowButton
            // 
            this.createRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createRowButton.Location = new System.Drawing.Point(198, 405);
            this.createRowButton.Name = "createRowButton";
            this.createRowButton.Size = new System.Drawing.Size(97, 34);
            this.createRowButton.TabIndex = 4;
            this.createRowButton.Text = "行追加";
            this.createRowButton.UseVisualStyleBackColor = true;
            this.createRowButton.Click += new System.EventHandler(this.CreateRowButton_Click);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteRowButton.Location = new System.Drawing.Point(301, 405);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(97, 34);
            this.deleteRowButton.TabIndex = 4;
            this.deleteRowButton.Text = "行削除";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.DeleteRowButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.Location = new System.Drawing.Point(721, 123);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(97, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "検索";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "実行結果";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 473);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(806, 168);
            this.textBox1.TabIndex = 5;
            // 
            // TableRecordEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(836, 646);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.deleteRowButton);
            this.Controls.Add(this.createRowButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.commitDB);
            this.Controls.Add(this.editTableRecordGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Button commitDB;
        private System.Windows.Forms.Button createRowButton;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Data.DataSet sampleDataSet;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.Button searchButton;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列1DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列2DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列3DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 列4DataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

