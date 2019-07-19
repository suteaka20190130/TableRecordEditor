using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlTypes;

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
            if (sqlCmd.Transaction != null)
            {
                sqlCmd.Transaction.Rollback();
                sqlConn.Close();
            }
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
            sqlCmd.Parameters.Add(new SqlParameter("@table_name", tableName));

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
        public DataTable SelectTableRecord(string tableName, DataTable searchConditionDt, ref DataTable schemaDt)
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
            string whereSql = string.Empty;
            string whereStr = " WHERE ";
            string whereScalar = "\r\n";

            sqlCmd.Parameters.Clear();
            for (int i = 0; i < searchConditionDt.Columns.Count; i++)
            {
                if (searchConditionDt.Rows[0][searchConditionDt.Columns[i].ColumnName].ToString() != "")
                {
                    SqlParameter param = sqlCmd.CreateParameter();
                    param.ParameterName = "@" + searchConditionDt.Columns[i].ColumnName;
                    param.SqlDbType = ConvertSqlDbType(searchConditionDt.Columns[i].DataType);
                    param.Direction = ParameterDirection.Input;
                    var setVal = searchConditionDt.Rows[0][searchConditionDt.Columns[i].ColumnName];
                    param.Value = setVal == DBNull.Value ? SetNullValue(searchConditionDt.Columns[i].DataType) : setVal;
                    sqlCmd.Parameters.Add(param);

                    whereStr += string.Format("{0}=@{0}  AND ", searchConditionDt.Columns[i].ColumnName);

                    //whereScalar += string.Format("@{0}={1} \r\n", searchConditionDt.Columns[i].ColumnName, setVal);
                    whereScalar += string.Format("@{0}={1} \r\n", searchConditionDt.Columns[i].ColumnName, ConvertOutputFormat(param.Value, searchConditionDt.Columns[i].DataType));
                }
            }

            if (whereStr == " WHERE ")
            {
                sqlCmd.CommandText = sqlBuilder.ToString();
            }
            else
            {
                whereSql = whereStr.Remove(whereStr.Length - 4, 4);
            }
            // SQL設定  
            sqlCmd.CommandText = sqlBuilder.ToString() + whereSql.ToString();
            debugTextBox.Text = sqlCmd.CommandText + whereScalar.ToString();

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();

            // DataTableにSELECT結果を格納
            sqlAdapter.Fill(dt);

            // テーブルの定義情報を読み出す
            schemaDt = new DataTable();
            sqlAdapter.FillSchema(schemaDt, SchemaType.Source);

            return dt;
        }


        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="insertRow"></param>
        /// <returns></returns>
        public int InsertRecord(string tableName, DataRow insertRow, ref DataTable schemaDt)
        {
            // SQL生成(INSERT文)

            sqlCmd.CommandText = "";
            string insertStr = "insert into " + tableName + " (";
            string values = " VALUES(";
            string insertScalar = "\r\n";

            sqlCmd.Parameters.Clear();

            for (int i = 0; i < insertRow.Table.Columns.Count; i++)
            {
                if (schemaDt.Columns[insertRow.Table.Columns[i].ColumnName].AllowDBNull == false && insertRow[insertRow.Table.Columns[i].ColumnName, DataRowVersion.Current] == DBNull.Value)
                {
                    throw new Exception($"NULL非許容の列に空文字は指定できません。{insertRow.Table.Columns[i].ColumnName}");
                }
                insertStr += insertRow.Table.Columns[i].ColumnName + ",";
                values += "@" + insertRow.Table.Columns[i].ColumnName + ",";

                SqlParameter param = sqlCmd.CreateParameter();
                param.ParameterName = "@" + insertRow.Table.Columns[i].ColumnName;
                param.SqlDbType = ConvertSqlDbType(insertRow.Table.Columns[i].DataType);
                param.Direction = ParameterDirection.Input;
                var setVal = insertRow[i];
                param.Value = setVal == DBNull.Value ? SetNullValue(insertRow.Table.Columns[i].DataType) : setVal;
                sqlCmd.Parameters.Add(param);

                //insertScalar += string.Format("@{0}={1} \r\n", insertRow.Table.Columns[i].ColumnName, setVal == DBNull.Value ? SetNullValue(insertRow.Table.Columns[i].DataType) : setVal);
                insertScalar += string.Format("@{0}={1} \r\n", insertRow.Table.Columns[i].ColumnName, ConvertOutputFormat(param.Value, insertRow.Table.Columns[i].DataType));
            }

            insertStr = insertStr.TrimEnd(',');
            values = values.TrimEnd(',');

            insertStr += ")";

            sqlCmd.CommandText = insertStr + values + ")";

            //SQL実行
            debugTextBox.Text += sqlCmd.CommandText + insertScalar + "-----\r\n";
            int targetRecordCnt = sqlCmd.ExecuteNonQuery();

            return targetRecordCnt;
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="deleteRow"></param>
        /// <returns></returns>
        public int DeleteRecord(string tableName, DataRow deleteRow, ref DataTable schemaDt)
        {
            // SQL生成(DELETE文)

            string deleteStr = "DELETE " + tableName + " WHERE ";
            string deleteScalar = "\r\n";
            string deleteSql = "";

            sqlCmd.Parameters.Clear();

            foreach (DataColumn col in schemaDt.PrimaryKey)
            {
                SqlParameter param = sqlCmd.CreateParameter();
                param.ParameterName = "@where" + col.ColumnName;
                param.SqlDbType = ConvertSqlDbType(col.DataType);
                param.Direction = ParameterDirection.Input;
                var setVal = deleteRow[col.ColumnName, DataRowVersion.Original];
                param.Value = setVal == DBNull.Value ? SetNullValue(col.DataType) : setVal;
                sqlCmd.Parameters.Add(param);

                deleteSql += string.Format("{0}=@where{0}  AND ", col.ColumnName);
                //deleteScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, setVal);
                deleteScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, ConvertOutputFormat(param.Value, col.DataType));
            }

            if (deleteSql == "")
            {
                foreach (DataColumn col in deleteRow.Table.Columns)
                {

                    if (deleteRow[col.ColumnName, DataRowVersion.Original] == DBNull.Value)
                    {
                        deleteSql += string.Format("{0}{1}  AND ", col.ColumnName, " IS NULL");
                    }
                    else
                    {
                        SqlParameter param = sqlCmd.CreateParameter();
                        param.ParameterName = "@where" + col.ColumnName;
                        param.SqlDbType = ConvertSqlDbType(col.DataType);
                        param.Direction = ParameterDirection.Input;
                        var setVal = deleteRow[col.ColumnName, DataRowVersion.Original];
                        param.Value = setVal == DBNull.Value ? SetNullValue(col.DataType) : setVal;
                        sqlCmd.Parameters.Add(param);
                        deleteSql += string.Format("{0}=@where{0}  AND ", col.ColumnName);
                        //deleteScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, setVal);
                        deleteScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, ConvertOutputFormat(param.Value, col.DataType));
                    }
                }
            }

            int mojisu = deleteSql.Length;
            string trimDeleteSql = deleteSql.Substring(0, mojisu - 4);
            // SQL設定
            sqlCmd.CommandText = deleteStr += trimDeleteSql;

            // SQL実行
            debugTextBox.Text += sqlCmd.CommandText + deleteScalar + "-----\r\n";
            int targetRecordCnt = sqlCmd.ExecuteNonQuery();

            return targetRecordCnt;
        }


        /// <summary>
        /// 更新処理
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="updateRow"></param>
        /// <returns></returns>
        public int UpdateRecord(string tableName, DataRow updateRow, ref DataTable schemaDt)
        {
            // SQL生成(UPDATE文)
            StringBuilder sqlBuilder = new StringBuilder();

            string setSql = string.Empty;
            string whereSql = string.Empty;
            string setScalar = "\r\n";
            string whereScalar = string.Empty;

            // カラム一覧の取得
            sqlCmd.Parameters.Clear();

            foreach (DataColumn col in updateRow.Table.Columns)
            {
                if (schemaDt.Columns[col.ColumnName].AllowDBNull == false && updateRow[col.ColumnName, DataRowVersion.Current] == DBNull.Value)
                {
                    throw new Exception($"NULL非許容の列に空文字は指定できません。{col.ColumnName}");
                }
                SqlParameter param = sqlCmd.CreateParameter();
                param.ParameterName = "@" + col.ColumnName;
                param.SqlDbType = ConvertSqlDbType(col.DataType);
                param.Direction = ParameterDirection.Input;
                var setVal = updateRow[col.ColumnName, DataRowVersion.Current];
                param.Value = setVal == DBNull.Value ? SetNullValue(col.DataType) : setVal;
                sqlCmd.Parameters.Add(param);

                setSql += string.Format("{0}=@{0},", col.ColumnName);
                //setScalar += string.Format("@{0}={1} \r\n", col.ColumnName, setVal == DBNull.Value ? SetNullValue(col.DataType) : setVal);
                setScalar += string.Format("@{0}={1} \r\n", col.ColumnName, ConvertOutputFormat(param.Value, col.DataType));
            }


            foreach (DataColumn col in schemaDt.PrimaryKey)
            {
                SqlParameter param = sqlCmd.CreateParameter();
                param.ParameterName = "@where" + col.ColumnName;
                param.SqlDbType = ConvertSqlDbType(col.DataType);
                param.Direction = ParameterDirection.Input;
                var setVal = updateRow[col.ColumnName, DataRowVersion.Original];
                param.Value = setVal == DBNull.Value ? SetNullValue(col.DataType) : setVal;
                sqlCmd.Parameters.Add(param);

                whereSql += string.Format("{0}=@where{0}  AND ", col.ColumnName);
                //whereScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, setVal);
                whereScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, ConvertOutputFormat(param.Value, col.DataType));
            }

            if (whereSql == "")
            {
                foreach (DataColumn col in updateRow.Table.Columns)
                {
                    if (updateRow[col.ColumnName, DataRowVersion.Original] == DBNull.Value)
                    {
                        whereSql += string.Format("{0}{1}  AND ", col.ColumnName, " IS NULL");
                    }
                    else
                    {
                        SqlParameter param = sqlCmd.CreateParameter();
                        param.ParameterName = "@where" + col.ColumnName;
                        param.SqlDbType = ConvertSqlDbType(col.DataType);
                        param.Direction = ParameterDirection.Input;
                        var setVal = updateRow[col.ColumnName, DataRowVersion.Original];
                        param.Value = setVal == DBNull.Value ? SetNullValue(col.DataType) : setVal;
                        sqlCmd.Parameters.Add(param);

                        whereSql += string.Format("{0}=@where{0}  AND ", col.ColumnName);
                        //whereScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, setVal);
                        whereScalar += string.Format("@where{0}={1} \r\n", col.ColumnName, ConvertOutputFormat(param.Value, col.DataType));
                    }
                }
            }


            // 末尾のカンマとANDを除外
            setSql = setSql.Remove(setSql.Length - 1, 1);
            whereSql = whereSql.Remove(whereSql.Length - 4, 4);

            sqlBuilder.AppendFormat("UPDATE {0} SET {1} WHERE {2}", tableName, setSql, whereSql);

            // SQL設定
            sqlCmd.CommandText = sqlBuilder.ToString();

            // SQL実行
            debugTextBox.Text += sqlCmd.CommandText + setScalar + whereScalar + "-----\r\n";
            int targetRecordCnt = sqlCmd.ExecuteNonQuery();

            return targetRecordCnt;
        }
        private SqlDbType ConvertSqlDbType(Type type)
        {
            if (type == typeof(string))
            {
                return SqlDbType.NVarChar;
            }
            else if (type == typeof(Int16))
            {
                return SqlDbType.SmallInt;
            }
            else if (type == typeof(Int32))
            {
                return SqlDbType.Int;
            }
            else if (type == typeof(Int64))
            {
                return SqlDbType.BigInt;
            }
            else if (type == typeof(decimal))
            {
                return SqlDbType.Decimal;
            }
            else if (type == typeof(DateTime))
            {
                return SqlDbType.DateTime;
            }
            else if (type == typeof(Boolean))
            {
                return SqlDbType.Bit;
            }
            else
            {
                throw new Exception($"想定外のデータ型です。{type.ToString()}");
            }
        }

        private INullable SetNullValue(Type type)
        {
            if (type == typeof(string))
            {
                return SqlString.Null;
            }
            else if (type == typeof(Int16))
            {
                return SqlInt16.Null;
            }
            else if (type == typeof(Int32))
            {
                return SqlInt32.Null;
            }
            else if (type == typeof(Int64))
            {
                return SqlInt64.Null;
            }
            else if (type == typeof(decimal))
            {
                return SqlDecimal.Null;
            }
            else if (type == typeof(DateTime))
            {
                return SqlDateTime.Null;
            }
            else if (type == typeof(Boolean))
            {
                return SqlBoolean.Null;
            }
            else
            {
                throw new Exception($"Nullを持つ想定外のデータ型です。{type.ToString()}");
            }
        }

        private string ConvertOutputFormat(object val, Type type)
        {
            if (type == typeof(DateTime))
            {
                return String.Format("{0:yyyy-MM-dd HH:mm:ss.fff}", val);
            }
            return val.ToString();
        }
    }
}
