<style scoped>
  body{
    background-color: #f4f7f6;
    margin-top:20px;
}
.card {
    background: #fff;
    transition: .5s;
    border: 0;
    margin-bottom: 30px;
    border-radius: .55rem;
    position: relative;
    width: 100%;
    box-shadow: 0 1px 2px 0 rgb(0 0 0 / 10%);
}
.chat-app .people-list {
    width: 280px;
    position: absolute;
    left: 0;
    top: 0;
    padding: 20px;
    z-index: 7
}

.chat-app .chat {
    margin-left: 280px;
    border-left: 1px solid #eaeaea
}

.people-list {
    -moz-transition: .5s;
    -o-transition: .5s;
    -webkit-transition: .5s;
    transition: .5s
}

.chat-list{
    height: 350px;
    overflow: auto;
}

.people-list .chat-list li {
    padding: 10px 15px;
    list-style: none;
    border-radius: 3px;
}

.people-list .chat-list li:hover {
    background: #efefef;
    cursor: pointer
}

.people-list .chat-list li.active {
    background: #efefef
}

.people-list .chat-list li .name {
    font-size: 15px
}

.people-list .chat-list img {
    width: 45px;
    border-radius: 50%
}

.people-list img {
    float: left;
    border-radius: 50%
}

.people-list .about {
    float: left;
    padding-left: 8px
}

.people-list .status {
    color: #999;
    font-size: 13px
}

.chat .chat-header {
    padding: 15px 20px;
    border-bottom: 2px solid #f4f7f6
}

.chat .chat-header img {
    float: left;
    border-radius: 40px;
    width: 40px
}

.chat .chat-header .chat-about {
    float: left;
    padding-left: 10px
}

.chat .chat-history {
    padding: 20px;
    border-bottom: 2px solid #fff;
    height: 400px;
}

.chat .chat-history ul {
    padding: 0
}

.chat .chat-history ul li {
    list-style: none;
    margin-bottom: 30px
}

.chat .chat-history ul li:last-child {
    margin-bottom: 0px
}

.chat .chat-history .message-data {
    margin-bottom: 15px
}

.chat .chat-history .message-data img {
    border-radius: 40px;
    width: 40px
}

.chat .chat-history .message-data-time {
    color: #434651;
    padding-left: 6px
}

.chat .chat-history .message {
    color: #444;
    padding: 18px 20px;
    line-height: 26px;
    font-size: 16px;
    border-radius: 7px;
    display: inline-block;
    position: relative
}

.chat .chat-history .message:after {
    bottom: 100%;
    left: 7%;
    border: solid transparent;
    content: " ";
    height: 0;
    width: 0;
    position: absolute;
    pointer-events: none;
    border-bottom-color: #fff;
    border-width: 10px;
    margin-left: -10px
}

.chat .chat-history .my-message {
    background: #efefef
}

.chat .chat-history .my-message:after {
    bottom: 100%;
    left: 30px;
    border: solid transparent;
    content: " ";
    height: 0;
    width: 0;
    position: absolute;
    pointer-events: none;
    border-bottom-color: #efefef;
    border-width: 10px;
    margin-left: -10px
}

.chat .chat-history .other-message {
    background: #e8f1f3;
    text-align: right
}

.chat .chat-history .other-message:after {
    border-bottom-color: #e8f1f3;
    left: 93%
}

.chat .chat-message {
    padding: 20px
}

.online,
.offline,
.me {
    margin-right: 2px;
    font-size: 8px;
    vertical-align: middle
}

.online {
    color: #86c541
}

.offline {
    color: #e47297
}

.me {
    color: #1d8ecd
}

.float-right {
    float: right
}

.clearfix:after {
    visibility: hidden;
    display: block;
    font-size: 0;
    content: " ";
    clear: both;
    height: 0
}

@media only screen and (max-width: 767px) {
    .chat-app .people-list {
        height: 465px;
        width: 100%;
        overflow-x: auto;
        background: #fff;
        left: -400px;
        display: none
    }
    .chat-app .people-list.open {
        left: 0
    }
    .chat-app .chat {
        margin: 0
    }
    .chat-app .chat .chat-header {
        border-radius: 0.55rem 0.55rem 0 0
    }
    .chat-app .chat-history {
        height: 300px;
        overflow-x: auto
    }
}

@media only screen and (min-width: 768px) and (max-width: 992px) {
    .chat-app .chat-list {
        height: 650px;
        overflow-x: auto;
    }
    .chat-app .chat-history {
        height: 600px;
        overflow-x: auto
    }
}

@media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (orientation: landscape) and (-webkit-min-device-pixel-ratio: 1) {
    .chat-app .chat-list {
        height: 480px;
        overflow-x: auto;
    }
    .chat-app .chat-history {
        height: calc(100vh - 350px);
        overflow-x: auto
    }
}
.scrollbar{
    /* padding: 1rem; */
    max-height: 400px;
    overflow: auto;
  /* border: 1px solid lightgray; */
} 

.text-right{
    text-align: right;
}
</style>

<template>
    <div class="row clearfix">
        <div class="col-lg-12">
            <div class="card chat-app">
                <div id="plist" class="people-list">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">
                                <font-awesome-icon :icon="['fas', 'magnifying-glass']" size="xl" />
                            </span>
                        </div>
                        <input type="text" class="form-control" placeholder="Search..." v-model="keyword">
                    </div>
                    <ul class="list-unstyled chat-list mt-2 mb-0">
                        <li class="clearfix" v-if="this.tempChatroomList" v-for="(item) in this.tempChatroomList" 
                            :class="{ 'active' : this.groupId == item.ChatroomId }" 
                            v-bind:key="item.ChatroomId"
                            v-on:click="SetGroup(item)">
                            <!-- <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar"> -->
                            <img src="..\images\default.png" alt="avatar" >
                            
                            <div class="about">
                                <div class="name" >
                                    {{ item.UserName }} ({{ item.UserId }})<br>
                                     {{ item.ChatroomId  }}
                                </div>
                                <!-- <div class="status"> <i class="fa fa-circle offline"></i> left 7 mins ago </div>                                             -->
                            </div>
                        </li>
                        <!-- <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar">
                            <div class="about">
                                <div class="name">Vincent Porter</div>
                                <div class="status"> <i class="fa fa-circle offline"></i> left 7 mins ago </div>                                            
                            </div>
                        </li>
                        <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar">
                            <div class="about">
                                <div class="name">Vincent Porter</div>
                                <div class="status"> <i class="fa fa-circle offline"></i> left 7 mins ago </div>                                            
                            </div>
                        </li>
                        <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar1.png" alt="avatar">
                            <div class="about">
                                <div class="name">Vincent Porter</div>
                                <div class="status"> <i class="fa fa-circle offline"></i> left 7 mins ago </div>                                            
                            </div>
                        </li>
                        <li class="clearfix active">
                            <img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt="avatar">
                            <div class="about">
                                <div class="name">Aiden Chavez</div>
                                <div class="status"> <i class="fa fa-circle online"></i> online </div>
                            </div>
                        </li>
                        <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar3.png" alt="avatar">
                            <div class="about">
                                <div class="name">Mike Thomas</div>
                                <div class="status"> <i class="fa fa-circle online"></i> online </div>
                            </div>
                        </li>                                    
                        <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="avatar">
                            <div class="about">
                                <div class="name">Christian Kelly</div>
                                <div class="status"> <i class="fa fa-circle offline"></i> left 10 hours ago </div>
                            </div>
                        </li>
                        <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar8.png" alt="avatar">
                            <div class="about">
                                <div class="name">Monica Ward</div>
                                <div class="status"> <i class="fa fa-circle online"></i> online </div>
                            </div>
                        </li>
                        <li class="clearfix">
                            <img src="https://bootdey.com/img/Content/avatar/avatar3.png" alt="avatar">
                            <div class="about">
                                <div class="name">Dean Henry1</div>
                                <div class="status"> <i class="fa fa-circle offline"></i> offline since Oct 28 </div>
                            </div>
                        </li> -->
                    </ul>
                </div>
                <div class="chat">
                    <div class="chat-header clearfix">
                        <div class="row">
                            <div class="col-lg-6" v-if="ChatroomData">
                                <a href="javascript:void(0);" data-toggle="modal" data-target="#view_info">
                                    <!-- <img src="https://bootdey.com/img/Content/avatar/avatar2.png" alt="avatar"> -->
                                    <img src="..\images\default.png" alt="avatar">
                                </a>
                                <div class="chat-about">
                                    <h6 class="m-b-0" >{{ ChatroomData.UserName }}</h6>
                                    <!-- <small>Last seen: 2 hours ago</small> -->
                                </div>
                            </div>
                            <!-- <div class="col-lg-6 hidden-sm text-right">
                                <a href="javascript:void(0);" class="btn btn-outline-info">
                                    <font-awesome-icon :icon="['fas', 'right-from-bracket']" />
                                </a>
                            </div> -->
                        </div>
                    </div>
                    <div class="chat-history">
                        <ul class="m-b-0 scrollbar" @scroll.passive="HandleScroll" ref="messageBox">
                            <li class="clearfix" v-if="messageLog" v-for="(item, index) in messageLog">
                                <div class="message-data" :class="[{ 'text-right': item.SendUserId == this.$store.state.auth.userId}]">
                                    <span class="message-data-time">{{  $moment(item.SendTime).format('YYYY-MM-DD HH:mm') }}</span>
                                    <img src="..\images\default.png" alt="avatar">
                                </div>
                                <div class="message"
                                :class="[
                                    item.SendUserId == this.$store.state.auth.userId ? 'other-message' : 'my-message',
                                    item.SendUserId == this.$store.state.auth.userId ? 'float-right': ''
                                ]">
                                <!-- ({{ item.Id }}).  <br> -->
                                {{ item.Message }}
                                     
                                     <!-- {{ item.SendUserId }} 
                                     {{ this.$store.state.auth.userId }} 
                                     {{ item.SendUserId == this.$store.state.auth.userId }} -->
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="chat-message clearfix" v-if="this.groupId">
                        <div class="input-group mb-0">
                            <div class="input-group-prepend">
                                <span class="input-group-text" @click="SendMessage" :disabled="isSendMessage" ><font-awesome-icon :icon="['far', 'paper-plane']" size="xl" /></span>
                            </div>
                            <textarea type="textarea" class="form-control" placeholder="Enter text here..." v-model="tmpMessage"></textarea>                                    
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import * as signalR from '@microsoft/signalr';
// import { createStore, set, get, promisifyRequest } from 'idb-keyval';
import {  set, get, createStore } from 'idb-keyval';

export default 
{
    data(){
        return {
            keyword:'',
            chatroomList:[],
            isLoadMessage:false,
            loadMessageBtnName:"載入歷史訊息(20筆)",
            totalCount:0,
            pageSize:20,
            hubConnection: null,
            name: null,
            groupId:"",
            isSendMessage: true,
            tmpMessage:"",
            messageLog:[],
            isGroupLoadingCompleted:false,
            isMessageLoading:false
        }
    },
    watch: {
        messageLog:{
            handler() {
                // this.SetMessageLogBtnInfo();
            },
            deep: true
        }
    },

    computed:{
        ChatroomData(){

            if(!this.chatroomList)
                return null;

            var chatroom = this.chatroomList.filter((item) => { return item.ChatroomId == this.groupId });
            console.log('chatroom', chatroom);

            return chatroom[0];
        },

        tempChatroomList()
        {
            if(!this.$utility.IsNotNullAndNotEmpty(this.keyword))
                return this.chatroomList;

            return this.chatroomList.filter((item) => {
                console.log(item);
                return item.UserName.indexOf(this.keyword) > -1;
            })
        }
    },

    created(){
        this.GetChatroomList();
    },
    methods:{
        SendMessage(){

            this.isSendMessage = false;
            this.$api.auth.check()
                .then((response) => {
                    var isVaild = response.data.Data;
                    if(isVaild == true){
                        this.hubConnection.invoke('send', 
                        { 
                            Message: this.tmpMessage, 
                            SendTime: new Date().toJSON()
                        })
                        .then(() =>{
                            console.log('msg send',  this.$refs.messageBox);
                            // this.$refs.messageBox.target.scrollTop = 

                            this.$refs.messageBox.scrollTop = this.$refs.messageBox.scrollHeight;

                            this.tmpMessage = '';
                        })
                        .catch((error) => {
                            console.log('send message error', error);
                            this.$router.push("/");
                        });
                    }
                    else{
                        this.$utility.SignOut();
                    }
                })

            this.isSendMessage = true;
        },
        GetMessageList()
        {
            console.log('getMessageList');
            //isLoadingCompleted

            if(this.isGroupLoadingCompleted){
                return;
            }

            const ids = this.messageLog.map(object => {
                return object.Id;
            });

            const minMessageId = Math.min(...ids);
            console.log('minMessageId', minMessageId); 

            this.$api.v1.message.getMessageList({ 
                    chatroomId: this.groupId, 
                    messageId: minMessageId,
                    queryModeType: 2,
                    maxCount:20
                })
                .then((response) => {
                    let responseData = response.data;
                    console.log('Load Message', responseData);

                    if(responseData && responseData.ChatroomStatusCode == 200)
                    {
                        if(responseData.Data.MessageLogs)
                        {
                            responseData.Data.MessageLogs.forEach(element => {
                                this.messageLog.unshift(element);
                            });

                            this.SetMessageCache();

                            this.isMessageLoading = false;


                            this.$nextTick(() => {
                            this.$refs.messageBox.scrollTop = 750;
                        });
                        }
                        else{

                            this.isGroupLoadingCompleted = true;
                        }
                    }
                
                    // this.SetMessageLogBtnInfo();
                })
        },

        InitMessageLogData(){

            let groupMessageDB = createStore(`messageDB-${this.groupId}`, this.groupId);

            get(this.groupId, groupMessageDB)
                .then((val) => {
                    console.log('groupMessageDB', val);

                    let getMessageInfoRequest = { 
                            chatroomId: this.groupId, 
                            messageId: 0,
                            queryModeType: 1,
                            maxCount:20
                        };

                    if(val) {
                        this.messageLog = JSON.parse(val);

                        const ids = this.messageLog.map(object => {
                            return object.Id;
                        });

                        const maxMessageId = Math.max(...ids);
                        console.log('maxMessageId',ids, maxMessageId); 

                        getMessageInfoRequest.messageId = maxMessageId;
                        getMessageInfoRequest.maxCount = 0;
                    }
                    
                    //確認有無尚未顯示的訊息
                    this.$api.v1.message.getMessageList(getMessageInfoRequest)
                        .then((response) => {
                            console.log('getMessageList', response);

                            if(response.data.ChatroomStatusCode == 200 && this.$utility.IsArrayNotNullAndNotEmpty(response.data.Data.MessageLogs))
                            {
                                console.log('add', response.data.Data.MessageLogs);

                                response.data.Data.MessageLogs.forEach((item) =>{
                                    this.messageLog.push(item);
                                })

                                this.SetMessageCache();
                            }    

                            this.$nextTick(() => {
                                    this.$refs.messageBox.scrollTop = this.$refs.messageBox.scrollHeight;
                                });
                        })


                })
        },

        InitSignalR()
        {
            if(this.hubConnection)
            {
                this.hubConnection.stop().then(() => {
                    // alert('stop hubConnection');
                });
            }

            this.isGroupLoadingCompleted = false;

            this.hubConnection = new signalR.HubConnectionBuilder()
                .withUrl(`https://localhost:7057/hub/notification?GroupId=${this.groupId}`, { 
                    accessTokenFactory: () => this.$store.state.auth.token
                    // withCredentials: true,
                    // headers: {
                    //     "groupId": this.groupId
                    // },
                    // transport: signalR.HttpTransportType.LongPolling 
                })
                .withAutomaticReconnect({
                    nextRetryDelayInMilliseconds: retryContext => {

                        this.$api.auth.check()
                        .then((response) => {
                            if(response.data == true)
                            {
                                if (retryContext.elapsedMilliseconds < 10000) {
                                    return Math.random() * 10000;
                                } else {
                                    return null;
                                }
                            }
                            else
                                return null;
                        })
                    }
                })
                .build();

                this.hubConnection.start();

                this.hubConnection.on("ReceiveMessage", (userName, messageId, message, sendTime, status)  => {

                    console.log('ReceiveMessage', messageId);
                    this.messageLog.push({ 
                        GroupId: this.groupId, 
                        Status: status,
                        UserName: userName, 
                        SendUserId: this.$store.state.auth.userId,
                        Message: message, 
                        Id: messageId,
                        SendTime: sendTime
                    });
                });

            this.InitMessageLogData();
        },

        SetMessageCache()
        {
            let groupMessageDB = createStore(`messageDB-${this.groupId}`, this.groupId);
            set(this.groupId, JSON.stringify(this.messageLog), groupMessageDB)
                .then(() => {
                        console.log('set 儲存成功');
                });
        },

        HandleScroll (e) {
            console.log(e.target.scrollTop);

            if(e.target.scrollTop <= 0 && this.isMessageLoading == false)
            {
                this.isMessageLoading = true;
                this.GetMessageList();
            }
        },

        //取得左邊聊天室列表
        GetChatroomList(){
            this.$api.v1.chatroom.getChatroomList()
                .then((response) =>{
                    console.log('GetChatroomList',response);

                    if(response.data.ChatroomStatusCode == 200)
                        this.chatroomList = response.data.Data;
                })
        },

        SetGroup(group)
        {
            console.log('SetGroup',group.ChatroomId, group.UserId);
            
            this.messageLog = [];

            if(group.ChatroomId == "00000000-0000-0000-0000-000000000000")
            {
                this.$api.v1.chatroom.addChatroom({
                    toUserId: group.UserId
                })
                    .then((response) => {
                        if(response.data.ChatroomStatusCode == 200)
                        {
                            console.log('addChatroom', response);
                            group.ChatroomId = response.data.Data.ChatroomId;
                            this.groupId = group.ChatroomId;
                            this.InitSignalR();
                        }
                    });
            }
            else{
                this.groupId = group.ChatroomId;
                this.InitSignalR();
            }
        }
    }
}
</script>