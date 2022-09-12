using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using MISA.WEB7.HNSINH.HCSN1.BL;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO;

namespace MISA.WEB7.HNSINH.HCSN1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedAssetsController : ControllerBase
    {
        #region Field

        private IFixedAssetBL _fixedAssetBL;

        #endregion

        #region Constructor

        public FixedAssetsController(IFixedAssetBL fixedAssetBL)
        {
            _fixedAssetBL = fixedAssetBL;
        }

        #endregion

        #region Methods

        /// <summary>
        /// API Xóa 1 tài sản
        /// </summary>
        /// <returns>Id tài sản vừa xóa</returns>
        /// Created by: SINHHN (21/08/2022)
        [HttpDelete("{fixedAssetId}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteFixedAssetByID([FromRoute] Guid fixedAssetId)
        {
            try
            {
                int numberOfAffectedRows = _fixedAssetBL.DeleteFixedAssetByID(fixedAssetId);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, fixedAssetId);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API Lấy danh sách tài sản cho phép lọc và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param> 
        /// <param name="fixedAssetCategoryID">ID vị trí</param>
        /// <param name="departmentID">ID phòng ban</param>
        /// <param name="pageSize">Số trang muốn lấy</param>
        /// <param name="pageNumber">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách tài sản thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số tài sản thỏa mãn điều kiện</returns>
        /// Created by: SINHHN (21/08/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<FixedAsset>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterFixedAssets(
            [FromQuery] string? keyword,
            [FromQuery] Guid? departmentID,
            [FromQuery] Guid? fixedAssetCategoryID,
            [FromQuery] int pageSize = 15,
            [FromQuery] int pageNumber = 1)
        {
            try
            {
                var dataPaging = _fixedAssetBL.FilterFixedAssets(keyword, fixedAssetCategoryID, departmentID, pageSize, pageNumber);

                // Xử lý dữ liệu trả về
                if (dataPaging != null)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, dataPaging);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// Lấy mã tài sản tự động tăng
        /// </summary>
        /// <returns>
        /// Mã tài sản tự động tăng
        /// </returns>
        /// Created by: SINHHN (21/08/2022)
        [HttpGet("new-code")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNewFixedAssetCode()
        {
            try
            {
                var newCode = _fixedAssetBL.GetNewFixedAssetCode();
                // Xử lý kết quả trả về từ DB
                if (newCode != null)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, newCode);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }

        }

        /// <summary>
        /// API Lấy thông tin 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn xem</param> 
        /// <returns>Một đối tượng gồm:
        /// Thông tin tài sản
        /// Created by: SINHHN (21/08/2022)
        [HttpGet("{fixedAssetID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<FixedAsset>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFixedAssetByID(Guid fixedAssetID)
        {
            try
            {
                var dataFixedAsset = _fixedAssetBL.GetFixedAssetByID(fixedAssetID);

                // Xử lý dữ liệu trả về
                if (dataFixedAsset != null)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, dataFixedAsset);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

        /// <summary>
        /// API thêm mới 1 tài sản
        /// </summary>
        /// <param name="fixedAsset">Đối tượng tài sản muốn thêm mới</param>
        /// <returns>ID của tài sản vừa thêm mới</returns>
        /// Created by: SINHHN (18/08/2022)
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult InsertFixedAsset([FromBody] FixedAsset fixedAsset)
        {
            try
            {
                var numberOfAffectedRows = _fixedAssetBL.InsertFixedAsset(fixedAsset);
                if (numberOfAffectedRows > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, fixedAsset);
                }
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001");
            }
        }

      
        /// <summary>
        /// API sửa 1 tài sản
        /// </summary>
        /// <param name="fixedAssetID">ID của tài sản muốn sửa</param>
        /// <param name="fixedAsset">Đối tượng tài sản muốn sửa</param>
        /// <returns>ID của tài sản vừa sửa</returns>
        /// Created by: SINHHN (23/08/2022)
        [HttpPut("{fixedAssetID}")]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(Guid))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateFixedAsset(Guid fixedAssetID, [FromBody] FixedAsset fixedAsset)
        {
            try
            {
                var res = _fixedAssetBL.UpdateFixedAsset(fixedAssetID, fixedAsset);

                if (res > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, fixedAsset);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "e002");
                }
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
