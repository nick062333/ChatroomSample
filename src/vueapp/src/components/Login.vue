<script>


export default{
    data(){
        return {
            account : '',
            password : ''
        }
    },
    created(){

        //TODO:需調整至共用方法
        this.$store.dispatch('auth/setAuth',{ token : '', userName:'', isLogin : false });
    
        window.localStorage.setItem('userData', JSON.stringify({ 
              token:'',
              userName: '',
              isLogin: false, 
          }));
    },
    methods:{
        Login()
        {
            console.log('login');

            this.$api.auth.login({ account : this.account, password : this.password })
            .then((response) =>{
                
                let responseData = response.data;

                if(!responseData || responseData.ChatroomStatusCode != 200)
                {
                    alert('登入失敗，可能帳號密碼有誤');
                    return;
                }

                let userData = { 
                    "token" : responseData.Data.token, 
                    "userName": responseData.Data.userName,     
                    "userId" : responseData.Data.userId,
                    "isLogin": true 
                };

                this.$store.dispatch('auth/setAuth', userData);

                window.localStorage.setItem('userData', JSON.stringify(userData));

                alert('已登入');
                this.$router.push("/");

            })
            .catch((error) => {
                this.$store.dispatch('auth/setAuth',{ token : '', userName:'', userId:'', isLogin : false });

                window.localStorage.setItem('userData', JSON.stringify({ 
                    token:'',
                    userName: '',
                    userId:'',
                    isLogin:false, 
                }));

                alert('登入失敗，伺服器異常請稍後在試');
            })
            .error
        },

        Register(){
            this.$router.push('/Register');
        }

    }
 }
</script>
<template>
<br />
<h2>登入</h2>
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