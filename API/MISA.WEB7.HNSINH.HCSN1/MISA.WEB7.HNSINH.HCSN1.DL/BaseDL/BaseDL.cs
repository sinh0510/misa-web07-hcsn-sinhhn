using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Dapper;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MySqlConnector;

namespace MISA.WEB7.HNSINH.HCSN1.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Field
    
        protected const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=misa.web07.hcsn.sinh;Uid=root;Pwd=Sinh@510;";

        #endregion

        ///<summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns> Danh sách tất cả bản ghi</returns>
        /// Created By: SINHHN (23/08/2022)
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
            {
                var className = typeof(T).GetCustomAttribute<TableAttribute>();
                if(className != null)
                {
                    //Chuẩn bị câu truy vấn SELECT
                    var tableName = className.Name;
                    string getAllRecordsCommand = $"SELECT * FROM {tableName}";

                    //Thực hiện chạy câu lệnh SELECT
                    var records = mySqlConnection.Query(getAllRecordsCommand);
                    return records;
                }
                else
                {
                    return Enumerable.Empty<dynamic>();
                }
                
            }
        }

        /// <summary>
        /// Lấy thông tin 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xem</param>
        /// <returns>Thông tin 1 bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        public virtual IEnumerable<dynamic> GetRecord(string recordID)
        {
            using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
            {
                var tableObj = typeof(T).GetCustomAttribute<TableAttribute>();
                var keyObj = typeof(T).GetCustomAttribute<MISA.WEB7.HNSINH.HCSN1.Common.Entity.KeyAttribute>();
                if (tableObj != null && keyObj != null)
                {
                    //Chuẩn bị câu truy vấn SELECT
                    var tableName = tableObj.Name;
                    var fieldName = keyObj.Key;

                    string getRecordCommand = $"SELECT * FROM {tableName} WHERE {fieldName} = '{recordID}'";

                    //Thực hiện chạy câu lệnh SELECT
                    var records = mySqlConnection.Query(getRecordCommand);
                    return records;
                }
                else
                {
                    return Enumerable.Empty<dynamic>();
                }
            }
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Created by: SINHHN (23/08/2022)
        public virtual IEnumerable<dynamic> DeleteRecord(string recordID)
        {
            using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
            {
                var tableObj = typeof(T).GetCustomAttribute<TableAttribute>();
                var keyObj = typeof(T).GetCustomAttribute<MISA.WEB7.HNSINH.HCSN1.Common.Entity.KeyAttribute>();
                if (tableObj != null && keyObj != null)
                {
                    //Chuẩn bị câu truy vấn SELECT
                    var tableName = tableObj.Name;
                    var fieldName = keyObj.Key;
                    string deleteRecordCommand = $"DELETE FROM {tableName} WHERE {fieldName} = '{recordID}'";  

                    //Thực hiện chạy câu lệnh SELECT
                    var numberOfAffectedRows = mySqlConnection.Execute(deleteRecordCommand);
                    return Enumerable.Empty<dynamic>();
                }
                else
                {
                    return Enumerable.Empty<dynamic>();
                }
            }
        }

    }
}
