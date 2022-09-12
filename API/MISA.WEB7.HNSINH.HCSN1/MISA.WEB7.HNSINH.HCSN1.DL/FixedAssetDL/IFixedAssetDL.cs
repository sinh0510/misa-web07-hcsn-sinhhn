
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO;

namespace MISA.WEB7.HNSINH.HCSN1.DL
{
    public interface IFixedAssetDL
    {
        /// <summary>
        /// Xóa 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: SINHHN (21/08/2022)
        public int DeleteFixedAssetByID(Guid fixedAssetID);

        /// <summary>
        /// Lấy mã tài sản mới
        /// </summary>
        /// <returns>Mã tài sản mới</returns>
        /// Created by: SINHHN (21/08/2022)
        public string GetNewFixedAssetCode();

        /// <summary>
        /// API Lấy danh sách tài sản cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="fixedAssetCategoryID">ID vị trí</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách tài sản thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số tài sản thỏa mãn điều kiện</returns>
        /// Created by: SINHHN (09/06/2022)
        public PagingData<FixedAsset> FilterFixedAssets(string? keyword, Guid? fixedAssetCategoryID, Guid? departmentID, int pageSize, int pageNumber);

        /// <summary>
        /// Thêm 1 tài sản
        /// </summary>
        /// <param name="fixedAsset">ID của tài sản muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: SINHHN (21/08/2022)
        public int InsertFixedAsset(FixedAsset fixedAsset);

        /// <summary>
        /// API sửa 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn sửa</param>
        /// <param name="fixedAsset">Đối tượng tài sản muốn sửa</param>
        /// <returns>ID của tài sản vừa sửa</returns>
        /// Created by: SINHHN (23/08/2022)
        public int UpdateFixedAsset(Guid? fixedAssetID, FixedAsset fixedAsset);

        /// <summary>
        /// Lấy thông tin 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn xem</param>
        /// <returns>Thông tin tài sản</returns>
        /// Created by: SINHHN (21/08/2022)
        public object GetFixedAssetByID(Guid? fixedAssetID);

    }
}
