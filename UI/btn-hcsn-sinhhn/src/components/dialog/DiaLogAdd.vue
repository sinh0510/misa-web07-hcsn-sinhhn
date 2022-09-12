<template>
  <div id="dialog" class="dialog" v-bind:class="{ isShowDialog: true }">
    <div class="dialog-content">
      <div class="dialog-header">
        <div class="dialog-title">{{ title }}</div>
        <div class="dialog-close">
          <div
            class="tooltip icon-close"
            id="dialog-close"
            @click="btnCloseOnClick"
          >
            <span class="tooltiptext">Đóng </span>
          </div>
        </div>
      </div>
      <div class="dialog-main">
        <div class="dialog-item">
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Mã tài sản<span style="color: red"> *</span></label
            >
            <input
              v-model="this.asset.fixedAssetCode"
              type="text"
              class="dialog-item m-input input-max"
              id="txtAssetCode"
              required
              ref="txtAssetCode"
              placeholder="Nhập mã tài sản"
              tabindex="1001"
            
              @blur="checkRequired(this.$refs['txtAssetCode'])"
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Tên tài sản<span style="float: top; color: red"> *</span></label
            >
            <input
              v-model="this.asset.fixedAssetName"
              type="text"
              class="dialog-item m-input input-max"
              placeholder="Nhập tên tài sản"
              name="Tên tài sản"
              id="txtNameAsset"
              
              required
              tabindex="1002"
              ref="txtNameAsset"
              @blur="checkRequired(this.$refs['txtNameAsset'])"
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Mã bộ phận sử dụng<span style="float: top; color: red"
                > *</span
              ></label
            >
            <ComboboxDialog
              :url="'http://localhost:10990/api/Departments'"
              :propValue="'DepartmentId'"
              :propText="'DepartmentCode'"
              :placText="'Chọn mã bộ phận sử dụng'"
              style="margin-left: 0px"
              @dataName="setDepartmentName"
              tabindex="1003"
            >
            </ComboboxDialog>
          </div>
          <div class="dialog-item input-big">
            <label class="dialog-label" for="">Tên bộ phận sử dụng</label>
            <input
              type="text"
              class="dialog-item m-input input-max"
              placeholder=""
              v-model="asset.departmentName"
              disabled
              
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Mã loại tài sản<span style="float: top; color: red"
                > *</span
              ></label
            >
            <ComboboxDialog
              :url="'http://localhost:10990/api/FixedAssetCategorys'"
              :propValue="'FixedAssetCategoryID'"
              :propText="'FixedAssetCategoryCode'"
              :placText="'Chọn mã loại tài sản'"
              style="margin-left: 0px"
              @dataName="setCategoryName"
              tabindex="1004"
            >
            </ComboboxDialog>
          </div>
          <div class="dialog-item input-big">
            <label class="dialog-label" for="">Tên loại tài sản</label>
            <input
              type="text"
              class="dialog-item m-input input-max"
              placeholder=""
              v-model="asset.fixedAssetCategoryName"
              disabled
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Số lượng<span style="float: top; color: red"> *</span></label
            >
            <input
              type="text"
              style="text-align: right"
              id="txtQuantity"
              class="m-input input-max absolute"
              tabindex="1005"
              number
              required
              placeholder=""
              v-model="this.asset.quantity"
              ref="txtQuantity"
              @input="FormatNumberInput()"
              @keypress="CheckNumber($event)"
              @blur="checkRequired(this.$refs['txtQuantity'])"
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Nguyên giá<span style="float: top; color: red"> *</span></label
            >
            <input
              type="text"
              style="text-align: right"
              class="dialog-item m-input input-max"
              placeholder="0"
              number
              required
              id="txtPrice"
              v-model="this.asset.cost"
              tabindex="1006"
              ref="txtPrice"
              @blur="checkRequired(this.$refs['txtPrice'])"
              @input="FormatNumberInput()"
            />
          </div>
           <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Số năm sử dụng<span style="float: top; color: red"
                > *</span
              ></label
            >
            <input
              v-model="this.asset.lifeTime"
              type="number"
              style="text-align: right"
              class="dialog-item m-input input-max"
              placeholder=""
              tabindex="1007"
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Tỷ lệ hao mòn (%)<span style="float: top; color: red"
                > *</span
              ></label
            >
            <input
              v-model="this.asset.depreciationRate"
              type="text"
              style="text-align: right"
              class="dialog-item m-input input-max"
              placeholder="0"
              number
              required
              ref="txtAtrophy"
              id="txtAtrophy"
              tabindex="1008"
              @blur="checkRequired(this.$refs['txtAtrophy'])"
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Giá trị hao mòn năm<span style="float: top; color: red"
                > *</span
              ></label
            >
            <input
              v-model="this.asset.depreciationValue"
              type="text"
              style="text-align: right"
              class="m-input input-max"
              placeholder="0"
              number
              required
              id="txtdepreciation"
              ref="txtdepreciation"
              tabindex="1009"
              @blur="checkRequired(this.$refs['txtdepreciation'])"
              @input="FormatNumberInput()"
            />
          </div>
            <div class="dialog-item input-small">
            <label class="dialog-label" for="">Năm theo dõi</label>
            <input
              v-model="this.asset.trackedYear"
              type="text"
              class="dialog-item m-input input-max"
              placeholder=""
              disabled
            />
          </div>
          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Ngày mua<span style="float: top; color: red"> *</span></label
            >
            <input
              v-model="this.asset.purchaseDate"
              type="date"
              class="m-input input-max"
              placeholder=""
              tabindex="1010"
            />
          </div>

          <div class="dialog-item input-small">
            <label class="dialog-label" for=""
              >Ngày bắt đầu sử dụng<span style="float: top; color: red"
                > *</span
              ></label
            >
            <input
              v-model="this.asset.productionDate"
              type="date"
              class="m-input input-max"
              placeholder=""
              tabindex="1011"
            />
          </div>
        
         

        </div>

        <div class="dialog-button">
          <div
            class="m-btn dialog-save"
            @click="btnSaveOnClick2"
            id="btnClose"
            tabindex="1012"
          >
            Lưu
          </div>

          <div
            class="m-btn-white dialog-cancel"
            @click="btnCloseOnClick"
            id="btnClose"
            tabindex="1013">
            Hủy
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ComboboxDialog from "../container/HeadContent/ComboboxDialog.vue";
import { FormatNumber } from "../../public/FormatNumber.js";
import axios from "axios";
export default {
  components: {
    ComboboxDialog,
  },
  name: "DialogAdd",
  emits: ["showAssetDetailDialog"],
  data() {
    return {
      isUpdate: false,
      asset: {
        fixedAssetId: "00000000-0000-0000-0000-000000000000",
        fixedAssetCode: "",
        fixedAssetName: "",
        departmentID: "",
        departmentName: "",
        fixedAssetCategoryID: "",
        fixedAssetCategoryName: "",
        quantity: "",
        cost: "",
        depreciationRate: "",
        purchaseDate: "",
        productionDate: "",
        trackedYear: 2022,
        lifeTime: "",
        depreciationValue: "",
        createdBy: "SINHHN",
        createdDate: new Date(),
        modifiedBy: "SINHHN",
        modifiedDate: new Date(),
      },
      optionCBBox1: [],
      dataItemDetail: [],
      dataName: {
        AssetCode: "Mã tài sản",
        AssetName: "Tên tài sản",
        Price: "Nguyên giá",
        YearDate: "Số năm sử dụng",
        Quantity: "Số lượng",
        Purchasedate: "Ngày mua",
        Startday: "Ngày bắt đầu",
        Depreciation: "Giá trị hao mòn năm",
        Atrophy: "Tỉ lệ hao mòn",
      },
      errors: [],
      isShowDialogNotify: false,
      date: {
        Startday: new Date(),
        Depreciation: new Date(),
      },
    };
  },


  created() {
    /*
     * Hàm lấy dữ liệu đưa vào table
     * Author : Hoàng Ngọc Sinh
     * Date : 22/08/2022
     */
    if (this.updateSelect) {
      this.asset = this.updateSelect;
      this.isUpdate = true; 
    }else {
      this.isUpdate = false;
    }
      /*
     * Hàm sinh mã tự động
     * Author : Hoàng Ngọc Sinh
     * Date : 22/08/2022
     */
    axios.get("http://localhost:10990/api/FixedAssets/new-code")
    .then(res => { this.asset.fixedAssetCode = res.data });
  },
  props: {
    updateSelect: Object,
    title: String,
  },

  methods: {
    FormatNumber,

  

    DataDepartment(e) {
      this.dataItemDetail.departmentID = e.DepartmentID;
      this.dataItemDetail.departmentName = e.DepartmentName;
    },


    btnCloseOnClick() {
      this.$emit("showAssetDetailDialog", false);
    },
    btnSaveOnClick2() {
      try {
        let requestOptions = {};
        if (this.isUpdate) {
          requestOptions = {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
              fixedAssetId: this.asset.fixedAssetId,
              fixedAssetCode: this.asset.fixedAssetCode,
              fixedAssetName: this.asset.fixedAssetName,
              departmentID: this.asset.departmentID,
              fixedAssetCategoryID: this.asset.fixedAssetCategoryID,
              purchaseDate: "1995-06-11T02:18:54",
              cost: this.asset.cost,
              quantity: this.asset.quantity,
              depreciationRate: this.asset.depreciationRate,
              trackedYear: this.asset.trackedYear,
              lifeTime: this.asset.lifeTime,
              createdBy: "SINHHN",
              createdDate: "1977-08-24T23:02:15",
              modifiedBy: "Nguyễn Thị Thành",
              modifiedDate: "2022-08-11T00:58:36",
              productionDate: "1971-01-01T00:00:09",
              depreciationValue: this.asset.depreciationValue,
            }),
          };
          fetch(`http://localhost:10990/api/FixedAssets/${this.asset.fixedAssetId}`, requestOptions)
            .then((res) => res.json())
            
            .then((data) => {
              this.resApi = data.data;
            });
             this.$emit("showAssetDetailDialog", false);
        } else {
          requestOptions = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
              fixedAssetId: "00000000-0000-0000-0000-000000000000",
              fixedAssetCode: String(this.asset.fixedAssetCode),
              fixedAssetName: this.asset.fixedAssetName,
              departmentID: this.asset.departmentID,
              fixedAssetCategoryID: this.asset.fixedAssetCategoryID,
              purchaseDate: "1995-06-11T02:18:54",
              cost: this.asset.cost,
              quantity: this.asset.quantity,
              depreciationRate: this.asset.depreciationRate,
              trackedYear: this.asset.trackedYear,
              lifeTime: this.asset.lifeTime,
              createdBy: "SINHHN",
              createdDate: "1975-01-12T04:25:33",
              modifiedBy: "Nguyễn Thị Thành",
              modifiedDate: "2022-08-11T00:58:36",
              productionDate: "1971-01-01T00:00:09",
              depreciationValue: this.asset.depreciationValue,
            }),
          };
          fetch("http://localhost:10990/api/FixedAssets", requestOptions)
            .then((res) => console.log(res))
         this.$emit("showAssetDetailDialog", false);
        }
      } catch (error) {
        console.log(error);
      }
    },

    Validation() {
      var isCheckRequired = false;
      var res = this.dataItemDetail;
      console.log(res);
      try {
        if (!res.AssetCode) {
          this.errors.push("Mã tài sản không được bỏ trống .");
          isCheckRequired = true;
        } else {
          // Giới hạn 50 kí tự
          if (res.AssetCode.length > 50) {
            this.errors.push("Mã tài sản quá 50 kí tự.");
          }
        }
        if (!res.AssetName) {
          this.errors.push("Tên tài sản không được để trống .");
          isCheckRequired = true;
        }
        if (!res.Quantity) {
          this.errors.push("Số lượng không được để trống .");
          isCheckRequired = true;
        }
        if (!res.Depreciation) {
          this.errors.push("Giá trị hao mòn không được để trống .");
          isCheckRequired = true;
        }
        // tỷ lệ hao mòn không quá 2 kí tự
        if (!res.Atrophy.length > 2) {
          this.errors.push("Tỉ lệ hao mòn không được để trống .");
          isCheckRequired = true;
        }
        if (!res.Quantity) {
          this.errors.push("Số lượng không được để trống .");
          isCheckRequired = true;
        }
        if (isCheckRequired == false) {
          if (this.errors.length >= 1) {
            this.isShowDialogNotify = true;
          } else {
            //
            console.log("a");
          }
        } else {
          alert("Vui lòng nhập trường còn trống");
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Required những dữu liệu cần thiết
     * Author :Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    checkRequired(res) {
      // Kiểm tra nếu input rỗng thì hiển thị border đỏ và hiện thông báo
      if (!res.value) {
        res.classList.add("border-red");
        // this.isRequired = true;
      } else {
        //  this.isRequired = false;
        res.classList.remove("border-red");
      }
    },
    /**
     * Kiểm tra xem nhập liệu đầu vào có phải là số hay không
     * Author :Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    CheckNumber(e) {
      var number = String.fromCharCode(e.keyCode),
        valid = /^[0-9]+$/.test(number);

      if (!valid) {
        e.preventDefault();
      }
    },
    /**
     * Thêm dấu cho số
     * Author :Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    FormatNumberInput() {
      try {
        var value = event.currentTarget.value;
        if (value) {
          value = FormatNumber(value);
          event.currentTarget.value = value;
        }
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Focus vào ô input dầu tiên
     * Author :Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    isFocusInput() {
      this.$refs["txtAssetCode"].focus();
    },
        /**
     * Lấy tên bộ phận vào combobox
     * Author :Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    setDepartmentName(value) {
      this.asset.departmentName = value.DepartmentName;
      this.asset.departmentID = value.DepartmentId;
    },
        /**
     * Lấy tên loại tài sản vào combobox
     * Author :Hoàng Ngọc Sinh
     * Date:20/08/2022
     */
    setCategoryName(value) {
      this.asset.fixedAssetCategoryName = value.FixedAssetCategoryName;
      this.asset.fixedAssetCategoryID = value.FixedAssetCategoryID;
    },
    
  },
    mounted() {
    /**
     * Focus vào ô input đầu tiên khi mở dialog 
     * Author : Hoàng Ngọc Sinh
     * Date:07/09/2022
     */
    this.isFocusInput();
  },
};
</script>
<style scoped>
@import url(../../css/main.css);
</style>
