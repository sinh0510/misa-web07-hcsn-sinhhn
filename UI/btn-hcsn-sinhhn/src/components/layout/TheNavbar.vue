<template>
<div   class=" sidebar" v-bind:class="{open: isShowNavBar}">
  <div style="padding: 6px 14px;">
    <div class="nav-header">
      <div class="nav-head">
        <div class="logo-details"  @click = "btnShowNavBarOnClick" id="btn-open">
          <div class='icon-logo'>

          </div>
          <div class="logo_name">MISA QLTS</div>

        </div>
        <ul class="nav-list">
          <li>
            <a href="#">
              <div class='icon-tivi icon-fixed'></div>
              <span class="links_name nav-text">Tổng quan</span>

            </a>
            <span class="tooltip">Tổng quan</span>
          </li>
          <li>
            <a href="#">
              <div class='icon-car icon-fixed '></div>
              <span class="links_name nav-text">Tài sản</span>
            </a>
            <span class="tooltip">Tài sản</span>
          </li>
          <li>
            <a href="#">
              <div class='icon-tree icon-fixed'></div>
              <span class="links_name nav-text">Tài sản HT-DB</span>
            </a>
            <span class="tooltip">Tài sản HT-DB</span>
          </li>
          <li>
            <a href="#">
              <div class='icon-paint icon-fixed'></div>
              <span class="links_name nav-text">Công cụ dụng cụ</span>
            </a>
            <span class="tooltip">Công cụ dụng cụ</span>
          </li>
          <li>
            <a href="#">
              <div class='icon-document icon-fixed'></div>
              <span class="links_name nav-text">Danh mục</span>
             </a>
            <span class="tooltip">Danh mục</span>
          </li>
          <li>
            <a href="#">
              <div class='icon-searchnb icon-fixed'></div>
              <span class="links_name nav-text">Tra cứu</span>
             </a>
            <span class="tooltip">Tra cứu</span>
          </li>
          <li>
            <a href="#">
              <div class='icon-glass icon-fixed'></div>
              <span class="links_name nav-text">Báo cáo</span>
            </a>
            <span class="tooltip">Báo cáo</span>
          </li>

        </ul>
      </div>
    
    </div>
    </div>
    <div id="btn-close" class="profile" @click = "btnHideNavBarOnClick">
        <div class='icon-logout'></div>
      </div>

  </div>
</template>

<script>
export default {
    data() {
      return {
        isShowNavBar : false,
      }
    },
  
methods: {
        //hàm ẩn hiện navbar
        btnShowNavBarOnClick() {
            try {
                this.isShowNavBar = true;
            } catch (error) {
                console.log(error);
            }
        },
        btnHideNavBarOnClick() {
            try {
                this.isShowNavBar = false;
            } catch (error) {
                console.log(error);
            }
        }
    },

}
</script>

<style scoped>
@import url( ../../css/layout/sidebar.css);
</style>