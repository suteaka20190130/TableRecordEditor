using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;


namespace TableRecordEditor
{
    public partial class TableRecordEditorForm : Form
    {
        DBAccessManger dBAccess;

        /// <summary>
        /// Constructor
        /// </summary>
        public TableRecordEditorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableRecordEditorForm_Load(object sender, EventArgs e)
        {
            // 画面初期化処理
            InitializeForm(InitLevel.connectDB);

            // 接続先DB取得
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                connectDBList.Items.Clear();
                foreach (ConnectionStringSettings cs in settings)
                {
                    connectDBList.Items.Add(cs.Name);
                }
            }
        }

        enum InitLevel
        {
            connectDB,
            selectTable,
            searchCondition,
            editTableRecord
        }

        private void InitializeForm(InitLevel lv)
        {
            switch (lv)
            {
                case InitLevel.connectDB:
                    connectDBList.Items.Clear();
                    selectTableList.Items.Clear();
                    InitializeGridView(searchConditionGridView, 2);
                    InitializeGridView(editTableRecordGridView, 0);
                    break;

                case InitLevel.selectTable:
                    selectTableList.Items.Clear();
                    InitializeGridView(searchConditionGridView, 2);
                    InitializeGridView(editTableRecordGridView, 0);
                    break;

                case InitLevel.searchCondition:
                    InitializeGridView(searchConditionGridView, 2);
                    InitializeGridView(editTableRecordGridView, 0);
                    break;

                case InitLevel.editTableRecord:
                    InitializeGridView(editTableRecordGridView, 0);
                    break;
            }

        }

        private void InitializeGridView(DataGridView dataGridView, int row)
        {
            // 初期化
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;

            //// サンプル列を設定
            //dataGridView.DataSource = sampleDataSet;
            //dataGridView.DataMember = "Empolyee";

            //// 空行追加
            //for (int i = 0; i < row; i++)
            //{
            //    // dataGridView.Rows.Add();
            //}
        }

        private void ConnectDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = ((ListBox)sender).SelectedItem as String;
            if (string.IsNullOrEmpty(dbName)) { return; }

            // コントロール初期化
            InitializeForm(InitLevel.selectTable);

            string connStr = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
            dBAccess = new DBAccessManger(connStr);

            if (dBAccess.CanOpen())
            {
                string[] tables = dBAccess.GetTableList().ToArray();
                if (tables.Length > 0)
                {
                    selectTableList.Items.AddRange(tables);
                }
                else
                {
                    MessageBox.Show(this, "テーブルが存在しません");
                }
            }
            else
            {
                MessageBox.Show(this, "接続失敗");
                connectDBList.ClearSelected();
            }

        }

        private void SelectTableList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectTableList_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
