// 為了讓api調用更方便，把api掛載到vue的prototype上。
// 其中，api可能會有版本號的分別，也可以封裝後更方便管理。

import req from './https'

const auth = {
    signUp(){
        this.$store.dispatch('auth/setAuth',{ 
                "token" : '', 
                "userName": '', 
                "isLogin": false 
            });

            this.$store.dispatch('auth/setAuth',{ token : '', userName:'', isLogin : false });

            window.localStorage.setItem('userData', JSON.stringify({ 
                  token:'',
                  userName: '',
                  isLogin: false, 
              }));
    
            alert('已登出');
            
            this.$router.push("/");
        // return req('post', '/auth/signup', params);
    },
    login(params){
        return req('post', '/auth/login', params);
    }
}

export default auth;