import Chatroom from '../components/Chatroom.vue'
import Login from '../components/Login.vue'
import Home from '../components/Home.vue'

import { createRouter, createWebHashHistory } from 'vue-router'

const routes = [
    { name:'Home', path: '/', component: Chatroom },
    // { name:'Chatroom', path: '/Chatroom', component: Chatroom },
    { name:'Login', path: '/login', component: Login },
    { name:'SignOut', path: '/SignOut', component: null },
  ]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

router.beforeEach(async (to, from, next) => {

    console.log('beforeEach', to);

    let userObject = window.localStorage.getItem("userData");

    if(!userObject == null)
    return next({ name: 'Login' })

    let userData = JSON.parse(userObject);
    console.log('userData', userData);

    if(to.name == 'Login'){
        window.localStorage.getItem("userData");
        next();
    }







    if(userData.isLogin)
        next();
    else
        return next({ name: 'Login' })
})

export default router