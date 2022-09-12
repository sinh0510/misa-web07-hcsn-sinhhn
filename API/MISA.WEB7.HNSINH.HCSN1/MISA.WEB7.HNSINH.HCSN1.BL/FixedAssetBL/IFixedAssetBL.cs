using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO;
namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public interface IFixedAssetBL
    {
        /// <summary>
        /// Thêm mới 1 tài sản
        /// </summary>
        /// <param name="fixedAsset">Đối tượng tài sản muốn thêm mới</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: SINHHN (21/08/2022)
        public int InsertFixedAsset(FixedAsset fixedAsset);

        /// <summary>
        /// Sửa 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn sửa</param>
        /// <param name="fixedAsset">Đối tượng tài sản muốn sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: SINHHN (21/08/2022)
        public int UpdateFixedAsset(Guid fixedassetID, FixedAsset fixedAsset);

        /// <summary>
        /// Xóa 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: SINHHN (21/08/2022)
        public int DeleteFixedAssetByID(Guid fixedAssetID);

        /// <summary>
        /// Lấy danh sách tài sản cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param>
        /// <param name="fixedAssetCategoryID">ID loại tài sản</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách tài sản thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số tài sản thỏa mãn điều kiện</returns>
        /// Created by: SINHHN (21/08/2022)
        public PagingData<FixedAsset> FilterFixedAssets(
            string? keyword,
            Guid? fixedAssetCategoryID,
            Guid? departmentID,
            int pageSize,
            int pageNumber);

        /// <summary>
        /// Lấy thông tin chi tiết của 1 tài sản
        /// </summary>
        /// <param name="fixedassetID">ID của tài sản muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng tài sản muốn lấy thông tin chi tiết</returns>
        /// Created by: SINHHN (21/08/2022)
        public object GetFixedAssetByID(Guid fixedassetID);

        /// <summary>
        /// Lấy mã tài sản mới tự động tăng
        /// </summary>
        /// <returns>Mã tài sản mới tự động tăng</returns>
        /// Created by: SINHHN (21/08/2022)
        public string GetNewFixedAssetCode();

    }
}
