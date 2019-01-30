using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TableRecordEditor
{
    class DBAccessManger
    {
        const string SYS_TBL = "sys.object";
        const string SYS_COL = "sys.columns";

        const string SQL_GET_TBL =
@"
SELECT sch.name +'.'+ tbl.name AS objectName 
  FROM sys.tables tbl 
 INNER JOIN sys.schemas sch 
         ON tbl.schema_id = sch.schema_id 
 WHERE tbl.is_ms_shipped = 0
";

        const string SQL_GET_COL = "";

        SqlConnection sqlConn;
        SqlCommand sqlCmd;

        public DBAccessManger(string sqlConnStr)
        {
            sqlConn = new SqlConnection(sqlConnStr);
            sqlCmd = sqlConn.CreateCommand();
        }

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

        public string[] GetTableList()
        {
            sqlCmd.CommandText = SQL_GET_TBL;

            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();

            sqlAdapter.Fill(dt);

            var obj = from row in dt.AsEnumerable() select row.Field<string>("objectName");

            return obj.ToArray();
        }
    }
}
