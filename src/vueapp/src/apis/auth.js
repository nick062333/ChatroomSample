// 為了讓api調用更方便，把api掛載到vue的prototype上。
// 其中，api可能會有版本號的分別，也可以封裝後更方便管理。

import req from './https'

const auth = {
    // signUp(params){
    //     // this.$store.dispatch('auth/setAuth',{ token : '', isLogin : false });
    //     // return req('post', '/auth/signup', params);
    // },
    login(params){
        return req('post', '/auth/login', params);
    }
}

export default auth;