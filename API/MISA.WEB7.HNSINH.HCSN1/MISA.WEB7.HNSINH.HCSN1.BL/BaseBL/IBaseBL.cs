using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách các bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        public IEnumerable<dynamic> GetAllRecords();


        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="recordID"></param> 
        /// <returns>Thông tin 1 bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        public IEnumerable<dynamic> GetRecord(Guid recordID);

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID"></param> 
        /// <returns>ID bản ghi vừa xóa</returns>
        /// Created by: SINHHN (23/08/2022)
        public IEnumerable<dynamic> DeleteRecord(Guid recordID);




    }
}
