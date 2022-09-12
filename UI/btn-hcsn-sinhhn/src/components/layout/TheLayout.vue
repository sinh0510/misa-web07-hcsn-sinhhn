<template>
<div class="layout">
    <HeaderLayout/>
    <TheContent/>
    <router-view></router-view>
  </div>
</template>

<script>

import HeaderLayout from './TheHeaderLayout.vue'
import TheContent from './TheContent.vue'

export default {
  components: {
    HeaderLayout,
    TheContent,

  },
   


  }
</script>

<style>
@import url(../../css/main.css);
</style>