using MISA.WEB7.HNSINH.HCSN1.BL;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.DL;

namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public class FixedAssetCategoryBL : BaseBL<FixedAssetCategory>, IFixedAssetCategoryBL
    {
        #region Field

        private IFixedAssetCategoryDL _fixedAssetCategoryDL;

        #endregion

        #region Constructor

        public FixedAssetCategoryBL(IFixedAssetCategoryDL fixedAssetCategoryDL) : base(fixedAssetCategoryDL)
        {
            _fixedAssetCategoryDL = fixedAssetCategoryDL;
        }
        #endregion
    }
}
