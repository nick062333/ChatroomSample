import request from '../https'

const chatroom = {
    getChatroomList(params){
        return request('get','/chatroom', params)
    },
    addChatroom(params){
        return request('post','/chatroom', params)
    },
}

export default chatroom;