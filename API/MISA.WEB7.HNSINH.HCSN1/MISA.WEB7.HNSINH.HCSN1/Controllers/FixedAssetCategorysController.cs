using Microsoft.AspNetCore.Mvc;
using MISA.WEB7.HNSINH.HCSN1.BL;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;

namespace MISA.WEB7.HNSINH.HCSN1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedAssetCategorysController : BasesController<FixedAssetCategory>
    {
        #region Field

        private IFixedAssetCategoryBL _fixedAssetCategoryBL;

        #endregion

        #region Constructor
        public FixedAssetCategorysController(IFixedAssetCategoryBL fixedAssetCategoryBL) : base(fixedAssetCategoryBL)
        {
            _fixedAssetCategoryBL = fixedAssetCategoryBL;
        }

        /// <summary>
        /// API Lấy danh sách loại tài sản
        /// </summary>
        /// <returns>Danh sách loại tài sản</returns>
        /// Created by: SINHHN (21/08/2022)
        [HttpGet]
        public override IActionResult GetAllRecords()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _fixedAssetCategoryBL.GetAllRecords());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy thông tin 1 loại tài sản
        /// </summary>
        /// <param name="fixedAssetCategoryID">ID của loại tài sản muốn xem thông tin</param>
        /// <returns>Thông tin loại tài sản</returns>
        /// Created by: SINHHN (23/08/2022)
        [HttpGet("{fixedAssetCategoryID}")]
        public override IActionResult GetRecord([FromRoute] Guid fixedAssetCategoryID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _fixedAssetCategoryBL.GetRecord(fixedAssetCategoryID));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API xóa 1 loại tài sản
        /// </summary>
        /// <param name="fixedAssetCategoryID">ID của loại tài sản muốn xóa</param>
        /// <returns>Id loại tài sản vừa xóa</returns>
        /// Created by: SINHHN (23/08/2022)
        [HttpDelete("{fixedAssetCategoryID}")]
        public override IActionResult DeleteRecord([FromRoute] Guid fixedAssetCategoryID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _fixedAssetCategoryBL.DeleteRecord(fixedAssetCategoryID));
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
