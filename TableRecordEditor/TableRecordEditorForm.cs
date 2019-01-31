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
using System.Data.SqlClient;

namespace TableRecordEditor
{
    public partial class TableRecordEditorForm : Form
    {
        DBAccessManger dBAccess;

        public string SelectedDB { get; set; }
        public string SelectedTable { get; set; }

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
            InitializeForm(TargetLevel.connectDB);

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

        /// <summary>
        /// 処理レベル
        /// </summary>
        enum TargetLevel
        {
            connectDB,
            selectTable,
            searchCondition,
            editTableRecord
        }

        /// <summary>
        /// 各コントロールの初期化処理
        /// </summary>
        /// <param name="lv"></param>
        private void InitializeForm(TargetLevel lv)
        {
            switch (lv)
            {
                case TargetLevel.connectDB:
                    SelectedDB = string.Empty;
                    connectDBList.Items.Clear();

                    SelectedTable = string.Empty;
                    selectTableList.Items.Clear();

                    InitializeGridView(searchConditionGridView, 2);
                    InitializeGridView(editTableRecordGridView, 0);
                    break;

                case TargetLevel.selectTable:
                    SelectedTable = string.Empty;
                    selectTableList.Items.Clear();

                    InitializeGridView(searchConditionGridView, 2);
                    InitializeGridView(editTableRecordGridView, 0);
                    break;

                case TargetLevel.searchCondition:
                    InitializeGridView(searchConditionGridView, 2);
                    InitializeGridView(editTableRecordGridView, 0);
                    break;

                case TargetLevel.editTableRecord:
                    InitializeGridView(editTableRecordGridView, 0);
                    break;
            }

        }

        /// <summary>
        /// GridViewの初期化処理
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="row"></param>
        private void InitializeGridView(DataGridView dataGridView, int row)
        {
            // 初期化
            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;
        }

        /// <summary>
        /// 接続先DB選択時に所有するテーブル一覧を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectDBList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dbName = ((ListBox)sender).SelectedItem as String;
            if (string.IsNullOrEmpty(dbName) || dbName == SelectedDB) { return; }

            SelectedDB = dbName;

            // コントロール初期化
            InitializeForm(TargetLevel.selectTable);

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

        /// <summary>
        /// テーブル一覧選択時に所有するカラム一覧を検索条件グリッドに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tableName = ((ListBox)sender).SelectedItem as String;
            if (string.IsNullOrEmpty(tableName) || tableName == SelectedTable) { return; }

            SelectedTable = tableName;

            InitializeForm(TargetLevel.searchCondition);

            DataTable dt = dBAccess.GetColumnList(tableName);
            DataTable searchConditionDt = new DataTable();

            foreach (DataRow row in dt.Rows)
            {
                searchConditionDt.Columns.Add(new DataColumn(row["name"].ToString()));
            }
            // 値入力用の1行追加
            searchConditionDt.Rows.Add(searchConditionDt.NewRow());

            searchConditionGridView.AutoGenerateColumns = true;
            searchConditionGridView.DataSource = searchConditionDt;
        }

        /// <summary>
        /// 検索ボタン押下時に、検索条件に従った検索結果を編集グリッドに表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!CanExecute(TargetLevel.searchCondition)) { return; }

            InitializeForm(TargetLevel.editTableRecord);

            DataTable searchConditionDt = searchConditionGridView.DataSource as DataTable;
            DataTable dt = dBAccess.SelectTableRecord(SelectedTable, searchConditionDt);

            // 値入力用の1行追加
            editTableRecordGridView.AutoGenerateColumns = true;
            editTableRecordGridView.DataSource = dt;
        }

        /// <summary>
        /// レベルに応じて実行可能であるかチェックする
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        private bool CanExecute(TargetLevel lv)
        {
            switch (lv)
            {
                case TargetLevel.connectDB:
                    return true;

                case TargetLevel.selectTable:
                    return true;

                case TargetLevel.searchCondition:
                    if (string.IsNullOrEmpty(SelectedDB)
                     || string.IsNullOrEmpty(SelectedTable)
                     || searchConditionGridView.DataSource == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case TargetLevel.editTableRecord:
                    if (string.IsNullOrEmpty(SelectedDB)
                     || string.IsNullOrEmpty(SelectedTable)
                     || searchConditionGridView.DataSource == null
                     || editTableRecordGridView.DataSource == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return true;
            }
        }

        /// <summary>
        /// 編集グリッドに行追加する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateRowButton_Click(object sender, EventArgs e)
        {
            // 編集グリッドが存在すれば処理続行
            if (!CanExecute(TargetLevel.editTableRecord)) { return; }

            // GridViewダイレクト編集は出来ないため、いったんDataTableに落として行追加
            DataTable dt = editTableRecordGridView.DataSource as DataTable;
            dt.Rows.Add(dt.NewRow());

            editTableRecordGridView.DataSource = dt;
        }

        /// <summary>
        /// 編集グリッドで選択している行を削除する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            // 編集グリッドが存在すれば処理続行
            if (!CanExecute(TargetLevel.editTableRecord)) { return; }

            // 選択行を取得して行削除
            int deleteIndex = editTableRecordGridView.CurrentRow.Index;
            editTableRecordGridView.Rows.RemoveAt(deleteIndex);
        }

        private void CommitDB_Click(object sender, EventArgs e)
        {
            // 編集グリッドが存在すれば処理続行
            if (!CanExecute(TargetLevel.editTableRecord)) { return; }

            // 変更した行が無い場合処理終了
            DataTable editRecordDt = editTableRecordGridView.DataSource as DataTable;
            int notModifyRowCnt = editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.Unchanged).Count();
            if (editRecordDt.Rows.Count == notModifyRowCnt) { return; }

            // DB更新処理
            try
            {
                dBAccess.sqlConn.Open();
                // トランザクション開始
                SqlTransaction tran = dBAccess.sqlConn.BeginTransaction();

                // 1) 削除処理
                foreach (DataRow row in editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.Deleted))
                {
                    dBAccess.DeleteRecord(SelectedTable, row);
                }

                // 2) 更新処理
                foreach (DataRow row in editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.ModifiedCurrent))
                {
                    dBAccess.UpdateRecord(SelectedTable, row);
                }

                // 3) 追加処理
                foreach (DataRow row in editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.Added))
                {
                    dBAccess.InsertRecord(SelectedTable, row);
                }

                // DB反映
                tran.Commit();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
