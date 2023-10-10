import Chatroom from '../components/Chatroom.vue'
import Login from '../components/Login.vue'
import Register from '../components/Register.vue'

import { createRouter, createWebHashHistory } from 'vue-router'

const routes = [
    { name:'Home', path: '/', component: Chatroom },
    // { name:'Chatroom', path: '/Chatroom', component: Chatroom },
    { name:'Login', path: '/login', component: Login },
    { name:'SignOut', path: '/SignOut', component: null },
    { name:'Register', path: '/Register', component: Register },
  ]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

router.beforeEach(async (to, from, next) => {

    console.log('beforeEach', to);

    if(to.name == 'Login' || to.name == 'Register'){

        //TODO:補清除驗證的動作
        next();
    }
    else
    {
        let userObject = window.localStorage.getItem("userData");
        
        console.log('userObject',userObject, !userObject);
        
        if(!userObject)
            return next({ name: 'Login' })
    
        let userData = JSON.parse(userObject);
        console.log('userData', userData);
    
        if(to.name == 'Login'){
            next();
        }
    
        if(userData.isLogin)
            next();
        else
            return next({ name: 'Login' })
    }
})

export default router