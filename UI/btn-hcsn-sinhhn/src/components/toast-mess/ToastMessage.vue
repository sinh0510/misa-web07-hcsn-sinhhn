<template>
  <div class="toast-form" id="toast-notify">
    <div class="toast-notify">
      <div class="toast-notify__header">
        <div class="icon-warning">
          <i class="fa-solid fa-triangle-exclamation"></i>
        </div>
        <div class="text-notify">
          <p v-for="item in dataError" :key="item">{{ item }}</p>
        </div>
      </div>
      <div class="toast-notify__footer">
        <button
          class="m-btn btn-save"
          ref="btnConfirm"
          tabindex="1"
          @click="DeleteAsset()">
          Đồng ý
        </button>
        <button
          class="m-btn-white btn-cancel"
          style="margin: 0 10px"
          @keydown.tab.prevent="isFocusConfirm()"
          tabindex="2"
         
          @click="Canceldelete"
        >
          Không
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "TheToastNotify",

  data() {
    return {
      ShowToastNotify: true,
    };
  },

  mounted() {
    this.$refs["btnConfirm"].focus();
  },

  props: {
    dataError: Array,
    dataAsset: Array,
  },

  emits:['closeToastMS'],

  methods: {
    /***
     * Focus vào ô Xác nhận
     * Author:Hoàng Ngọc Sinh(19/08/2022)
     */
    isFocusConfirm() {
      this.$refs["btnConfirm"].focus();
    },

    DeleteAsset() {
      try {
        // Xóa 1 bản ghi
        if (this.dataAsset.length >= 1) {
          axios
            .delete(
              `http://localhost:10990/api/FixedAssets/${this.dataAsset[0].FixedAssetId}`
            )
            .then((res) => {
              console.log(res);
              this.isShowToastNotify = true;
              this.$emit("closeToastMS");
              this.$emit("removeSuccess", true);
            })
            .catch((res) => {
              console.log(res);
            });
        }
  
      } catch (error) {
        console.log(error);
      }
    },
    Canceldelete(){
      this.$emit("closeToastMS");
    }

  },
  
};
</script>

<style>
@import url(../../css/base/toastmessage.css);
@import url(../../css/base/button.css);
</style>