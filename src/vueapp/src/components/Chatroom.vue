<style scoped>
    /* 當<style>標籤具有該scoped屬性時，其 CSS 將僅套用於目前組件的元素。這類似於 Shadow DOM 中的樣式封裝。 */
   a {
    display:inline;
    margin-right: 15px;
  }

  div {

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
        <div v-for="(item, index) in messageLog">使用者名稱:{{ item.userName }} 訊息:{{ item.message }}  發送時間:{{ item.sendDate }}</div>
    </div>
    <br>
    <div>
        <div>
            <div>姓名:<input type="text" v-model="name" /></div>
            <div>
                訊息:<textarea v-model="tmpMessage"></textarea>
                <button @click="SendMessage">發送訊息</button>
            </div>
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
            name:"",
            tmpMessage:"123",
            messageLog:[{ userName:"小名", message: "a", sendDate:new Date().toJSON()}]
        }
    },
    created(){
        console.log('create');

        var vm = this;

        vm.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("https://localhost:7057/notification")
            .build();

            vm.hubConnection.start();

            vm.hubConnection.on("ReceiveMessage", (userName, message, sendDate)  => {
                console.log('ReceiveMessage=', userName, message, sendDate);
                
                vm.messageLog.push({ userName, message, sendDate});

        }   );
    },
    methods:{

        SendMessage(){
            this.hubConnection.invoke('send', 
                { 
                    UserId: this.name, 
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


// import * as signalR from '@microsoft/signalr';
// // const signalR = require("@microsoft/signalr")
// let connection = new signalR.HubConnectionBuilder()
//     .withUrl("https://localhost:7057/chat")
//     .build();

// connection.on("ReceiveMessage", data => {
//     console.log('ReceiveMessage=', data);
// });

// connection.start()
//     .then(() => {

//         console.log('start');
//         connection.invoke("NewSend", "Hello");

//     });

</script>