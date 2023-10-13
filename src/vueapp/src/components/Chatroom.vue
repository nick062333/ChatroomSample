<style scoped>
    /* 當<style>標籤具有該scoped屬性時，其 CSS 將僅套用於目前組件的元素。這類似於 Shadow DOM 中的樣式封裝。 */
   a {
    display:inline;
    margin-right: 15px;
  }

  .message_log_box{
    background-color: #FFD382;
    padding:10px;
    margin-bottom:5px;
  }

  .message_log{
    display:inline;
    padding:10px;
    margin-bottom:5px;
  }
</style>

<template>
    <div class="message_log_box">
        <p>
            <button class="btn btn-dark" v-on:click="GetMessageLogList" :disabled="!isLoadMessage">{{ loadMessageBtnName }}</button>
        </p>
        <div class="card" v-if="messageLog" v-for="(item, index) in messageLog">
            <div class="card-body" :style="{ 'text-align': (item.SendUserId == this.$store.state.auth.userId ? 'right': 'left') }">
                <b>{{ item.Id }}. {{ item.UserName }}</b>: {{ item.Message }} <br> {{  $moment(item.SendTime).format('YYYY-MM-DD HH:mm:ss') }}
            </div>
        </div>
    </div>
    <br>
    <div>
        <div>

            <!-- <div class="input-group flex-nowrap">
                <span class="input-group-text" id="addon-wrapping">群組代碼</span>
                <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="addon-wrapping">
            </div> -->
            <div class="mb-3">
                <label for="exampleFormControlTextarea1" class="form-label">訊息</label>
                <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" v-model="tmpMessage"></textarea>
            </div>
            <button type="button" class="btn btn-primary" @click="SendMessage">發送</button>
        </div>


    </div>
</template>

<script>
import * as signalR from '@microsoft/signalr';
import { createStore, set, get } from 'idb-keyval';



export default 
{
    data(){
        return {
            isLoadMessage:false,
            loadMessageBtnName:"載入歷史訊息(20筆)",
            messageLogCount:0,
            totalCount:0,
            pageSize:20,
            hubConnection: null,
            name: null,
            groupId:"46be0312-c43a-451d-8489-45f426bdba54",
            tmpMessage:"",
            messageLog:[
      
            ]
        }
    },
    watch: {
        messageLog:{
            handler(newValue) {
                this.SetMessageLogBtnInfo();
            },
            deep: true
        }
    },
    created(){
        this.SetMessageTotalCount();
        this.InitMessageLogData();
        this.InitSignalR();
    },
    methods:{
        SendMessage(){
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
                            console.log('msg send');
                        })
                        .catch((error) => {
                            console.log('send message error', this.$router);
                            this.$router.push("/");
                        });
                    }
                    else{
                        this.$utility.SignOut();
                    }
                })
        },
        GetMessageLogList()
        {
            console.log('GetMessageLogList',this.messageLogCount)
            this.$api.v1.message.getMessageLogList({ 
                    groupId : this.groupId, 
                    startIndex : this.messageLogCount <= 0 ? 0 : this.messageLogCount - 1, 
                    pageSize : this.pageSize 
                })
                .then((response) => {
                    let responseData = response.data;
                    console.log('LoadMessage', responseData);

                    if(responseData && responseData.ChatroomStatusCode == 200 && responseData.Data.MessageLogs)
                    {
                        responseData.Data.MessageLogs.forEach(element => {
                            this.messageLog.unshift(element);
                        });

                        this.SetMessageCache();
                    }
                
                    this.SetMessageLogBtnInfo();
                })
        },
        SetMessageTotalCount()
        {
            this.totalCount = 0;

            this.$api.v1.message.getMessageLogListTotalCount({ groupId : this.groupId })
                .then((response) => {
                    console.log('getMessageLogListTotalCount', response);
                    this.totalCount = response.data.Data.TotalCount;
                    this.SetMessageLogBtnInfo();
        
                });
        },

        SetMessageLogBtnInfo()
        {
            if(this.messageLogCount < this.totalCount)
            {
                this.isLoadMessage = true;
                this.loadMessageBtnName = "載入歷史訊息(20筆)";
            }
            else{
                this.isLoadMessage = false;
                this.loadMessageBtnName = "訊息載入完畢";
            }
        }, 

        InitMessageLogData(){
            this.groupMessageDB = createStore('messageDB', this.groupId);

            get(this.groupId, this.groupMessageDB)
                .then((val) => {
                    console.log('groupMessageDB', val);
                    if(val) {
                        this.messageLog = JSON.parse(val);

                        const maxIdItem = this.messageLog 
                            .reduce((max, item) => (item.Id > max.Id ? item : max), this.messageLog[0]);

                        console.log('maxIdItem', maxIdItem);

                        console.log('messageLog',this.messageLog);

                        this.$api.v1.message.getMessageLogListByIdRange({ 
                            groupId: this.groupId, 
                            startId: maxIdItem.Id 
                        })
                        .then((response) => {
                            console.log('getMessageLogListByIdRange', response);

                            if(response.data.ChatroomStatusCode == 200 && this.$utility.IsArrayNotNullAndNotEmpty(response.data.Data))
                            {
                                console.log('add', response.data.Data);
                                this.messageLog.push(response.data.Data);

                                this.SetMessageCache();
                            }    
                        })
                    }
                })
        },

        InitSignalR()
        {
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
                                    // If we've been reconnecting for less than 60 seconds so far,
                                    // wait between 0 and 10 seconds before the next reconnect attempt.
                                    return Math.random() * 10000;
                                } else {
                                    // If we've been reconnecting for more than 60 seconds so far, stop reconnecting.
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

                this.hubConnection.on("ReceiveMessage", (userName, message, sendTime, status)  => {
                    this.messageLog.push({ 
                        GroupId: this.groupId, 
                        Status: status,
                        UserName: userName, 
                        SendUserId: this.$store.state.auth.userId,
                        Message: message, 
                        SendTime: sendTime
                    });

                    // set(this.groupId, JSON.stringify(this.messageLog), this.groupMessageDB)
                    //     .then(() => console.log('set 儲存成功'));

                });
        },

        SetMessageCache()
        {
            this.messageLogCount = this.messageLog.length;

            set(this.groupId, JSON.stringify(this.messageLog), this.groupMessageDB)
                .then(() => {
                        console.log('set 儲存成功');
                });
        }
    }
}
</script>