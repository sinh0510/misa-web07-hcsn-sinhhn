
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB7.HNSINH.HCSN1.Common.Entity
{
    /// <summary>
    /// Loại tài sản
    /// </summary>
    [Table("fixed_asset_category")]
    //[KeyAttribute(Key = "FixedAssetCategoryID")]
    [KeyAttribute(Key = "FixedAssetCategoryID")]
    public class FixedAssetCategory
    {
        #region Property
        [System.ComponentModel.DataAnnotations.Key]
        public Guid FixedAssetCategoryID { get; set; }
        public string? FixedAssetCategoryCode { get; set; }
        public string? FixedAssetCategoryName { get; set; }
        public string? Note { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        #endregion
    }
}
