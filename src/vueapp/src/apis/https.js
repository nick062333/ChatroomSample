const axios = require('axios');

const errorHandle = (status, msg) => {
    switch(status){
        case 400:
            alert('login fail');
            break;
        default:
            alert('option error');
    }
}


axios.interceptors.request.use(function (config) {
    // 在发送请求之前做些什么

    //發request前判斷token存在時須在header加上token
    const token = store.state.auth.token;
    token && (config.headers.Authorization = 'Bearer ' + token);

    return config;
  }, function (error) {
    // 对请求错误做些什么
    return Promise.reject(error);
  });