<template>
<div class="content-header">
            <div class="content-header-left">
                <p  class="content-title">Danh sách tài sản</p>
            </div>
            <div class="content-header-right">
                <div class="header-department">
                    <p style="font-size:16px" class="name-department">Sở tài chính</p>
                </div>
                <div class="header-year padding">
                    <div class="header-year-text">Năm</div>
                    <div class="header-year-num">2022</div>
                    <div class="header-year-btn">
                        <div class="btn-up icon-content" v-on:click="counter += 1"></div>
                        <div class="btn-down icon-content" v-on:click="counter -= 1"></div>
                    </div>
                </div>
                <div class="tooltip header-notify icon-content padding ">
                    <span class="tooltiptext">Thông báo</span>
                </div>
                <div class="tooltip header-system icon-content padding ">
                    
                    <span class="tooltiptext">Danh mục</span>
                </div>
                <div class="tooltip header-support icon-content padding ">
                    
                    <span class="tooltiptext">Hỗ trợ</span>
                </div>
                <div class="tooltip header-user icon-content padding ">
                    
                    <span class="tooltiptext">Người dùng</span>
                </div>
                <div class="header-arrow icon-content padding"></div>
            </div>
        </div>
</template>

<script>
</script>

<style>
@import url(../../css/main.css);
@import url(../../css/base/tooltip.css)
</style>