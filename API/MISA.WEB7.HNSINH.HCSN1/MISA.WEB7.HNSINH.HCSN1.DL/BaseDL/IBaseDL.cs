using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WEB7.HNSINH.HCSN1.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi của 1 bảng</returns>
        /// Created by: SINHHN (23/08/2022)
        public IEnumerable<dynamic> GetAllRecords();

        /// <summary>
        /// Lấy thông tin 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xem</param>
        /// <returns>Thông tin 1 bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        public IEnumerable<dynamic> GetRecord(string recordID);

        /// <summary>
        /// Xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Created by: SINHHN (23/08/2022)
        public IEnumerable<dynamic> DeleteRecord(string recordID);

        ///<summary>
        ///Thêm 1 bản ghi
        /// </summary>
        ///<param name="Record"> Bản ghi cần thêm mới </param>
        ///<returns> Trả về bản ghi khi đã thêm mới thành công </returns>
       /// public Guid InsertOneRecord(T record);

        ///<summary>
        ///Sửa 1 bản ghi
        /// </summary>
        ///<param name="record"> Bản ghi cần thêm mới </param>
        ///<param name="recordId"></param>
        ///<returns> Trả về bản ghi khi đã sửa thành công </returns>
      ///  public Guid UpdateOneRecord(T record, Guid recordId);

    }
}
