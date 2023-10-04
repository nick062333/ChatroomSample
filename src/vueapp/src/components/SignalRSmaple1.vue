<script setup>
// import { ref } from 'vue'

import * as signalR from '@microsoft/signalr';
// const signalR = require("@microsoft/signalr")

let connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7057/chat")
    .build();

connection.on("ReceiveMessage", data => {
    console.log('ReceiveMessage=', data);
});

connection.start()
    .then(() => {

        console.log('start');
        connection.invoke("NewSend", "Hello");

    });

</script>

<template>
  <p class="greeting">{{ greeting }}</p>
  <p></p>
</template>

<style>
.greeting {
  color: red;
  font-weight: bold;
}
</style>