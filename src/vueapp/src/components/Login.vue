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

                if(!response || !response.data || response.data.chatroomStatusCode != 200)
                {
                    alert('登入失敗，可能帳號密碼有誤');
                    return;
                }

                let userData = { 
                    "token" : response.data.data.token, 
                    "userName": response.data.data.userName,     
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

                alert('登入失敗1');
            })
        },

        Register(){
            this.$router.push('/Register');
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
            <button type="button" class="btn btn-primary mb-3" v-on:click="Register()">註冊</button>
        </div>
    </form>
</template>

<style>

</style>