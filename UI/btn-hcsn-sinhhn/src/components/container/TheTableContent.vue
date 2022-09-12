<template>
  <div class="table-content">
    <div class="table" style="overflow: auto">
      <table class="m-table">
        <thead style="position: sticky; top: 0px; background-color: f5f5f5">
          <tr style="height: 38px; background-color: #f4f7ff; z-index: 9998">
            <th class="resize-width">
              <label class="checkbox text-align-center"
                ><input @click="isTicksAll()" type="checkbox" /><span
                  class="tick text-align-center"
                  style="margin-left: 5px"
                ></span
              ></label>
            </th>
            <th class="resize-width text-align-center cursor tooltip">
              <p class="tooltiptext">Số thứ tự</p>
              STT
            </th>
            <th class="resize-width text-align-left cursor">Mã tài sản</th>
            <th class="resize-width text-align-left cursor">Tên tài sản</th>
            <th class="resize-width text-align-left cursor">Loại tài sản</th>
            <th class="resize-width text-align-left cursor">Bộ phận sử dụng</th>
            <th class="resize-width text-align-right cursor">Số lượng</th>
            <th class="resize-width text-align-right cursor">Nguyên giá</th>
            <th class="text-align-right resize-width cursor tooltip">
              <p class="tooltiptext">Hao mòn /Khấu hao lũy kế</p>
              HM/KH lũy kế
            </th>
            <th class="resize-width text-align-right cursor">
              Giá trị còn lại
            </th>
            <th class="resize-width text-align-center cursor">Chức năng</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-contextmenu:contextmenu
            v-for="(item, index) in Asset"
            :key="item.FixedAssetId"
            @click="SelectTick($event, item, index)"
            :class="{ checktable: checkTick(item) }"
            @dblclick="isShowDialogDetail(item)"
          >
            <td>
              <label class="checkbox text-align-center" 
                ><input :checked="checkTick(item)" type="checkbox" /><span
                  class="tick"
                ></span
              ></label>
            </td>
            <td class="text-align-center">{{ index + 1 }}</td>
            <td class="text-align-left" id="IdAsset">
              {{ item.FixedAssetCode }}
            </td>
            <td class="text-align-left"  id="nameAsset">
            <p style="width:180px; text-overflow: ellipsis;
              overflow: hidden;
              white-space: nowrap;" >
              {{ item.FixedAssetName }}</p>
            </td>
            <td class="text-align-left">
              {{ NameAssetCategory(item.FixedAssetCategoryID) }}
            </td>
            <td class="text-align-left">
              {{ NameDepartment(item.DepartmentID) }}
            </td>
            <td class="text-align-right quantity">{{ item.Quantity }}</td>
            <td class="text-align-right price">
              {{ FormatNumber(item.Cost) }}
            </td>
            <td class="text-align-right Atrophy">
              {{ FormatNumber(item.DepreciationRate) }}
            </td>
            <td class="text-align-right price-remaining">
              {{ FormatNumber(item.DepreciationValue) }}
            </td>
            <td class="text-align-center">
              <div class="function display-flex">
                <div class="tooltip icon-edit" @click="updateData(item)">
                  <span class="tooltiptexttop">Sửa</span>
                </div>
                <div class="tooltip icon-detail">
                  <span class="tooltiptexttop">Nhân bản</span>
                </div>
                <div
                  class="tooltip icon-onedelete"
                  @click="handleRemoveDetail(item)"
                >
                  <span class="tooltiptexttop">Xóa</span>
                </div>
              </div>
            </td>
          </tr>

          <tr class="table-footer" style="position: sticky; bottom: 0;border-top:1px">
            <td colspan="6">
            </td>
            <td
              class="text-align-right"
              style="font-size: 13px; font-weight: 700"
            >
              200
            </td>
            <td
              class="text-align-right"
              style="font-size: 13px; font-weight: 700"
            >
              20.000.000
            </td>
            <td
              class="text-align-right"
              style="font-size: 13px; font-weight: 700"
            >
              20.000
            </td>
            <td
              class="text-align-right"
              style="font-size: 13px; font-weight: 700"
            >
              6.400.000
            </td>
            <td
              class="text-align-right"
              style="font-size: 13px; font-weight: 700"
            ></td>
          </tr>
        </tbody>
      </table>
   
      
    </div>
     <div class="sumary">
         <div class="paging">
                <div class="total-record">
                  Tổng số: <strong>1000{{totalCount }}</strong> bản ghi
                </div>
                <div class="page-record">
                  <select class="select" name="" id="">
                    <option value="">20</option>
                    <option value="">50</option>
                    <option value="">200</option>
                  </select>
                </div>
                <div class="table__paging--center">
                  <div
                    class="paging__button paging__button--prev icon-content tooltip"
                    @click="onClickPreviousPage"
                  >
                  <span class="tooltiptexttop">Trang trước</span>
                  </div>
                  <div :class="{ selected: page.isDisabled }" @click="onClickPage(page.name)" class="paging__number"
                        v-for="page in pages" :key="page.name">{{ page.name }}</div>
                  <div
                    class="paging__button paging__button--next icon-content tooltip"
                    @click="onClickNextPage"
                    style="margin-left:4px"
                  ><span class="tooltiptexttop">Trang sau</span></div>
                </div>
              </div>
            </div>
    <v-contextmenu ref="contextmenu">
      <v-contextmenu-item>
        <div class="menu-item">
          <div class="menu-item--text">Thêm</div>
        </div>
      </v-contextmenu-item>
      <v-contextmenu-item>
        <div class="menu-item">
          <div class="tooltip edit">
            <div>
              <div class="menu-item--text">Sửa</div>
            </div>
          </div>
        </div>
      </v-contextmenu-item>
      <v-contextmenu-item>
        <div class="menu-item">
          <div class="tooltip onedelete">
            <div>
              <div @click="showpopup(true, data)" class="menu-item--text">
                Xóa
              </div>
            </div>
          </div>
        </div>
      </v-contextmenu-item>
      <v-contextmenu-item>
        <div class="menu-item">
          <div class="tooltip detail">
            <div>
              <div class="menu-item--text">Nhân bản</div>
            </div>
          </div>
        </div>
      </v-contextmenu-item>
    </v-contextmenu>
  </div>
  <ToastMessage
    :dataError="titleWarning"
    :dataAsset="dataSelect"
    v-if="isShowToastNotify"
    @closeToastMS="closeToast"
    v-on:removeSuccess="removeSuccess"
  />
  <DiaLogAdd
    v-if="isShowDialog"
    :title="title"
    :updateSelect="updateSelect"
    @showAssetDetailDialog="showAssetDetailDialog"
  />
</template>

<script>
import DiaLogAdd from "../dialog/DiaLogAdd.vue";
import { FormatNumber } from "../../public/FormatNumber.js";
import { directive, Contextmenu, ContextmenuItem } from "v-contextmenu";
import "v-contextmenu/dist/themes/default.css";
import axios from "axios";
import ToastMessage from "../toast-mess/ToastMessage.vue";

export default {
  directives: {
    contextmenu: directive,
  },
  components: {
    [Contextmenu.name]: Contextmenu,
    [ContextmenuItem.name]: ContextmenuItem,
    ToastMessage,
    DiaLogAdd,
  },
  data() {
    return {
      // Dữ liệu cho api phân trang
      paging: {
        keyWord: "",
        departmentID: "",
        fixedAssetCategoryID: "",
        pageSize: 15,
        pageNumber: 1,
        totalPage: 0,
        maxVisibleButtons: 5,
      },

        dataDepartment: [],
        dataCategory: [],
      isShowDialog: false,
      isShowToastNotify: false,
      directives: {
        contextmenu: directive,
        isNoData: false,
      },
      components: {
        [Contextmenu.name]: Contextmenu,
        [ContextmenuItem.name]: ContextmenuItem,
      },
      isClickRow: "",
      title:"Thêm tài sản",
      Asset: [],
      Category:[],
      Departments:[],
      sumQuantity: 0,
      sumPrice: 0,
      isShowContentMenu: false,
      show: false,
      dataTicks: [],
      IndexFirst: 0,
      IndexLast: 0,
      dataSelect: [],
      titleWarning: [],
      updateSelect: Object,
    };
  },
  computed: {
    ComputedSumPrice() {
      return FormatNumber(this.sumPrice);
    },

    /**
     * Lấy trang đầu tiên.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    startPage() {
      if (this.paging.pageNumber === 1) {
        return 1;
      }
      if (this.paging.pageNumber === this.paging.totalPage) {
        return this.paging.totalPage;
      }
      return this.paging.pageNumber - 1;
    },

    /**
     * Lấy mảng gồm tên và attr btn.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    pages() {
      const range = [];
      for (
        let i = this.startPage;
        i <=
        Math.min(
          this.startPage + this.paging.maxVisibleButtons - 1,
          this.paging.totalPage
        );
        i += 1
      ) {
        range.push({
          name: i,
          isDisabled: i === this.paging.pageNumber,
        });
      }
      return range;
    },
  },

  /**Hiển thị dữ liệu
   * Author :Hoàng Ngọc Sinh
   * **/

  methods: {
    getAsset(paging) {

      this.isLoading = true;
      axios
        .get(
          `http://localhost:10990/api/FixedAssets?pageSize=${paging.pageSize}
          &pageNumber=${paging.pageNumber}
          &keyword=${paging.keyWord}
          &departmentId=${paging.departmentID}
          &fixedAssetCategoryID=${paging.fixedAssetCategoryID}`
        )

        .then((response) => {
          
          this.paging.totalPage = Math.ceil(
            response.data.totalCount / this.paging.pageSize
          );
          this.Asset = response.data.data.map((item) => {
            return {
              CreatedBy: item.createdBy,
              CreatedDate: item.createdDate,
              DepartmentID: item.departmentID,
              DepreciationRate: item.depreciationRate,
              DepreciationValue: item.depreciationValue,
              FixedAssetCategoryID: item.fixedAssetCategoryID,
              FixedAssetCode: item.fixedAssetCode,
              FixedAssetId: item.fixedAssetId,
              FixedAssetName: item.fixedAssetName,
              LifeTime: item.lifeTime,
              ModifiedBy: item.modifiedBy,
              ModifiedDate: item.modifiedDate,
              ProductionDate: item.productionDate,
              PurchaseDate: item.purchaseDate,
              Quantity: item.quantity,
              TrackedYear: item.trackedYear,
              Cost: item.cost,
            };
          });
          console.log(this.Asset);
          this.isLoading = false;

        })
        .catch((error) => {
          this.isLoading = false;
          this.isNoData = true;
          alert(error);
        });
    },
     getDepartments() {
      this.isLoading = true;
      axios
        .get( `http://localhost:10990/api/Departments`)

        .then((response) => {
          this.dataDepartment = response.data
          this.isLoading = false;
        })
        .catch((error) => {
          this.isLoading = false;
          this.isNoData = true;
          alert(error);
        });
    },
     getCategory() {
      this.isLoading = true;
      axios
        .get( `http://localhost:10990/api/FixedAssetCategorys`)

        .then((response) => {
          this.dataCategory = response.data
          this.isLoading = false;
        })
        .catch((error) => {
          this.isLoading = false;
          this.isNoData = true;
          alert(error);
        });
    },
    /**
     * Lấy tên bộ phận sử dụng
     * Author : Hoàng Ngọc Sinh
     * Date:27/08/2022
     */
    NameDepartment(id) {
      for (const item of this.dataDepartment) {
        if (item.DepartmentId == id) {
          return item.DepartmentName;
        }
      }
    },
    /**
     * Lấy tên loại tài sản
     * Author : Hoàng Ngọc Sinh
     * Date:27/08/2022
     */
    NameAssetCategory(id) {
      for (const item of this.dataCategory) {
        if (item.FixedAssetCategoryID == id) {
          return item.FixedAssetCategoryName;
        }
      }
    },

    showAssetDetailDialog(isShowDialog) {
      this.isShowDialog = isShowDialog;
    },

    /**
     * Về trang đầu.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    onClickFirstPage() {
      this.paging.pageNumber = 1;
      this.getData(this.paging);
    },

    /**
     * Lùi 1 trang.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    onClickPreviousPage() {
      if (this.paging.pageNumber > 1) {
        this.paging.pageNumber -= 1;
        this.getAsset(this.paging);
      }
    },


removeSuccess(bool) {if(bool== true) {this.getAsset(this.paging)}},
    /**
     *  Chọn trang muốn đến.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    onClickPage(page) {
      this.paging.pageNumber = page;
      this.getAsset(this.paging);
    },

    /**
     * Tiến 1 trang.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    onClickNextPage() {
      if (this.paging.pageNumber < this.paging.totalPage) {
        this.paging.pageNumber += 1;
        this.getAsset(this.paging);
      }
    },

    /**
     * Đến trang cuối.
     * Hoàng Ngọc Sinh (06/08/2022)
     */
    onClickLastPage() {
      this.paging.pageNumber = this.paging.totalPage;
      this.getAsset(this.paging);
    },

    /**
     *
     */
    FormatNumber,
    /**
     *  Truyền dữ liệu 1 hàng vào 1 mảng
     * Author : Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    btnRowTable(item) {
      console.log(item);
    },
    isShowDialogDetail(item) {
      this.emitter.emit("itemDialog", item);
    },
    /**
     * Xử lý sự kiện nhấn phím ctrl thì chọn nhiều
     * Author : Hoàng Ngọc Sinh
     * Date:20/08/2022
     * @param(e,item,index) e : sự kiện được click vào
     *            item : truyền row vừa click trên table
     *            index : số thứ tự của row đó trong table
     */
    SelectTick(e, item, index) {
      try {
        // Kiểm tra có giữ phím ctrl hay không
        // Nếu có thì thêm vào mảng và không reset lại mảng
        // Ngược lại thì reset mảng
        if (e.ctrlKey == true) {
          this.dataTicks.push(item);
        } else if (e.shiftKey == true) {
          /**
           * Xử lý sự kiện nhấn phím Shitft  thì chọn full đến vị trí click
           * Author : Hoàng Ngọc Sinh
           * Date:20/08/2022
           * */
          this.IndexLast = index;
          for (var i = this.IndexFirst; i <= this.IndexLast; i++) {
            this.dataTicks.push(this.Asset[i]);
          }
        } else {
          this.dataTicks = [];
          this.dataTicks.push(item);
          this.IndexFirst = index;
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Kiểm tra xem row nào đã được tick
     * Author : Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    checkTick(item) {
      try {
        for (const value of this.dataTicks) {
          if (item == value) {
            return item;
          }
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Tick hết tất cả
     * Author : Hoàng Ngọc Sinh
     * Date:20/08/2022
     **/
    isTicksAll() {
      this.isTickAll = !this.isTickAll;
      if (this.isTickAll == true) {
        for (const item of this.Asset) {
          this.dataTicks.push(item);
        }
      } else {
        this.dataTicks = [];
        return;
      }
    },

    // Xóa 1 tài sản
    // Author : Hoàng Ngọc Sinh
    handleRemoveDetail(item) {
      this.isShowToastNotify = true;
      this.titleWarning.push(
        `Bạn có thật sự muốn xóa tài sản ${item.FixedAssetName} này không ?`
      );
      this.dataSelect.push(item);
      this.emitter.emit("LoadData");
    },

    closeToast() {
      this.isShowToastNotify = false;
      this.titleWarning = [];
    },

    updateData(item) {
      axios
        .get(`http://localhost:10990/api/FixedAssets/${item.FixedAssetId}`)
        .then((response) => {
          this.updateSelect = {
            fixedAssetId: response.data.FixedAssetId,
            fixedAssetCode: response.data.FixedAssetCode,
            fixedAssetName: response.data.FixedAssetName,
            departmentID: response.data.DepartmentID,
            departmentName: response.data.DepartmentName,
            fixedAssetCategoryID: response.data.FixedAssetCategoryID,
            fixedAssetCategoryName: response.data.FixedAssetCategoryName,
            quantity: response.data.Quantity,
            cost: response.data.Cost,
            depreciationRate: response.data.DepreciationRate,
            purchaseDate: response.data.DurchaseDate,
            productionDate: response.data.ProductionDate,
            trackedYear: response.data.TrackedYear,
            lifeTime: response.data.LifeTime,
            depreciationValue: response.data.DepreciationValue,
            createdBy: "SINHHN",
            createdDate: new Date(),
            modifiedBy: "SINHHN",
            modifiedDate: new Date(),
          };
          this.isShowDialog = true;
          this.title="Sửa tài sản";
        })
        .catch((error) => {
          this.isLoading = false;
          this.isNoData = true;
          alert(error);
        });
    },
  },
  created() {
    this.getAsset(this.paging);
    this.getDepartments();
    this.getCategory();
  },

};
</script>
<style scoped>
@import url(../../css/main.css);
@import url(../../css/base/tooltip.css);
</style>
