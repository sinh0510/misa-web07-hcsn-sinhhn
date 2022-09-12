using Microsoft.AspNetCore.Mvc;
using MISA.WEB7.HNSINH.HCSN1.BL;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;

namespace MISA.WEB7.HNSINH.HCSN1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        #region Field

        private IDepartmentBL _departmentBL;

        #endregion

        #region Constructor

        public DepartmentsController(IDepartmentBL departmentBL) : base(departmentBL)
        {
            _departmentBL = departmentBL;
        }

        /// <summary>
        /// API Lấy toàn bộ danh sách phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        /// Created by: SINHHN (25/08/2022)
        [HttpGet]
        public override IActionResult GetAllRecords()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _departmentBL.GetAllRecords());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy toàn bộ thông tin 1 phòng ban
        /// </summary>
        /// <param name="departmentID">ID của phòng bàn muốn xem thông tin</param>
        /// <returns>Thông tin phòng ban</returns>
        /// Created by: SINHHN (26/08/2022)
        [HttpGet("{departmentID}")]
        public override IActionResult GetRecord([FromRoute] Guid departmentID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _departmentBL.GetRecord(departmentID));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API xóa 1 phòng ban
        /// </summary>
        /// <param name="departmentID">ID của phòng bàn muốn xóa</param>
        /// <returns>Id phòng ban vừa xóa</returns>
        /// Created by: SINHHN (26/08/2022)
        [HttpDelete("{departmentID}")]
        public override IActionResult DeleteRecord([FromRoute] Guid departmentID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _departmentBL.DeleteRecord(departmentID));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        #endregion
    }
}
