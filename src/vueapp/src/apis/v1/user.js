import request from '../https'

const users = {
    getAll(){
        return request('get','/user/getall')
    },
    register(params){
        return request('post','/user/register', params)

    }
}

export default users;