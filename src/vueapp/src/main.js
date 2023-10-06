// import './assets/main.css'

import { createApp, nextTick } from 'vue'
import App from './App.vue'

import Store from './store/index.js';
import Vuex from 'vuex';

import api from './apis'

import 'bootstrap/dist/css/bootstrap.min.css'
import "bootstrap"

import router from './router/index.js';

// import cors from 'cors'

// const routes = [
//     { path: '/', component: Home },
//     { path: '/Chatroom', component: Chatroom },
//     { path: '/login', component: Login },
//     { path: '/SignOut', component: null },
//   ]

// const router = createRouter({
//     history: createWebHashHistory(),
//     routes
// })

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