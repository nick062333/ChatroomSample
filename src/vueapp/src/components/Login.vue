<script>
 export default{
    data(){
        return {
            account : '',
            password : ''
        }
    },
    methods:{
        Login()
        {
            console.log('login');
            this.$api.auth.login({ account : this.account, password : this.password })
            .then((response) =>{
                console.log('login', response);
                this.$store.dispatch('auth/setAuth',{ "token" : response.data, "isLogin": true });
                alert('已登入');
                this.$router.push("/");

            })
            .catch((error) => {
                console.log('login error', error);
            })
        }

    }
 }
</script>

<template>
    <form class="row g-3">
        <div class="mb-3 row">
            <label for="staticEmail" class="col-sm-2 col-form-label">帳號</label>
            <div class="col-sm-10">
            <input type="text" class="form-control" v-model="account">
        </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">密碼</label>
            <div class="col-sm-10">
            <input type="password" class="form-control" id="inputPassword"  v-model="password">
            </div>
        </div>
        <div class="col-auto">
            <button type="button" class="btn btn-primary mb-3" v-on:click="Login()">登入</button>
        </div>
    </form>
</template>

<style>

</style>