﻿using System.Collections.Generic;

namespace MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO
{

    public class PagingData<T>
    {
        /// <summary>
        /// Mảng đối tượng thỏa mãn điều kiện lọc và phân trang 
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public long TotalCount { get; set; }
    }

}
