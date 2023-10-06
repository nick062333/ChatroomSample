
<style scoped>
    /* 當<style>標籤具有該scoped屬性時，其 CSS 將僅套用於目前組件的元素。這類似於 Shadow DOM 中的樣式封裝。 */
   a {
    display:inline;
    margin-right: 15px;
  }

  main {
    display:inline;
  }
</style>

<template>
  <div>Hello World!!</div>
</template>


<script>
  export default {
    data(){
      return {
      }

    },
    computed: {
      // username() {
      //   return this.$route.params.username
      // },
    },
  }
</script>