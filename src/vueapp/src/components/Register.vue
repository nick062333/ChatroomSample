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
            this.$api.v1.user.register({ 
                account : this.account, 
                password : this.password, 
                userName: this.userName })
            .then((response) =>{
                let responseData = response.data;
                console.log('login', responseData);

                if(responseData && responseData.ChatroomStatusCode == 200)
                {
                    alert('註冊成功');
                    this.$router.push("/Login");
                }
                else{
                    alert(responseData.Description);
                }
            })
            .catch((error) => {
                console.log(error);
            })
        },
    }
 }
</script>
<template>
  <div class="row align-items-start">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active" aria-current="page">註冊</li>
        </ol>
    </nav>
  </div>
  <div class="row align-items-center">
    <div class="col">
        <form class="row g-3">
            <div class="mb-3 row">
                <label for="staticEmail" class="col-sm-2 col-form-label">使用者名稱</label>
                <div class="col-sm-10">
                <input type="text" class="form-control" v-model="userName">
            </div>
            </div>
            <div class="mb-3 row">
                <label for="text" class="col-sm-2 col-form-label">帳號</label>
                <div class="col-sm-10">
                <input type="text" class="form-control" id="text"  v-model="account">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="inputPassword" class="col-sm-2 col-form-label">密碼</label>
                <div class="col-sm-10">
                <input type="password" class="form-control" id="inputPassword"  v-model="password">
                </div>
            </div>
            <div class="col-auto">
                <button type="button" class="btn btn-primary mb-3" v-on:click="ToRegister()">註冊</button>
                <button type="reset" class="btn btn-primary mb-3" >清除</button>
            </div>
        </form>
    </div>
  </div>
  <div class="row align-items-end">
    <div class="col">
      One of three columns
    </div>
    <div class="col">
      One of three columns
    </div>
    <div class="col">
      One of three columns
    </div>
  </div>
</template>

<style>

</style>