
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
    <div class="fixed-top bg-light">
        <ul class="nav justify-content-end">
        <li class="nav-item" v-if="this.$store.state.auth.isLogin" >
          您好 {{username}}
        </li>
        <li class="nav-item" v-if="this.$store.state.auth.isLogin" >
          <router-link to="/SignOut" custom v-solt="{ SignOut }"><a v-on:click="SignOut" class="nav-link" href="#">登出</a></router-link>
        </li>
      </ul>
    </div>
  </header>
  <br>
  <main>
    <div class="container">
      <router-view></router-view>
    </div>
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
    },
  }
</script>