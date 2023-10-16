import request from '../https'

const message = {
    getMessageLogListTotalCount(params){
        return request('get','/message/count', params)
    },

    getMessageList(params){
        return request('get','/message', params)
    }
}

export default message;