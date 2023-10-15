// import './assets/main.css'

import { createApp, nextTick } from 'vue'
import App from './App.vue'

import Store from './store/index.js';
import Vuex from 'vuex';

import api from './apis';

import 'bootstrap/dist/css/bootstrap.min.css';
import "bootstrap";

import router from './router/index.js';

import moment from 'moment';

import { v4 as uuidv4 } from 'uuid';

import utility from './utility'

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { fab  } from '@fortawesome/free-brands-svg-icons'
import { fas } from '@fortawesome/free-solid-svg-icons'
import { far } from '@fortawesome/free-regular-svg-icons'

library.add(fab , fas, far)

const app = createApp(App,{
  methods: {
    LoginOff() {
      console.log('LoginOff')
    },
  }

}).component('font-awesome-icon', FontAwesomeIcon)

//必須使 next tick,會有載入順序問題, 導致綁定失敗
nextTick(()=>{
  // Vue.prototype.$api = api; => vue2.x
  app.config.globalProperties.$api = api;
  app.config.globalProperties.$moment = moment;
  app.config.globalProperties.$uuid = uuidv4;
})

app.use(router)
app.use(Vuex)
app.use(Store)
app.use(utility);
// app.use(cors)



app.mount('#app')