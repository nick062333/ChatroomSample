import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import SignalRSmaple1 from './components/SignalRSmaple1.vue'
import Chatroom from './components/Chatroom.vue'

import { createRouter, createWebHashHistory } from 'vue-router'


const Home = { template: '<div>Home3213123123</div>' }
const About = { template: '<div>About</div>' }

const routes = [
    { path: '/', component: Home },
    { path: '/SignalRSmaple1', component: SignalRSmaple1 },
    { path: '/Chatroom', component: Chatroom },
  ]

const router = createRouter({
    history: createWebHashHistory(),
    routes, 
})

const app = createApp(App)

app.use(router)

app.mount('#app')