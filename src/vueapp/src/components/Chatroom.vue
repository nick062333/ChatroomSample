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
        <p>對話框</p>
        <div class="card" v-for="(item, index) in messageLog">
            <div class="card-body" :style="{ 'text-align': (item.userName == this.$store.state.auth.userName ? 'right': 'left') }">
                {{ item.userName }}: {{ item.message }}
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
// import { ref } from 'vue'
import * as signalR from '@microsoft/signalr';

export default 
{
    data(){
        return {
            hubConnection: null,
            name: null,
            groupId:"group01",
            tmpMessage:"123",
            messageLog:[{ userName:"小名", message: "a", sendDate:new Date().toJSON()}]
        }
    },
    created(){
        console.log('create',this.$store.state.auth );
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl(`https://localhost:7057/hub/notification?GroupName=${this.groupId}`, { 
                accessTokenFactory: () => this.$store.state.auth.token
                // withCredentials: true,
                // headers: {
                //     "groupId": this.groupId
                // },
                // transport: signalR.HttpTransportType.LongPolling 
            })
            .build();

            this.hubConnection.start();

            this.hubConnection.on("ReceiveMessage", (userName, message, sendDate)  => {
                console.log('ReceiveMessage=', userName, message, sendDate);
                
                this.messageLog.push({ userName, message, sendDate});

        }   );
    },
    methods:{

        SendMessage(){
            this.hubConnection.invoke('send', 
                { 
                    // UserId: this.name, 
                    // GroupName: this.groupId,
                    Message: this.tmpMessage, 
                    SendDate: new Date().toJSON()
                })
                    .then(() =>
                    {
                        console.log('msg send');
                    });
        }
    }
}
</script>