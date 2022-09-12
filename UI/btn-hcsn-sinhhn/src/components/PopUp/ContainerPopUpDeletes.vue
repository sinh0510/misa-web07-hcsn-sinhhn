<template>
<!-- PopUp thông báo lưu  -->
  <div class="pop-up1 pop-up-mess">
    <div class="pop-up__container">
      <div class="content1">
        <div class="pop-up__content">
          <div class="pop-up__icon__warning"></div>
          <div class="pop-up__text">
            Bạn có thực sự muốn xóa các mục đã chọn?
          </div>
        </div>
        <div class="line"></div>
        <div class="container_footer">
          <div class="pop-up__footer-left">
            <button class="button btn-cancel" @click="btnCancelPopUp">Không</button>
          </div>
          <div class="pop-up__footer-right">
            <button class="button btn-confirm" @click="btnAgreePopUp">Có</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  props: ["data"],
   data() {
    return {
      MANHANVIEN:1,
    };
  },
  beforeMount() {
    this.Remove()
  },
  methods: {
    btnCancelPopUp() {
      this.$emit("Continue_ShowPopUp", false);
    },
    btnAgreePopUp(){
      this.Delete(this.data.EmployeeId);
      this.$emit("Continue_ShowPopUp", false);
    },
     /**
     * Xóa nhân viên
     * Author:Lợn Cọc
     * Date: 3.33Pm 14/8/2022
     */

  },
}
</script>
<style scoped>
@import url( ../../css/layout/sidebar.css);
</style>