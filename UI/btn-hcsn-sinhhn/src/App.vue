<template>

  <Navbar/>
  <Layout/>
 

</template>


<script>
import Navbar from './components/layout/TheNavbar.vue'
import Layout from './components/layout/TheLayout.vue'
export default {
  name: 'App',
  components: {
    Navbar,
    Layout
  }
}
</script>

<style >
@import url(./css/main.css);
</style>
