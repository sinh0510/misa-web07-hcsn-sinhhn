using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO;

namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public interface IFixedAssetCategoryBL : IBaseBL<FixedAssetCategory>
    {
        /// <summary>
        /// Get mã tài sản mới nhất
        /// <returns>Mã tài sản  mới nhất</returns>
        /// Created by: SINHHN (26/08/2022)
        ///public string GetNewFixedAssetCode();

        /// <summary>
        /// Lọc data theo phân loại và có phân trang
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="departmentID"></param>
        /// <param name="fixedAssetCategoryID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns>Danh sách tàn sản vừa lọc</returns>
        /// Created by: SINHHN (26/08/2022)
        ///public PagingData<FixedAsset> FilterFixedAsset(string? keyword, Guid? fixedAssetCategoryID, Guid? departmentID, int pageSize = 10, int pageNumber = 1);

        /// <summary>
        /// Sửa thông tin tài sản
        /// </summary>
        /// <param name="fixedAssetID"> ID tài sản cần sửa</param>
        /// <param name="fixedAsset"></param>
        /// <returns>Mã tài sản vừa update</returns>
        /// Created by: SINHHN (26/08/2022)
        ///public int UpdateFixedAsset(Guid fixedAssetID, FixedAsset fixedAsset);
    }

}
