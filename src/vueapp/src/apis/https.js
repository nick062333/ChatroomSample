import axios from 'axios';
import store from '../store';

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

    return config;
  }, function (error) {
    // 对请求错误做些什么
    return Promise.reject(error);
  });

  instance.interceptors.response.use(function (response) {
    console.log('interceptors response', response);
    return response;
  },  (error) => {
    const { response } = error;

    console.log('response error', error);
    console.log('response error2', response);

    if(response){
        errorHandle(response.status, response.data.error);
    }
    else{
        //回傳一個以 reason 拒絕的 Promise 物件

        alert('連線失敗，後台掛掉或沒網路')
        return Promise.reject(error);
    }
  });



const errorHandle = (status, msg) => {

    console.log('error status',status);
    switch(status){
        case 400:
            alert('登入失敗');
            break;
        case 401:
            alert('登入驗證已失效');
            this.$router.push('/login')
            break;
        default:
            console.error('未知的status', status);
    }
}


export default function(method, url, data = null){

    console.log('http.js url', url, method, data);

    method = method.toLowerCase();
    
    switch(method){
        case 'post':
            return instance.post(url, data);
        case 'get':
        return instance.get(url, data);
        case 'delete':
            return instance.delete(url, data);
        case 'put':
            return instance.put(url, data);
    }

    console.error('未知的method', method);
    return false;
}