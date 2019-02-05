using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace TableRecordEditor
{
    class DBAccessManger
    {
        #region 使用SQL
        /// <summary>
        /// テーブル一覧取得
        /// </summary>
        const string SQL_SELECT_TBL =
@"
SELECT sch.name +'.'+ tbl.name AS objectName 
  FROM sys.tables tbl 
 INNER JOIN sys.schemas sch 
         ON tbl.schema_id = sch.schema_id 
 WHERE tbl.is_ms_shipped = 0
";

        /// <summary>
        /// テーブルのカラム一覧取得
        /// </summary>
        const string SQL_SELECT_COLUMNS =
@"
SELECT name, column_id, system_type_id, user_type_id
FROM   sys.columns
WHERE  object_id = 
(SELECT object_id 
   FROM sys.objects 
  WHERE schema_id = SCHEMA_ID(@schema_name) 
    AND object_id = OBJECT_ID(@table_name)
)
AND system_type_id <> 189
";
        #endregion

        public SqlConnection sqlConn;
        public SqlCommand sqlCmd;
        public TextBox debugTextBox;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sqlConnStr"></param>
        public DBAccessManger(string sqlConnStr, TextBox textBox)
        {
            sqlConn = new SqlConnection(sqlConnStr);
            sqlCmd = sqlConn.CreateCommand();
            debugTextBox = textBox;
        }

        /// <summary>
        /// DBが接続可能であるか確認する
        /// </summary>
        /// <returns></returns>
        public bool CanOpen()
        {
            try
            {
                sqlConn.Open();
                sqlConn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void BeginTransaction()
        {
            sqlConn.Open();
            SqlTransaction tran = sqlConn.BeginTransaction();
            sqlCmd.Transaction = tran;
        }

        public void CommitTransaction()
        {
            sqlCmd.Transaction.Commit();
            sqlConn.Close();
        }

        public void RollBackTransaction()
        {
            sqlCmd.Transaction.Rollback();
            sqlConn.Close();
        }

        /// <summary>
        /// 接続先DBからテーブル一覧を取得する
        /// </summary>
        /// <returns></returns>
        public string[] GetTableList()
        {
            // SQL設定
            sqlCmd.CommandText = SQL_SELECT_TBL;

            // DataTableにSELECT結果を格納
            DataTable dt = new DataTable();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
            sqlAdapter.Fill(dt);

            // テーブル名のみを取り出す
            var obj = from row in dt.AsEnumerable() select row.Field<string>("objectName");

            return obj.ToArray();
        }

        /// <summary>
        /// スキーマ.テーブル名からカラム一覧を取得する
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetColumnList(string tableName)
        {
            // SQL設定
            sqlCmd.CommandText = SQL_SELECT_COLUMNS;

            // 使用するパラメータの定義・値を設定
            sqlCmd.Parameters.Add(new SqlParameter("@schema_name", tableName.Split('.')[0]));
            sqlCmd.Parameters.Add(new SqlParameter("@table_name", tableName.Split('.')[1]));

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();

            // DataTableにSELECT結果を格納
            debugTextBox.Text = sqlCmd.CommandText;
            sqlAdapter.Fill(dt);

            // 使用したパラメータ初期化
            sqlCmd.Parameters.Clear();

            return dt;
        }

        /// <summary>
        /// 指定したテーブルと検索条件に該当するDataTableを取得する。
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable SelectTableRecord(string tableName, DataTable searchConditionDt)
        {
            // SQL生成
            StringBuilder sqlBuilder = new StringBuilder();

            // SELECT句
            sqlBuilder.Append("SELECT");
            for (int i = 0; i < searchConditionDt.Columns.Count; i++)
            {
                if (i == 0)
                {
                    sqlBuilder.AppendFormat(" {0}", searchConditionDt.Columns[i].ColumnName);
                }
                else
                {
                    sqlBuilder.AppendFormat(", {0}", searchConditionDt.Columns[i].ColumnName);
                }
            }

            // FROM句
            sqlBuilder.AppendFormat(" FROM {0}", tableName);


            // WHERE句
#warning 課題① 検索条件に従ったWHERE句を生成すること


            string setSql = string.Empty;
            string whereSql = string.Empty;
            string whereStr = " WHERE ";
            for (int i = 0; i < searchConditionDt.Columns.Count; i++)
            {
                if (searchConditionDt.Rows[0][searchConditionDt.Columns[i].ColumnName].ToString() != "")
                {
                    whereStr += string.Format("{0}='{1}'  AND ", searchConditionDt.Columns[i].ColumnName, searchConditionDt.Rows[0][searchConditionDt.Columns[i].ColumnName].ToString());
                }
            }

            if (whereStr == " WHERE ")
            {
                sqlCmd.CommandText = sqlBuilder.ToString();
                debugTextBox.Text = sqlCmd.CommandText;

                SqlDataAdapter sqlWhereAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dtw = new DataTable();

                // DataTableにSELECT結果を格納
                sqlWhereAdapter.Fill(dtw);
                return dtw;
            }
            else
            {
                whereSql = whereStr.Remove(whereStr.Length - 4, 4);
                // SQL設定
                sqlCmd.CommandText = sqlBuilder.ToString() + whereSql.ToString();
                debugTextBox.Text = sqlCmd.CommandText;

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();

                // DataTableにSELECT結果を格納
                sqlAdapter.Fill(dt);

                return dt;
            }

        }


        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="insertRow"></param>
        /// <returns></returns>
        public int InsertRecord(string tableName, DataRow insertRow)
        {
            // SQL生成(INSERT文)
            StringBuilder sqlBuilder = new StringBuilder();


#warning 課題② 編集グリッドの内容(insertRow)に応じたINSERT文を生成すること

            sqlCmd.CommandText = "";
            string insertStr = "insert into " + tableName + " (";
            string values = " VALUES(";
            int count = 0;

            foreach (var item in insertRow.Table.Columns)
            {
                insertStr += item + ",";
            }
            insertStr = insertStr.TrimEnd(',');
            insertStr += ")";
            List<string> insertList = new List<string>();
            foreach (var item in insertRow.ItemArray)
            {
                insertList.Add(insertRow.ItemArray[count].ToString());
                count++;
            }
            //insertList.RemoveAt(insertList.Count() - 1);
            int a = 1;
            if (tableName == "dbo.answers")
            {
                foreach (var item in insertList)
                {
                    if (item != "")
                    {
                        if (item == "True")
                        {
                            sqlCmd.CommandText += "1,";
                        }
                        else if (item == "false")
                        {
                            sqlCmd.CommandText += "0,";
                        }
                        else
                        {
                            sqlCmd.CommandText += "'" + item + "',";
                        }
                    }
                    a++;
                }
            }
            else
            {
                foreach (var item in insertList)
                {
                    if (item != "")
                    {
                        sqlCmd.CommandText += "'" + item + "',";
                    }
                    a++;
                }
            }

            sqlCmd.CommandText = insertStr + values + sqlCmd.CommandText.TrimEnd(',') + ")";


            // SQL設定
            //sqlCmd.CommandText = sqlBuilder.ToString();


            //SQL実行
            debugTextBox.Text = sqlCmd.CommandText;
            int targetRecordCnt = sqlCmd.ExecuteNonQuery();

            return targetRecordCnt;
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="deleteRow"></param>
        /// <returns></returns>
        public int DeleteRecord(string tableName, DataRow deleteRow)
        {
            // SQL生成(DELETE文)
            StringBuilder sqlBuilder = new StringBuilder();


#warning 課題③ 編集グリッドの内容(deleteRow)に応じたDELETE文を生成すること
            string deleteStr = "";

            deleteStr = "DELETE " + tableName + " WHERE ";

            string deleteSql = "";
            List<DataRow> deleteList = new List<DataRow>();
            if (tableName == "dbo.answers")
            {
                for (int i = 0; i < deleteRow.Table.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        deleteSql += deleteRow.Table.Columns[i] + "=" + deleteRow[i, DataRowVersion.Original] + " and ";

                    }
                    else if (i == 1)
                    {
                        deleteSql += deleteRow.Table.Columns[i] + "='" + deleteRow[i, DataRowVersion.Original] + "' and ";
                    }
                }
            }
            else
            {
                for (int i = 0; i < deleteRow.Table.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        deleteSql += deleteRow.Table.Columns[i] + "=" + deleteRow[i, DataRowVersion.Original] + " and ";

                    }
                }
            }

            int mojisu = deleteSql.Length;
            string trimDeleteSql = deleteSql.Substring(0, mojisu - 4);
            // SQL設定
            sqlCmd.CommandText = deleteStr += trimDeleteSql;

            // SQL実行
            debugTextBox.Text = sqlCmd.CommandText;
            int targetRecordCnt = sqlCmd.ExecuteNonQuery();

            return targetRecordCnt;
        }


        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="updateRow"></param>
        /// <returns></returns>
        public int UpdateRecord(string tableName, DataRow updateRow)
        {
            // SQL生成(UPDATE文)
            StringBuilder sqlBuilder = new StringBuilder();


#warning 課題③ 編集グリッドの内容(updateRow)に応じたUPDATE文を生成すること

            string setSql = string.Empty;
            string whereSql = string.Empty;

            // カラム一覧の取得
            foreach (DataColumn col in updateRow.Table.Columns)
            {

                setSql += string.Format("{0}='{1}', ", col.ColumnName, updateRow[col.ColumnName, DataRowVersion.Current]);
                whereSql += string.Format("{0}='{1}' AND ", col.ColumnName, updateRow[col.ColumnName, DataRowVersion.Original]);
            }

            // 末尾のカンマとANDを除外
            setSql = setSql.Remove(setSql.Length - 2, 2);
            whereSql = whereSql.Remove(whereSql.Length - 4, 4);
            sqlBuilder.AppendFormat("UPDATE {0} SET {1} WHERE {2}", tableName, setSql, whereSql);

            // SQL設定
            sqlCmd.CommandText = sqlBuilder.ToString();

            // SQL実行
            debugTextBox.Text = sqlCmd.CommandText;
            int targetRecordCnt = sqlCmd.ExecuteNonQuery();

            return targetRecordCnt;
        }
    }
}
