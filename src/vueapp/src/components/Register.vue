<script>
 export default{
    data(){
        return {
            account : '',
            userName : '',
            password : ''
        }
    },
    methods:{
        ToRegister()
        {
            console.log('Register');

            this.$api.auth.login({ account : this.account, password : this.password })
            .then((response) =>{
                console.log('login', response);

                let userData = { 
                    "token" : response.data, 
                    "userName": this.account, 
                    "isLogin": true 
                };

                this.$store.dispatch('auth/setAuth', userData);

                window.localStorage.setItem('userData', JSON.stringify(userData));

                alert('已登入');
                this.$router.push("/");

            })
            .catch((error) => {
                this.$store.dispatch('auth/setAuth',);

                window.localStorage.setItem('userData', JSON.stringify({ 
                    token:'',
                    userName: '',
                    isLogin:false, 
                }));

                console.log('login error');
            })
        },
    }
 }
</script>

<template>
    <form class="row g-3">
        <div class="mb-3 row">
            <label for="staticEmail" class="col-sm-2 col-form-label">使用者名稱</label>
            <div class="col-sm-10">
            <input type="text" class="form-control" v-model="userName">
        </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">帳號</label>
            <div class="col-sm-10">
            <input type="password" class="form-control" id="inputPassword"  v-model="account">
            </div>
        </div>
        <div class="mb-3 row">
            <label for="inputPassword" class="col-sm-2 col-form-label">密碼</label>
            <div class="col-sm-10">
            <input type="password" class="form-control" id="inputPassword"  v-model="password">
            </div>
        </div>
        <div class="col-auto">
            <button type="button" class="btn btn-primary mb-3" v-on:click="Login()">註冊</button>
            <button type="button" class="btn btn-primary mb-3" v-on:click="Register()">清除</button>
        </div>
    </form>
</template>

<style>

</style>