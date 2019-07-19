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
using System.Text.RegularExpressions;

namespace TableRecordEditor
{
    public partial class TableRecordEditorForm : Form
    {
        DBAccessManger dBAccess;

        public string SelectedDB { get; set; }
        public string SelectedTable { get; set; }
        private DataTable SchemaDt;

        /// <summary>
        /// Constructor
        /// </summary>
        public TableRecordEditorForm()
        {
            InitializeComponent();
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
            dBAccess = new DBAccessManger(connStr, textBox1);

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

            try
            {

                DataTable dt = dBAccess.SelectTableRecord(SelectedTable, searchConditionDt, ref SchemaDt);

                // 値入力用の1行追加
                editTableRecordGridView.AutoGenerateColumns = true;
                editTableRecordGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                textBox1.Text += string.Format("\r\n//_/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/_//\r\n");
                textBox1.Text += string.Format("例外発生】\r\n{0}\r\n{1}\r\n{2}", ex.Message, ex.Source, ex.StackTrace);
                textBox1.Text += string.Format("\r\n//_/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/_//\r\n");
            }
        }

        /// <summary>
        /// レベルに応じて実行可能であるかチェックする
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        private bool CanExecute(TargetLevel lv)
        {
            bool retCd = true;
            switch (lv)
            {
                //case TargetLevel.connectDB:
                //break;
                //case TargetLevel.selectTable:
                //break;
                case TargetLevel.searchCondition:
                    if (string.IsNullOrEmpty(SelectedDB)
                     || string.IsNullOrEmpty(SelectedTable)
                     || searchConditionGridView.DataSource == null)
                    {
                        retCd = false;
                    }
                    break;

                case TargetLevel.editTableRecord:
                    if (string.IsNullOrEmpty(SelectedDB)
                     || string.IsNullOrEmpty(SelectedTable)
                     || searchConditionGridView.DataSource == null
                     || editTableRecordGridView.DataSource == null)
                    {
                        retCd = false;
                    }
                    break;
            }
            return retCd;
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
            // 編集グリッド、および選択行が存在すれば処理続行
            if (!CanExecute(TargetLevel.editTableRecord) || editTableRecordGridView.CurrentRow == null) { return; }

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

            textBox1.Text = String.Empty;
            // DB更新処理
            try
            {
                // トランザクション開始
                dBAccess.BeginTransaction();

                // 1) 削除処理
                foreach (DataRow row in editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.Deleted))
                {
                    dBAccess.DeleteRecord(SelectedTable, row, ref SchemaDt);
                }

                // 2) 更新処理
                foreach (DataRow row in editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.ModifiedCurrent))
                {
                    dBAccess.UpdateRecord(SelectedTable, row, ref SchemaDt);
                }

                // 3) 追加処理
                foreach (DataRow row in editRecordDt.Select(string.Empty, string.Empty, DataViewRowState.Added))
                {
                    dBAccess.InsertRecord(SelectedTable, row, ref SchemaDt);
                }

                // Commit
                dBAccess.CommitTransaction();
                // 編集グリッドのDataTableの変更状況をリセット
                editRecordDt.AcceptChanges();
            }
            catch (Exception ex)
            {
                textBox1.Text += string.Format("\r\n//_/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/_//\r\n");
                textBox1.Text += string.Format("例外発生】\r\n{0}\r\n{1}\r\n{2}", ex.Message, ex.Source, ex.StackTrace);
                textBox1.Text += string.Format("\r\n//_/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/__/_/_//\r\n");

                // Rollback
                dBAccess.RollBackTransaction();
            }
            // CommitTransaction, RollBackTransaction内でCloseするため不要
            //finally
            //{
            //    dBAccess.sqlConn.Close();
            //}

        }

        private void editTableRecordGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                List<int> dgvR = new List<int>();
                List<int> dgvC = new List<int>();
                // 選択されているセルごとに貼り付け
                foreach (DataGridViewCell c in editTableRecordGridView.SelectedCells)
                {
                    dgvR.Add(c.RowIndex);
                    dgvC.Add(c.ColumnIndex);
                }
                int iRMin = dgvR.Min();
                int iRMax = editTableRecordGridView.Rows.Count;
                int iCMin = dgvC.Min();
                int iCMax = editTableRecordGridView.Columns.Count;


                List<List<string>> clipStr = (Clipboard.GetText().Split(new string[] { "\r\n" }, StringSplitOptions.None))
                                             .Select(l => l.Split(new string[] { "\t" }, StringSplitOptions.None).ToList()).ToList();

                if (clipStr.Count == 1 && clipStr[0].Count == 1)
                {
                    foreach (DataGridViewCell c in editTableRecordGridView.SelectedCells)
                    {
                        int iR = c.RowIndex;
                        int iC = c.ColumnIndex;

                        // 選択セルに反映
                        this.editTableRecordGridView.Rows[iR].Cells[iC].Value = clipStr[0][0];
                    }
                }
                else
                {
                    for (int y = 0, iR = iRMin; y < clipStr.Count && iR < iRMax; y++, iR++)
                    {
                        for (int x = 0, iC = iCMin; x < clipStr[0].Count && iC < iCMax; x++, iC++)
                        {
                            // 選択セルに反映
                            if (String.IsNullOrEmpty(clipStr[y][x]))
                            {
                                this.editTableRecordGridView.Rows[iR].Cells[iC].Value = DBNull.Value;
                            }
                            else
                            {
                                this.editTableRecordGridView.Rows[iR].Cells[iC].Value = clipStr[y][x];
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell c in editTableRecordGridView.SelectedCells)
                {
                    int iR = c.RowIndex;
                    int iC = c.ColumnIndex;

                    // 選択セルに反映
                    this.editTableRecordGridView.Rows[iR].Cells[iC].Value = System.DBNull.Value;
                }
            }
        }

        private void editTableRecordGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (SchemaDt == null)
            {
                return;
            }
            foreach (DataColumn col in SchemaDt.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {
                    editTableRecordGridView.Columns[col.ColumnName].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";
                }
            }
        }

        private void editTableRecordGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                List<List<string>> clipStr = (Clipboard.GetText().Split(new string[] { "\r\n" }, StringSplitOptions.None))
                             .Select(l => l.Split(new string[] { "\t" }, StringSplitOptions.None).ToList()).ToList();

                // Gridの列数より多い場合、左端の列のデータ(行の枠部分）は削除する
                if (clipStr[0].Count > editTableRecordGridView.Columns.Count)
                {
                    List<string> clipStrRow = Clipboard.GetText().Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

                    for (int i = 0; i < clipStrRow.Count; i++)
                    {
                        clipStrRow[i] = clipStrRow[i].Substring(1, clipStrRow[i].Length - 1);
                    }

                    Clipboard.SetText(String.Join("\r\n", clipStrRow));
                }
            }
        }
    }
}
