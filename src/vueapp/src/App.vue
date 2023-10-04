
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
  <header>
    <!-- <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" /> -->
    <p>
      <router-link to="/">Home</router-link>
      <router-link to="/SignalRSmaple1">Signalr測試</router-link>
      <router-link to="/SignalRSmaple1">建立使用者</router-link>
      <router-link to="/Chatroom">聊天室</router-link>
    </p>
    <div class="wrapper">
    </div>
  </header>
  <br />
  <br />
  <main>
    <router-view></router-view>
  </main>
</template>


<script>
  export default {
    computed: {
      username() {
        return this.$route.params.username
      },
    },
    methods: {
      goToDashboard() {
        if (isAuthenticated) {
          this.$router.push('/dashboard')
        } else {
          this.$router.push('/login')
        }
      },
    },
  }
</script>