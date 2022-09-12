using Dapper;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity;
using MISA.WEB7.HNSINH.HCSN1.Common.Entity.DTO;
using MySqlConnector;

namespace MISA.WEB7.HNSINH.HCSN1.DL
{
    public class FixedAssetDL : IFixedAssetDL
    {
        protected const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=misa.web07.hcsn.sinh;Uid=root;Pwd=Sinh@510;";

        public int DeleteFixedAssetByID(Guid fixedAssetID)
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
                {
                    // Chuẩn bị câu lệnh DELETE
                    string deleteFixedAssetCommand = "DELETE FROM fixed_asset WHERE FixedAssetID = @FixedAssetID";

                    // Chuẩn bị tham số đầu vào cho câu lệnh DELETE
                    var parameters = new DynamicParameters();
                    parameters.Add("@FixedAssetID", fixedAssetID);

                    // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
                    int numberOfAffectedRows = mySqlConnection.Execute(deleteFixedAssetCommand, parameters);

                    return numberOfAffectedRows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public object GetFixedAssetByID(Guid? fixedAssetID)
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
                {
                    // Chuẩn bị câu lệnh SELECT
                    string getFixedAssetCommand = $"SELECT * FROM fixed_asset WHERE FixedAssetID = '{fixedAssetID}'";

                    // Thực hiện gọi vào DB để chạy câu lệnh SELECT với tham số đầu vào ở trên
                    var fixedAsset = mySqlConnection.QueryFirstOrDefault(getFixedAssetCommand);

                    return fixedAsset;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string GetNewFixedAssetCode()
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
                {

                    // Khai báo tên Proc
                    string storedProcedureName = "Proc_fixed_asset_GetMaxCode";

                    // Thực hiện gọi vào DB để chạy Proc
                    string maxEmployeeCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                    return maxEmployeeCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public PagingData<FixedAsset> FilterFixedAssets(string? keyword, Guid? fixedAssetCategoryID, Guid? departmentID, int pageSize, int pageNumber)
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
                {

                    // Khai báo Proc
                    string storedProcedureName = "Proc_fixed_asset_GetPaging";

                    var parameters = new DynamicParameters();
                    parameters.Add("@v_Offset", (pageNumber - 1) * pageSize);
                    parameters.Add("@v_Limit", pageSize);
                    parameters.Add("@v_Sort", "ModifiedDate DESC");

                    var orConditions = new List<string>();
                    var andConditions = new List<string>();
                    string whereClause = "";
                    if (keyword != null)
                    {
                        orConditions.Add($"FixedAssetCode LIKE '%{keyword}%'");
                        orConditions.Add($"FixedAssetName LIKE '%{keyword}%'");
                    }
                    if (orConditions.Count > 0)
                    {
                        whereClause = $"({string.Join(" OR ", orConditions)})";
                    }

                    if (departmentID != null)
                    {
                        andConditions.Add($"DepartmentID LIKE '%{departmentID}%'");
                    }
                    if (fixedAssetCategoryID != null)
                    {
                        andConditions.Add($"FixedAssetCategoryID LIKE '%{fixedAssetCategoryID}%'");
                    }

                    if (andConditions.Count > 0)
                    {
                        whereClause += $" AND {string.Join(" AND ", andConditions)}";
                    }

                    parameters.Add("@v_Where", whereClause);

                    // Thực hiện gọi vào DB để chạy Proc với tham số đầu vào ở trên
                    var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                    if (multipleResults != null)
                    {
                        var fixedAssets = multipleResults.Read<FixedAsset>().ToList();
                        var totalCount = multipleResults.Read<long>().Single();
                        return new PagingData<FixedAsset>()
                        {
                            Data = fixedAssets,
                            TotalCount = totalCount
                        };
                    }
                    return new PagingData<FixedAsset>()
                    {
                        Data = { },
                        TotalCount = 0
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int InsertFixedAsset(FixedAsset fixedAsset)
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
                {
                    //Chuẩn bị câu lệnh truy xuất
                    string insertAssetComand = "INSERT INTO fixed_asset(FixedAssetID, FixedAssetCode, FixedAssetName, DepartmentID, FixedAssetCategoryID, PurchaseDate, Cost, Quantity, DepreciationRate, TrackedYear, LifeTime, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ProductionDate, DepreciationValue)" + " VALUES(@FixedAssetID, @FixedAssetCode, @FixedAssetName, @DepartmentID, @FixedAssetCategoryID, @PurchaseDate, @Cost, @Quantity, @DepreciationRate, @TrackedYear, @LifeTime, @CreatedBy, @CreatedDate, @ModifiedBy, @ModifiedDate, @ProductionDate, @DepreciationValue);";

                    //Chuẩn bị tham số đầu vào
                    var FixedAssetID = Guid.NewGuid();
                    var parameters = new DynamicParameters();
                    parameters.Add("@FixedAssetID", FixedAssetID);
                    parameters.Add("@FixedAssetCode", fixedAsset.FixedAssetCode);
                    parameters.Add("@FixedAssetName", fixedAsset.FixedAssetName);
                    parameters.Add("@DepartmentID", fixedAsset.DepartmentID);
                    parameters.Add("@FixedAssetCategoryID", fixedAsset.FixedAssetCategoryID);
                    parameters.Add("@PurchaseDate", fixedAsset.PurchaseDate);
                    parameters.Add("@Cost", fixedAsset.Cost);
                    parameters.Add("@Quantity", fixedAsset.Quantity);
                    parameters.Add("@DepreciationRate", fixedAsset.DepreciationRate);
                    parameters.Add("@TrackedYear", fixedAsset.TrackedYear);
                    parameters.Add("@LifeTime", fixedAsset.LifeTime);
                    parameters.Add("@ProductionDate", fixedAsset.ProductionDate);
                    parameters.Add("@DepreciationValue", fixedAsset.DepreciationValue);
                    parameters.Add("@CreatedDate", fixedAsset.CreatedDate);
                    parameters.Add("@CreatedBy", fixedAsset.CreatedBy);
                    parameters.Add("@ModifiedDate", fixedAsset.ModifiedDate);
                    parameters.Add("@ModifiedBy", fixedAsset.ModifiedBy);

                    //Thực hiện gọi vào DB và chạy câu lệnh.
                    var numberOfAffectedRows = mySqlConnection.Execute(insertAssetComand, parameters);

                    return numberOfAffectedRows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int UpdateFixedAsset(Guid? fixedAssetID, FixedAsset fixedAsset)
        {
            try
            {
                using (var mySqlConnection = new MySqlConnection(CONNECTION_STRING))
                {
                    // Chuẩn bị câu lệnh truy vấn
                    string updateFixedAssetCommand = "UPDATE fixed_asset " +
                        "SET FixedAssetCode = @FixedAssetCode, " +
                        "FixedAssetName = @FixedAssetName, " +
                        "DepartmentID = @DepartmentID, " +
                        "FixedAssetCategoryID = @FixedAssetCategoryID, " +
                        "PurchaseDate = @PurchaseDate, " +
                        "Cost = @Cost, " +
                        "Quantity = @Quantity, " +
                        "DepreciationRate = @DepreciationRate, " +
                        "TrackedYear = @TrackedYear, " +
                        "LifeTime = @LifeTime, " +
                        "ProductionDate = @ProductionDate, " +
                        "DepreciationValue = @DepreciationValue, " +
                        "ModifiedDate = @ModifiedDate, " +
                        "ModifiedBy = @ModifiedBy " +
                        "WHERE FixedAssetID = @FixedAssetID;";

                    // Chuẩn bị tham số đầu vào cho câu lệnh UPDATE
                    var parameters = new DynamicParameters();
                    parameters.Add("@FixedAssetID", fixedAssetID);
                    parameters.Add("@FixedAssetCode", fixedAsset.FixedAssetCode);
                    parameters.Add("@FixedAssetName", fixedAsset.FixedAssetName);
                    parameters.Add("@DepartmentID", fixedAsset.DepartmentID);
                    parameters.Add("@FixedAssetCategoryID", fixedAsset.FixedAssetCategoryID);
                    parameters.Add("@PurchaseDate", fixedAsset.PurchaseDate);
                    parameters.Add("@Cost", fixedAsset.Cost);
                    parameters.Add("@Quantity", fixedAsset.Quantity);
                    parameters.Add("@DepreciationRate", fixedAsset.DepreciationRate);
                    parameters.Add("@TrackedYear", fixedAsset.TrackedYear);
                    parameters.Add("@LifeTime", fixedAsset.LifeTime);
                    parameters.Add("@ProductionDate", fixedAsset.ProductionDate);
                    parameters.Add("@DepreciationValue", fixedAsset.DepreciationValue);
                    parameters.Add("@CreatedDate", fixedAsset.CreatedDate);
                    parameters.Add("@CreatedBy", fixedAsset.CreatedBy);
                    parameters.Add("@ModifiedDate", fixedAsset.ModifiedDate);
                    parameters.Add("@ModifiedBy", fixedAsset.ModifiedBy);

                    // Thực hiện gọi vào DB để chạy câu lệnh UPDATE với tham số đầu vào ở trên
                    int numberOfAffectedRows = mySqlConnection.Execute(updateFixedAssetCommand, parameters);
                    return numberOfAffectedRows;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}


