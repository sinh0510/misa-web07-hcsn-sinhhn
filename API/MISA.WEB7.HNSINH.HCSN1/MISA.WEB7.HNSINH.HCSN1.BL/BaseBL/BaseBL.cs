using MISA.WEB7.HNSINH.HCSN1.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Contructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        public virtual IEnumerable<dynamic> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        /// <summary>
        /// Lấy thông tin 1 bản ghi
        /// </summary>
        /// <returns>thông tin 1 bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        public virtual IEnumerable<dynamic> GetRecord(Guid recordID)
        {
            return _baseDL.GetRecord(recordID.ToString());
        }

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID bản ghi vừa xóa</returns>
        /// Created by: SINHHN (23/08/2022)
        public virtual IEnumerable<dynamic> DeleteRecord(Guid recordID)
        {
            return _baseDL.DeleteRecord(recordID.ToString());
        }
        #endregion
    }
}
