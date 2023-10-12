import request from '../https'

const message = {
    getMessageLogList(params){
        return request('post','/message/get_message_log_list', params)
    },
}

export default message;