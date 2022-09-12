
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB7.HNSINH.HCSN1.Common.Entity
{
    /// <summary>
    /// Tài sản
    /// </summary>
    [Table("fixed_asset")]
    [KeyAttribute(Key = "FixedAssetId")]
    public class FixedAsset
    {
        #region Property
        /// <summary>
        /// ID tài sản
        /// </summary>
        [System.ComponentModel.DataAnnotations.Key]
        public Guid FixedAssetId { get; set; }

        /// <summary>
        /// mã tài sản
        /// </summary>
        [Required(ErrorMessage = "e004")]
        public string? FixedAssetCode { get; set; }

        /// <summary>
        /// Tên tài sản
        /// </summary>
        [Required(ErrorMessage = "e005")]
        public string? FixedAssetName { get; set; }

        /// <summary>
        /// ID bộ phận sử dụng
        /// </summary>
        [Required(ErrorMessage = "e006")]
        public Guid? DepartmentID { get; set; }

        /// <summary>
        /// ID Loại tài sản
        /// </summary>
        [Required(ErrorMessage = "e007")]
        public Guid? FixedAssetCategoryID { get; set; }

        /// <summary>
        /// Ngày mua
        /// </summary>
        [Required(ErrorMessage = "e013")]
        public DateTime PurchaseDate { get; set; }

        /// <summary>
        /// Nguyên giá
        /// </summary>
        [Required(ErrorMessage = "e009")]
        public decimal Cost { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        [Required(ErrorMessage = "e008")]
        public int Quantity { get; set; }

        /// <summary>
        /// Tỉ lệ hao mòn
        /// </summary>
        [Required(ErrorMessage = "e011")]
        public float DepreciationRate { get; set; }

        /// <summary>
        /// Năm bắt đầu theo dõi tài sản
        /// </summary>
        public int TrackedYear { get; set; }

        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        [Required(ErrorMessage = "e010")]
        public int LifeTime { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người sửa gần nhất
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Ngày bắt đầu sử dụng
        /// </summary>
        [Required(ErrorMessage = "a014")]
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// Giá trị hao mòn năm
        /// </summary>
        [Required(ErrorMessage = "a012")]
        public int DepreciationValue { get; set; }
        #endregion
    }
}

