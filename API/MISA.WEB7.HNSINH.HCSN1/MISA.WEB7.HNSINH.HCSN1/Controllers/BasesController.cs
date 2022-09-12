using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WEB7.HNSINH.HCSN1.BL;

namespace MISA.WEB7.HNSINH.HCSN1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// Created by: SINHHN (25/08/2022)
        [HttpGet]
        public virtual IActionResult GetAllRecords()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBL.GetAllRecords());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy 1 bản ghi
        /// </summary>
        /// <returns>Thông tin của 1 bản ghi</returns>
        /// Created by: SINHHN (23/08/2022)
        [HttpGet]
        public virtual IActionResult GetRecord(Guid recordID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBL.GetAllRecords());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Xóa 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi vừa xóa</returns>
        /// Created by: SINHHN (23/08/2022)
        [HttpDelete]
        public virtual IActionResult DeleteRecord(Guid recordID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBL.GetAllRecords());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        #endregion
    }
}
