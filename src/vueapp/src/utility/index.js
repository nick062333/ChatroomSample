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
    
        $router.push("/Login");
    },

    IsArrayNotNullAndNotEmpty(arr) {
        return arr !== null && arr.length > 0;
    },

    IsNotNullAndNotEmpty(value) {
        return value !== null && value;
    }
}

export default {
    install: (app, options) => {
        // inject a globally available $translate() method
        app.config.globalProperties.$utility = utility;
    }
} 