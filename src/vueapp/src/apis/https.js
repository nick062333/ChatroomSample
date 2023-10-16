import axios from 'axios';
import store from '../store';
import router from '../router'


var instance = axios.create({
    baseURL: 'https://localhost:7057/api/',
})

// axios.defaults.withCredentials = true;


instance.interceptors.request.use(function (config) {
    // 在发送请求之前做些什么

    //發request前判斷token存在時須在header加上token

    console.log('request interceptors');

    const token = store.state.auth.token;
    token && (config.headers.Authorization = 'Bearer ' + token);

    if(store.state.auth.token && config.url != '/auth/check')
    {
        // CustomHttpClient('get', '/auth/check')
        // .then((response) =>{
        //     console.log('/auth/check', response);
        // })
    }
        
    return config;
  }, (error) => {
    console.log('interceptors request error', error);

    if (error.response) {
        errorHandle(error.status, error.data.error);
    }
    else{
        alert('登入驗證已失效');
        router.push('/login')
        return;
    }

    return Promise.reject(error);
  });

  instance.interceptors.response.use(function (response) {
    // console.log('interceptors response', response);
    return response;
  },  (error) => {

    console.log('interceptors.response error', error.response);

    if (error.response) {
        errorHandle(error.status, error.data.error);
    }
    else{
        alert('登入驗證已失效');
        router.push('/login')
        return;
    }

    return Promise.reject(error);
  });



const errorHandle = (status, msg) => {

    console.log('error status',status);
    switch(status){
        case 400:
            alert('登入失敗');
            break;
        case 401:
            alert('登入驗證已失效');
            router.push('/login')
            break;
        default:
            console.error('未知的status', status);
    }
}

function CustomHttpClient(method, url, data = null){

    console.log('http.js url', url, method, data);

    method = method.toLowerCase();
    
    switch(method){
        case 'post':
            return instance.post(url, data);
        case 'get':
        return instance.get(url, {
            params: data
          });
        case 'delete':
            return instance.delete(url, {
                params: data
              });
        case 'put':
            return instance.put(url, data);
    }

    console.error('未知的method', method);
    return false;
}

export default CustomHttpClient