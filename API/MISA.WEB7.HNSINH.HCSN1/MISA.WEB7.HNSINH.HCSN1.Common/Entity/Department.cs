using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.WEB7.HNSINH.HCSN1.Common.Entity
{ 
    /// <summary>
    /// Phòng ban
    /// </summary>
    [Table("department")]
    [KeyAttribute(Key = "DepartmentID")]


    public class Department
{
    #region Property
    [System.ComponentModel.DataAnnotations.Key]
    public Guid DepartmentID { get; set; }
    public string? DepartmentCode { get; set; }
    public string? DepartmentName { get; set; }
    public string? Note { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    #endregion
}
}
