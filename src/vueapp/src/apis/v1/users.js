import request from '../https'

const users = {
    getAll(){
        return request('get','/users/getall')
    }
}

export default users;