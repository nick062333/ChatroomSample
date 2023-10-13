import request from '../https'

const message = {
    getMessageLogList(params){
        return request('post','/message/get_message_log_list', params)
    },

    getMessageLogListTotalCount(params){
        return request('get','/message/get_message_log_list_total_count', params)
    },

    getMessageLogListByIdRange(params){
        return request('get','/message/get_message_log_list_by_id_range', params)
    }
}

export default message;