<script setup>
// import { ref } from 'vue'

import * as signalR from '@microsoft/signalr';
// const signalR = require("@microsoft/signalr")

let connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7057/chat")
    .build();

// connection.on("send", data => {
//     console.log('send', data);
//     });

connection.on("ReceiveMessage", data => {
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.
    console.log('ReceiveMessage=', data);
});

connection.start()
    .then(() => {

        console.log('start');
        connection.invoke("send", "Hello");

    });

</script>

<template>
  <p class="greeting">{{ greeting }}</p>
</template>

<style>
.greeting {
  color: red;
  font-weight: bold;
}
</style>