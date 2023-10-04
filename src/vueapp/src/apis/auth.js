// 為了讓api調用更方便，把api掛載到vue的prototype上。
// 其中，api可能會有版本號的分別，也可以封裝後更方便管理。

import request from './https'

const auth = {
    signUp(params){
        return request('post', '/signup', params);
    },
    login(params){
        return request('post', '/login', params);
    }
}

export default auth;