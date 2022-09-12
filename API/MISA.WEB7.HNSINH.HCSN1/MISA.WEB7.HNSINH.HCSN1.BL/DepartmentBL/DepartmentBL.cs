using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.DL;

namespace MISA.WEB7.HNSINH.HCSN1.BL
{
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        #region Field

        private IDepartmentDL _departmentDL;

        #endregion

        #region Constructor

        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }
        #endregion
    }
}