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
            對話框<button v-on:click="LoadMessage">載入歷史訊息(20筆)</button>
        </p>
        <div class="card" v-if="messageLog" v-for="(item, index) in messageLog">
            <div class="card-body" :style="{ 'text-align': (item.SendUserId == this.$store.state.auth.userId ? 'right': 'left') }">
                <b>{{ item.UserName }}</b>: {{ item.Message }} <br> {{ $moment(item.SendDate).format('YYYY-MM-DD HH:mm:ss') }}
            </div>
        </div>
        <!-- <div v-for="(item, index) in messageLog">使用者名稱:{{ item.userName }} 訊息:{{ item.message }}  發送時間:{{ item.sendDate }}</div> -->
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
import { createStore, set, get, entries, setMany  } from 'idb-keyval';



export default 
{
    data(){
        return {
            startIndex:0,
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
        // 每当 question 改变时，这个函数就会执行
        messageLog:{
            handler(newValue, oldValue) {
            // 注意：在嵌套的变更中，
            // 只要没有替换对象本身，
            // 那么这里的 `newValue` 和 `oldValue` 相同
            this.startIndex = (!newValue || newValue.length <= 1 ) ? 0 : newValue.length - 1;
            console.log('startIndex',this.startIndex);
            },
            deep: true
        }
    },
    created(){

        this.groupMessageDB = createStore('messageDB', this.groupId);

        get(this.groupId, this.groupMessageDB)
            .then((val) => {
                console.log('groupMessageDB', val);
                if(val) {
                    this.messageLog = JSON.parse(val);
                }
            })

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
                        if (retryContext.elapsedMilliseconds < 30000) {
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

        this.hubConnection.on("ReceiveMessage", (userName, message, sendDate, status)  => {
            this.messageLog.push({ 
                GroupId: this.groupId, 
                Status: status,
                UserName: userName, 
                SendUserId: this.$store.state.auth.userId,
                Message: message, 
                SendDate: sendDate
            });

            set(this.groupId, JSON.stringify(this.messageLog), this.groupMessageDB)
                .then(() => console.log('set 儲存成功'));

        });
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
                            SendDate: new Date().toJSON()
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
        LoadMessage()
        {
            let vm = this;
            vm.page += 1;
            vm.$api.v1.message.getMessageLogList({ 
                    groupId : vm.groupId, 
                    page : vm.page, 
                    pageSize : vm.pageSize 
                })
                .then((response) => {
                    let responseData = response.data;
                    console.log('LoadMessage', responseData);

                    if(responseData && responseData.ChatroomStatusCode == 200)
                    {
                        responseData.Data.MessageLogs.forEach(element => {
                            vm.messageLog.unshift(element);
                        });
                    }
                
                })
        }
    }
}
</script>