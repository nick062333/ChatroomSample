import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import SignalRSmaple1 from './components/SignalRSmaple1.vue'
import Chatroom from './components/Chatroom.vue'

import { createRouter, createWebHashHistory } from 'vue-router'

import './assets/main.css'

import Store from './store/index.js';
import Vuex from 'vuex';

const Home = { template: '<div>Home Test</div>' }
const About = { template: '<div>About</div>' }

const routes = [
    { path: '/', component: Home },
    { path: '/SignalRSmaple1', component: SignalRSmaple1 },
    { path: '/Chatroom', component: Chatroom },
  ]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

const app = createApp(App)

app.use(router)

app.use(Vuex);
app.use(Store)

app.mount('#app')