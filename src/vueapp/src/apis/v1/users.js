import request from '../https'

const users = {
    getAll(){
        return request('get','/users/getall')
    },
    register(){
        return request('post','/users/register')

    }
}

export default users;