import $store from '../store'
import $router from '../router'

const utility = {
    SignOut(){
        console.log('signout function');
        $store.dispatch('auth/setAuth',{ token : '', userName:'', isLogin : false });
    
        window.localStorage.setItem('userData', JSON.stringify({ 
              token:'',
              userName: '',
              isLogin: false, 
          }));
    
        alert('已登出');
        $router.push("/Login");
    }
}

export default {
    install: (app, options) => {
        // inject a globally available $translate() method
        app.config.globalProperties.$utility = utility;
    }
} 