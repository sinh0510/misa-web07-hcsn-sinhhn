<template>
    <div class="head-content">
        <div class="head-content-left">
          <div class="m-row" style="width:230px">
            <div class="icon-search">
              <input style="padding-left:45px;width:228px;" type="text" class="m-input search" placeholder="Tìm kiếm tài sản" @keydown.enter="Searchprocessing">
            </div>
          </div>
           <BaseCombobox
              :url="'http://localhost:10990/api/FixedAssetCategorys'"
              :propValue="'FixedAssetCategoryID'"
              :propText="'FixedAssetCategoryName'"
              :placText="'Loại tài sản'"
              style="margin-left: 8px">
            </BaseCombobox>
            <BaseCombobox
              :url="'http://localhost:10990/api/Departments'"
              :propValue="'DepartmentId'"
              :propText="'DepartmentName'"
              :placText="'Bộ phận sử dụng'">
            </BaseCombobox>
        </div>
        <div class="head-content-right">
          <div class="m-btn buttonAdd" id="btnAdd" @click = "btnAddOnClick" >+ Thêm tài sản</div>
          <div class="excel">
            <div class="tooltip icon-excel">
              <span class="tooltiptext">Excel</span>
            </div>
          </div>
          <div class="delete">
            <div class="icon-delete">
              <div class="tooltip icon-delete">
                <span class="tooltiptext" id="btnAdd" @click = "btnAddOnClick">Xóa nhiều</span>
              </div>
            </div>
          </div>
        </div>
      </div>
          <DiaLogAdd 
          v-if="isShowDialog" 
          :title="title"
          @showAssetDetailDialog="showAssetDetailDialog" />
         
</template>

<script>
import DiaLogAdd from '../dialog/DiaLogAdd.vue'
import BaseCombobox from './HeadContent/BaseCombobox.vue'
export default {
  components: {
    DiaLogAdd,
    BaseCombobox
  },
  methods:{
    btnAddOnClick(){
      this.showAssetDetailDialog(true);
    },

    showAssetDetailDialog(isShowDialog){
      this.isShowDialog = isShowDialog;
    }
  },
  data(){
    return{
      isShowDialog : false,
      title:"Thêm tài sản",
    }
  },
   Searchprocessing(item){
            
            if(item=="")
            {
                this.searchArray.departmentID = "";
                this.searchArray.fixedAssetCategoryID = "";
            }
            if(item.DepartmentID != undefined)
            {   
                
                 this.searchArray.departmentID= item.DepartmentID;
            }
            if(item.FixedAssetCategoryID != undefined)
            {   
                
                 this.searchArray.fixedAssetCategoryID= item.FixedAssetCategoryID;
            }
            if(event.currentTarget.value != undefined)
            {
                this.searchArray.keyword= event.currentTarget.value;
            }
            if(item.pageSize != undefined)
            {
                this.searchArray.pageSize = item;
            }
            if(item.pageNumber!=undefined)
            {
                this.searchArray.pageNumber = item;
            }

            this.emitter.emit("search",this.searchArray);
        },
        mounted(){
         /**
         * Sự kiện nhận dữu liệu từ EventBus 
         * Author : Hoàng Ngọc Sinh
         * Date :20 /08/ 2021
         */
        try {
            this.emitter.on("dataPageSize",(item)=>{
                  // truyền data vào cho mảng 
                    this.searchArray.pageSize = item
                    this.Searchprocessing(item)
            }),
            this.emitter.on("pageNumber",item=>{
                // truyền data vào cho mảng 
                this.searchArray.pageNumber = item
                this.Searchprocessing(item)
            })
        } catch (error) {
            console.log(error);
        }
      }


}
</script>
<style scoped>

@import url(../../css/main.css);
@import url(../../css/base/tooltip.css);
</style>
