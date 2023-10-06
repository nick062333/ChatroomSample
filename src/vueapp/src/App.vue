
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
    <div class="fixed-top">
      <p v-if="this.$store.state.auth.isLogin">
      <!-- <router-link to="/">Home</router-link> -->
      <!-- <router-link to="/SignalRSmaple1">建立使用者</router-link> -->
      <router-link to="/">聊天室</router-link>
      <!-- <router-link to="/login" >登入</router-link> -->
      <router-link to="/SignOut" custom v-solt="{ SignOut }"><a v-on:click="SignOut" href="#">登出</a></router-link>
      登入者姓名:{{username}}
    </p>
    </div>
    <!-- <img alt="Vue logo" class="logo" src="./assets/logo.svg" width="125" height="125" /> -->

    <!-- <p v-else>
      <router-link to="/login" >登入</router-link>
    </p> -->
  </header>
  <br />
  <br />
  <main>
    <router-view></router-view>
  </main>
</template>


<script>
  export default {
    data(){
      return {
      }

    },
    computed: {
      username() {
        return this.$store.state.auth.userName
      },
    },
    methods: {
      SignOut(){
        this.$store.dispatch('auth/setAuth',{ token : '', userName:'', isLogin : false });

        window.localStorage.setItem('userData', JSON.stringify({ 
              token:'',
              userName: '',
              isLogin: false, 
          }));

        alert('已登出');
        
        this.$router.push("/");
      }
      // goToDashboard() {
      //   if (isAuthenticated) {
      //     this.$router.push('/dashboard')
      //   } else {
      //     this.$router.push('/login')
      //   }
      // },
    },
  }
</script>