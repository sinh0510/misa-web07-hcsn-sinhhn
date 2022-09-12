<template>
<!-- PopUp thông báo lưu  -->
  <div class="pop-up1 pop-up-mess">
    <div class="pop-up__container">
      <div class="content1">
        <div class="pop-up__content">
          <div class="pop-up__icon__question"></div>
          <div class="pop-up__text">
            Dữ liệu đã bị thay đổi. Bạn có muốn cất không?
          </div>
        </div>
        <div class="line"></div>
        <div class="container_footer">
          <div class="pop-up__footer-left">
            <button class="button btn-cancel" @click="btnCancelPopUp">Hủy</button>
          </div>
          <div class="pop-up__footer-right">
            <button class="button btn-cancel" style="order: 2" @click="btnRefusePopUp">Không</button>
            <button class="button btn-confirm" style="order: 1" @click="btnAgreePopUp">Có</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  methods: {
    btnCancelPopUp() {
      //Tắt PopUp hiện dialog
      this.$emit("Continue_ShowPopUp", false);
      this.$emit("Continue_ShowDialog", true);
    },
    btnAgreePopUp(){
      this.$emit("Continue_ShowPopUp", false);
      this.$emit("Continue_ShowDialog", false);
      //Thực thi thay đổi dữ liệu và đóng dialog và popup
    },
    btnRefusePopUp(){
      this.$emit("Continue_ShowPopUp", false);
      this.$emit("Continue_ShowDialog", false);
      //THoát hẳn dialog và popup
    }
  },
}
</script>