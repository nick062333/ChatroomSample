// import './assets/main.css'

import { createApp, nextTick } from 'vue'
import App from './App.vue'
import SignalRSmaple1 from './components/SignalRSmaple1.vue'
import Chatroom from './components/Chatroom.vue'
import Login from './components/Login.vue'

import { createRouter, createWebHashHistory } from 'vue-router'

import Store from './store/index.js';
import Vuex from 'vuex';

import api from './apis'

import 'bootstrap/dist/css/bootstrap.min.css'
import "bootstrap"

// import cors from 'cors'

const Home = { template: '<div>Home Test</div>' }

const routes = [
    { path: '/', component: Home },
    { path: '/SignalRSmaple1', component: SignalRSmaple1 },
    { path: '/Chatroom', component: Chatroom },
    { path: '/login', component: Login },
  ]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

const app = createApp(App)

//必須使 next tick,會有載入順序問題, 導致綁定失敗
nextTick(()=>{
  // Vue.prototype.$api = api; => vue2.x
  app.config.globalProperties.$api = api;
})

app.use(router)
app.use(Vuex)
app.use(Store)
// app.use(cors)

app.mount('#app')