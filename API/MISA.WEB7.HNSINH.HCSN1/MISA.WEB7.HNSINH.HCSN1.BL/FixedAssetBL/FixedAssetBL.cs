
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO;
using MISA.WEB7.HNSINH.HCSN1.DL;

namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public class FixedAssetBL : IFixedAssetBL
    {
        #region Field

        private IFixedAssetDL _fixedAssetDL;

        #endregion

        #region Constructor

        public FixedAssetBL(IFixedAssetDL fixedAssetDL)
        {
            _fixedAssetDL = fixedAssetDL;
        }

        public int DeleteFixedAssetByID(Guid fixedAssetId)
        {
            return _fixedAssetDL.DeleteFixedAssetByID(fixedAssetId);
        }

        public PagingData<FixedAsset> FilterFixedAssets(string? keyword, Guid? fixedAssetCategoryID, Guid? DepartmentID, int pageSize, int pageNumber)
        {
            return _fixedAssetDL.FilterFixedAssets(keyword, fixedAssetCategoryID, DepartmentID, pageSize, pageNumber);
        }

        public string GetNewFixedAssetCode()
        {
            try
            {
                var newCode = _fixedAssetDL.GetNewFixedAssetCode();
             
                return newCode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertFixedAsset(FixedAsset fixedAsset)
        {
            return _fixedAssetDL.InsertFixedAsset(fixedAsset);
        }

        public int UpdateFixedAsset(Guid fixedassetID, FixedAsset fixedAsset)
        {
            return _fixedAssetDL.UpdateFixedAsset(fixedassetID, fixedAsset);
        }

        public object GetFixedAssetByID(Guid fixedassetID)
        {
            return _fixedAssetDL.GetFixedAssetByID(fixedassetID);
        }

        #endregion
    }
}
